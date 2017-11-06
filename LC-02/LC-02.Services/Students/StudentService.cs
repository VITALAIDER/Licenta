using System.Runtime.InteropServices.ComTypes;
using Autoconnect.Data.Infrastructure;
using LC_02.Data.Entities;
using LC_02.Data.Infrastructure;

namespace LC_02.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> studentRepository;
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IRepository<Student> studentRepository, IUnitOfWork unitOfWork)
        {
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool AddNewStudent(StudentDto studentDto)
        {
            var student = new Student
            {
                Email = studentDto.Email,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                PhoneNumber = studentDto.PhoneNumber,
                ProfessorId = studentDto.ProfessorId,
                Title = studentDto.Title
            };
            foreach (var projectDto in studentDto.Projects)
            {
                var project = new Data.Entities.Project
                {
                    Title = projectDto.Title,
                    Description = projectDto.Description,
                    StartDate = projectDto.StartDate,
                    Student = student
                };
                student.Projects.Add(project);  
            }
            studentRepository.Add(student);
            unitOfWork.Commit();
            return true;
        }
    }
}