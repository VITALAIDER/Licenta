using System.Data.Entity;
using System.Runtime.InteropServices.ComTypes;

namespace LC_02.Data.Entities
{
    public class ProjectContext : DbContext
    {
        public ProjectContext()
            : base("LC_02.Models.ProjectContext")
        {
            Database.SetInitializer<ProjectContext>(null);
        }
        public DbSet<Data.Entities.Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}