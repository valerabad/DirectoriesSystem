using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DirectoriesSystem.Models
{
    public class FolderContext : DbContext
    {
        public DbSet<Folder> Folder { get; set; }
       
    }

    public class FoldersDbInitializer : DropCreateDatabaseAlways<FolderContext>
    {
        // 
        protected override void Seed(FolderContext db)
        {           
            Folder rootFolder = new Folder()
            {
                ParentId = null,
                Name = "Creating Digital Image",
                Path = "Creating Digital Image"               
            };

            Folder f = db.Folder.Add(rootFolder);
            int t = db.SaveChanges();           

            List<Folder> subFoldersLevel1 = new List<Folder>()
            {
                new Folder() { ParentId =  f.ID, Name = "Resources", Path = "Creating Digital Image/Resources"},
                new Folder() { ParentId =  f.ID, Name = "Evidence", Path = "Creating Digital Image/Evidence"},
                new Folder() { ParentId =  f.ID, Name = "GraphicProducts", Path = "Creating Digital Image/GraphicProducts"}               

            };

            foreach (Folder fol in subFoldersLevel1)
            {
               db.Folder.Add(fol);
            }
            db.SaveChanges();


            List<Folder> subFoldersLevel2 = new List<Folder>()
            {
                new Folder()
                {
                    ParentId = db.Folder.FirstOrDefault(m => m.Name == "Resources").ID,
                    Name = "Primary Sources",
                    Path = "Creating Digital Image/Resources/Primary Sources"
                },
                new Folder()
                {
                    ParentId = db.Folder.FirstOrDefault(m => m.Name == "Resources").ID,
                    Name = "Secondaty Sources",
                    Path = "Creating Digital Image/Resources/Secondary Sources"
                },
                new Folder()
                {
                    ParentId = db.Folder.FirstOrDefault(m => m.Name == "GraphicProducts").ID,
                    Name = "Process",
                    Path = "Creating Digital Image/GraphicProducts/Process"
                },
                new Folder()
                {
                    ParentId = db.Folder.FirstOrDefault(m => m.Name == "GraphicProducts").ID,
                    Name = "Final Product",
                    Path = "Creating Digital Image/GraphicProducts/Final Product"
                }
            };

            foreach (Folder fol in subFoldersLevel2)
            {
                db.Folder.Add(fol);
            }

            db.SaveChanges();

            base.Seed(db);
        }
    }
}