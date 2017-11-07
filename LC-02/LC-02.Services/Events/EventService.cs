using Autoconnect.Data.Infrastructure;
using LC_02.Data.Entities;
using LC_02.Data.Infrastructure;

namespace LC_02.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> studentRepository;
        private readonly IUnitOfWork unitOfWork;

        public EventService(IRepository<Event> studentRepository, IUnitOfWork unitOfWork)
        {
            this.studentRepository = studentRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool AddNewEvent(EventDto eventDto)
        {
            //var student = new Event
            //{
            //    Address = studentDto.Address,
            //    FirstName = studentDto.FirstName,
            //    LastName = studentDto.LastName,
            //    PhoneNumber = studentDto.PhoneNumber,
            //    ProfessorId = studentDto.ProfessorId,
            //    Title = studentDto.Title
            //};
            //foreach (var projectDto in studentDto.Projects)
            //{
            //    var project = new Data.Entities.History
            //    {
            //        Title = projectDto.Title,
            //        Description = projectDto.Description,
            //        StartDate = projectDto.StartDate,
            //        Student = student
            //    };
            //    student.Projects.Add(project);  
            //}
            //studentRepository.Add(student);
            unitOfWork.Commit();
            return true;
        }
    }
}