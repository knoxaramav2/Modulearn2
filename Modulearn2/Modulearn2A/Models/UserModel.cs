using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modulearn2A.Models
{
    public class ConfirmUserModel
    {
        [Required(ErrorMessage = "Required field.")]
        [EmailAddress(ErrorMessage = "Invalid address.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Required field.")]
        [EmailAddress()]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Required field.")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Required field.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Required field.")]
        public string Password { get; set; }
    }

    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        //[Required(ErrorMessage = "Required field.")]
        public string Email { get; set; }
        
        public string UserName { get; set; }
        
        public string PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public DateTime RegistrationDate { get; set; }

        //Restrict to 256x256 JPG
        public byte [] AccountImage { get; set; }
    }

    public class AdminModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserID { get; set; }
    }
}

