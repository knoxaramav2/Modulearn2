using System.ComponentModel.DataAnnotations.Schema;

namespace Modulearn2A.Models
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
    }
}

