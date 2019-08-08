using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DirectoriesSystem.Models
{       
    public class Folder
    {              
        public int id { get; set; }
        //public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
        public string Path { get; set; }
        public virtual List<Folder> Children { get; set; }

    }
}