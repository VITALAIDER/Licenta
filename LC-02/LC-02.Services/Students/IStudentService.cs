using LC_02.Data.Entities;

namespace LC_02.Services.Students
{
    public interface IStudentService
    {
        bool AddNewStudent(StudentDto studentDto);
    }
}