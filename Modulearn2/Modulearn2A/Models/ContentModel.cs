using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Modulearn2A.Models
{
    public class ContentJointModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ContentModelID { get; set; }
        public int ContentMetaModelID { get; set; }    
}

    public class ContentMetaModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DatePosted { get; set; }
        public int UserModelID { get; set; }
    }

    public class ContentModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Markdown { get; set; }
    }
}
