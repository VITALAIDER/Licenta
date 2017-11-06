using System.Collections.Generic;

namespace LC_02.Data.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public List<Project> Projects { get; set; }
        public int ProfessorId { get; set; }
        public string PhoneNumber { get; set; }
    }
}