using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modulearn2A.Models
{
    public class ContentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Markdown { get; set; }
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }
        public int PosterID { get; set; }
    }

    public class AdminModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int UserID { get; set; }
    }
}
