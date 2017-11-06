using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LC_02.Services.Project;

namespace LC_02.Services.Students
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public List<ProjectDto> Projects { get; set; }
        public int ProfessorId { get; set; }
        public string PhoneNumber { get; set; }
    }

}
