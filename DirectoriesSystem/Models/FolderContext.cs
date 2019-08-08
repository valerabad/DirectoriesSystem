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
            // Initializing for testing
            // child folders on the 3rd level
            List<Folder> childFolds3 = new List<Folder>();
            childFolds3.Add(new Folder { Name = "Process", Path= "Creating Digital Image/GraphicProducts/Process" });
            childFolds3.Add(new Folder { Name = "Final Product", Path = "Creating Digital Image/GraphicProducts/Final Products" });

            // child folders on the 2rd level
            List<Folder> childFolds2 = new List<Folder>();
            childFolds2.Add(new Folder { Name = "Primary Sources", Path = "Creating Digital Image/Resources/Primary Sources" });
            childFolds2.Add(new Folder { Name = "Secondary Sources", Path = "Creating Digital Image/Resources/Secondary Sources" });

            // child folders on the 1rd level
            List<Folder> childFolds1 = new List<Folder>();
            childFolds1.Add(new Folder {   Name = "Resources", Path = "Creating Digital Image/Resources", Children = childFolds2 });
            childFolds1.Add(new Folder {   Name = "Evidence", Path = "Creating Digital Image/Evidence" });
            childFolds1.Add(new Folder {   Name = "GraphicProducts", Path= "Creating Digital Image/GraphicProducts", Children = childFolds3 });

            Folder rootFolder = new Folder() {
                Name = "Creating Digital Image",
                Path = "Creating Digital Image",
                Children = childFolds1 };                                                   


            db.Folder.Add(rootFolder);

            base.Seed(db);
        }
    }
}