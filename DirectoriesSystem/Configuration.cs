using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using DirectoriesSystem.Models;

namespace DirectoriesSystem
{
    internal sealed class Configuration : DbMigrationsConfiguration<FolderContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        //Creating an object from our  context class to make the DB operations using EF  


        protected override void Seed(FolderContext context)
        {
            context.Folder.AddOrUpdate(c => c.Name,
                new Folder { id = 1, Name = "root", ParentId = null },
                new Folder { id = 2, Name = "sub1", ParentId = 1 },
                new Folder { id = 3, Name = "sub2", ParentId = 1 },
                new Folder { id = 4, Name = "sub3", ParentId = 1 },
                new Folder { id = 5, Name = "sub1sub", ParentId = 2 },
                new Folder { id = 7, Name = "sub1sub", ParentId = 2 });
        }
    }
}