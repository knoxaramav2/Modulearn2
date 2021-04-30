using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modulearn2A.Models
{
    public class AdminAccounts
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID;
        public int AdminID;
    }
}
