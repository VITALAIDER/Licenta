using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LC_02.Services.Students;

namespace LC_02.Services.Professor
{
    public class ProfessorDto
    {
        public int ProfessorId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public virtual List<StudentDto> Students { get; set; }
        public string PhoneNumber { get; set; }
    }
}
