using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using User_Management.Data;
using User_Management.ViewModel;
using System.Security.Cryptography;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;


namespace User_Management.Controllers
{
   
    public class UsersController : Controller
    {
        private readonly UserManagementDbContext _context;

        public UsersController(UserManagementDbContext context)
        {
            _context = context;
        }

        // GET: Users
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userManagementDbContext = _context.Users.Include(u => u.Role);
            return View(await userManagementDbContext.ToListAsync());
        }



        public async Task<IActionResult> Details(int? id)
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("NotRole", "Account");
            }

            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            // Chỉ hiển thị các thông tin khác trừ mật khẩu
            var viewModel = new User
            {
                Fullname = user.Fullname,
                CreatedDate = DateTime.Now,
                IsActive = user.IsActive,
                Gender = user.Gender,   
                Email = user.Email,
                Username = user.Username,
                Role = user.Role,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Phone = user.Phone,
                ProfileImage = user.ProfileImage,
                // Mật khẩu đã mã hóa hoặc chỉ hiển thị một phần nếu cần thiết
                 Password = HashPassword(user.Password),
            };

            return View(viewModel);
        }


        // GET: Users/Create

        public IActionResult Create()
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("NotRole", "Account");
            }


            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId");
            return View();
        }


        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserVM createUserVM)
        {
            if (ModelState.IsValid)
            {
                // Check if Email or Username already exists
                if (_context.Users.Any(u => u.Email == createUserVM.Email || u.Username == createUserVM.Username))
                {
                    ModelState.AddModelError("", "Email or Username already exists.");
                    // Load roles for dropdown list
                    ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", createUserVM.RoleId);
                    return View(createUserVM);
                }

                // Handle profile image upload
                string profileImagePath = null;
                if (createUserVM.ProfileImage != null)
                {
                    var fileName = Path.GetFileName(createUserVM.ProfileImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await createUserVM.ProfileImage.CopyToAsync(stream);
                    }
                    profileImagePath = $"{fileName}";
                }

                var user = new User
                {
                    RoleId = createUserVM.RoleId,
                    Fullname = createUserVM.Fullname,
                    Email = createUserVM.Email,
                    Username = createUserVM.Username,
                    Password = HashPassword(createUserVM.Password), // Encrypt password before saving
                    DateOfBirth = createUserVM.DateOfBirth,
                    Gender = createUserVM.Gender,
                    Address = createUserVM.Address,
                    Phone = createUserVM.Phone,
                    ProfileImage = profileImagePath, // Save the path of the image
                    CreatedDate = DateTime.Now,
                    IsActive = true
                };

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Load roles for dropdown list
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", createUserVM.RoleId);
            return View(createUserVM);
        }
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleId", user.RoleId);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Fullname,Username,Password,Gender,DateOfBirth,Address,Phone,Email,RoleId,ProfileImage")] EidtUser model)
        {
            if (id != model.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    var user = await _context.Users.FindAsync(id);
                    if (user == null)
                    {
                        return NotFound();
                    }

                    user.RoleId = model.RoleId;
                    user.Fullname = model.Fullname;
                    user.Username = model.Username;
                    user.Gender = model.Gender;
                    user.DateOfBirth = model.DateOfBirth;
                    user.Address = model.Address;
                    user.Phone = model.Phone;
                    user.Email = model.Email;

                    if (!string.IsNullOrEmpty(model.Password))
                    {
                        user.Password = HashPassword(model.Password);
                    }

                    if (model.ProfileImage != null)
                    {
                        var fileName = Path.GetFileName(model.ProfileImage.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ProfileImage.CopyToAsync(stream);
                        }

                        user.ProfileImage = fileName;  // Lưu tên tệp vào cơ sở dữ liệu
                    }

                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Users.Any(u => u.UserId == id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", model.RoleId);
            return View(model);
        }


        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!User.IsInRole("Admin"))
            {
                return RedirectToAction("NotRole", "Account");
            }
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
