using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LC_02.Services.Students;

namespace LC_02.Services.Project
{
    public class ProjectDto
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public virtual StudentDto Student { get; set; }
        public int StudentId { get; set; }
    }
}
