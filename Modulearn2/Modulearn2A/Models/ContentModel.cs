using System;
using System.ComponentModel.DataAnnotations.Schema;

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

}
