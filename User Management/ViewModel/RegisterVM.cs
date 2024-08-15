using System.ComponentModel.DataAnnotations;


namespace User_Management.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name must be a maximum of 100 characters.")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(255, ErrorMessage = "Email must be a maximum of 255 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, ErrorMessage = "Username must be a maximum of 100 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long and a maximum of 255 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        [StringLength(50, ErrorMessage = "Gender must be a maximum of 50 characters.")]
        public string Gender { get; set; }

        [StringLength(255, ErrorMessage = "Address must be a maximum of 255 characters.")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "Phone number must be a maximum of 50 characters.")]
        public string Phone { get; set; }
        [Required]
        public IFormFile ProfileImage { get; set; }
    }

}
