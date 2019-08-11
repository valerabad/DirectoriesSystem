using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DirectoriesSystem.Models
{       
    [Table("Folder")]
    public class Folder
    {
        [Key]
        public int ID { get; set; }
        public int? ParentId { get; set; }
        public String Name { get; set; }
        public String Other { get; set; }
        public String Path { get; set; }        
    }
}