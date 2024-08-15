using System;
using System.Collections.Generic;

namespace User_Management.Data;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? ProfileImage { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsActive { get; set; }

    public Role Role { get; set; }
   
}
public partial class EidtUser
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Fullname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public IFormFile? ProfileImage { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool? IsActive { get; set; }


}

