using System.Text;
using Microsoft.AspNetCore.Mvc;
using User_Management.Data;
using User_Management.ViewModel;
using System.Security.Cryptography;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using User_Management.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace User_Management.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManagementDbContext _context;

        public AccountController(UserManagementDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == MySetting.CLAIM_USERID)?.Value;

            if (userId == null)
            {
                return RedirectToAction("Login"); // Redirect to login if user ID is not found
            }

            var customer = _context.Users.Find(Convert.ToInt32(userId));
            if (customer == null)
            {
                return NotFound(); // Return a NotFound view or similar error handling
            }

            return View(customer);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem Email hoặc Username đã tồn tại chưa
                if (_context.Users.Any(u => u.Email == model.Email || u.Username == model.Username))
                {
                    ModelState.AddModelError("", "Email or Username already exists.");
                    return View(model);
                }

                // Xử lý tệp hình ảnh
                string profileImagePath = null;
                if (model.ProfileImage != null)
                {
                    var fileName = Path.GetFileName(model.ProfileImage.FileName);
                    // Đường dẫn chính xác từ thư mục wwwroot
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "assets", "img", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ProfileImage.CopyToAsync(stream);
                    }
                    profileImagePath = $"{fileName}";
                }

                // Tạo người dùng mới
                var user = new User
                {
                    Fullname = model.Fullname,
                    Email = model.Email,
                    Username = model.Username,
                    Password = HashPassword(model.Password),
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    Address = model.Address,
                    Phone = model.Phone,
                    ProfileImage = profileImagePath,
                    CreatedDate = DateTime.Now,
                    RoleId = 2, // Giả sử 2 là ID cho vai trò User. Cân nhắc lấy từ cơ sở dữ liệu.
                    IsActive = true
                };

                try
                {
                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu có
                    ModelState.AddModelError("", "An error occurred while creating the user. Please try again.");
                    // Ghi log lỗi để dễ dàng gỡ lỗi
                    // _logger.LogError(ex, "Error occurred while creating user.");
                    return View(model);
                }

                return RedirectToAction("Login", "Account");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                var hashedPassword = HashPassword(model.Password);
                var users = _context.Users.SingleOrDefault(c => c.Username == model.Username);

                if (users == null)
                {
                    ModelState.AddModelError("", "User does not exist.");
                }
                else
                {
                    if (!users.IsActive)
                    {
                        ModelState.AddModelError("", "Account is locked. Please contact admin.");
                    }
                    else
                    {
                        if (users.Password != hashedPassword)
                        {
                            ModelState.AddModelError("", "Incorrect password.");
                        }
                        else
                        {
                            // Lấy tên vai trò từ cơ sở dữ liệu dựa trên RoleId
                            var roleName = _context.Roles
                                            .Where(r => r.RoleId == users.RoleId)
                                            .Select(r => r.RoleName)
                                            .SingleOrDefault();

                            if (string.IsNullOrEmpty(roleName))
                            {
                                // Xử lý nếu RoleId không hợp lệ hoặc không tìm thấy
                                roleName = "Unknown";
                            }

                            var claims = new List<Claim> {
                        new Claim(ClaimTypes.Email, users.Email),
                        new Claim(ClaimTypes.Name, users.Fullname),
                        new Claim(MySetting.CLAIM_USERID, users.UserId.ToString()),
                        new Claim(ClaimTypes.Role, roleName) // Gán tên vai trò thay vì RoleId
                    };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                            await HttpContext.SignInAsync(claimsPrincipal);

                            if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
                            {
                                return Redirect(returnUrl);
                            }
                            else
                            {
                                return Redirect("/");
                            }
                        }
                    }
                }
            }

            // Nếu ModelState không hợp lệ hoặc đăng nhập thất bại, trả về trang đăng nhập
            return View();
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
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Fullname,Username,Password,Gender,DateOfBirth,Address,Phone,Email,RoleId")] EidtUser model )
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

                    // Cập nhật các thông tin từ model
                    user.Fullname = model.Fullname;
                    user.Username = model.Username;
                    user.Gender = model.Gender;
                    user.DateOfBirth = model.DateOfBirth;
                    user.Address = model.Address;
                    user.Phone = model.Phone;
                    user.Email = model.Email;

                    // Nếu mật khẩu mới được cung cấp, cập nhật lại mật khẩu
                    if (!string.IsNullOrEmpty(model.Password))
                    {   

                        user.Password = HashPassword(model.Password);  // Re-hash new password
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

            // Nếu có lỗi, hiển thị lại form chỉnh sửa với dữ liệu hiện tại
            ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName", model.RoleId);
            return View(model);
        }


        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login", "Account");
        }

        public IActionResult NotRole()
        {
            return View();
        }


        // Hàm để hash mật khẩu
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
