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
        protected override void Seed(FolderContext db)
        {
            List<Folder> child_folds_3 = new List<Folder>();
            child_folds_3.Add(new Folder { Name = "Process", Path= "Creating Digital Image/GraphicProducts/Process" });
            child_folds_3.Add(new Folder { Name = "Final Product", Path = "Creating Digital Image/GraphicProducts/Final Products" });

            List<Folder> child_folds_2 = new List<Folder>();
            child_folds_2.Add(new Folder { Name = "Primary Sources", Path = "Creating Digital Image/Resources/Primary Sources" }); //, Children = child_folds_3 
            child_folds_2.Add(new Folder { Name = "Secondary Sources", Path = "Creating Digital Image/Resources/Secondary Sources" });

            List<Folder> child_folds_1 = new List<Folder>();
            child_folds_1.Add(new Folder {   Name = "Resources", Path = "Creating Digital Image/Resources", Children = child_folds_2 });
            child_folds_1.Add(new Folder {   Name = "Evidence", Path = "Creating Digital Image/Evidence" });
            child_folds_1.Add(new Folder {   Name = "GraphicProducts", Path= "Creating Digital Image/GraphicProducts", Children = child_folds_3 });

            Folder rootFolder = new Folder() {
                Name = "Creating Digital Image",
                Path = "Creating Digital Image",
                Children = child_folds_1 };                                                   


            db.Folder.Add(rootFolder);

            base.Seed(db);
        }
    }
}