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
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}