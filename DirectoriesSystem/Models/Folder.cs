using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectoriesSystem.Models
{       
    
    public class Folder
    {       
        //[Key]
        public int id { get; set; }

        public string Name { get; set; }

        public int? ParentId { get; set; }
        public string Other { get; set; }
        [ForeignKey("ParentId")]
        public virtual Folder Parent { get; set; }
        
        //public string Path { get; set; }
        public virtual ICollection<Folder> Children { get; set; }

    }
}