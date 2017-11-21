using System;
using System.Collections.Generic;
using System.Linq;
using Autoconnect.Data.Infrastructure;
using LC_02.Data.Entities;
using LC_02.Data.Infrastructure;


namespace LC_02.Services.Events
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> eventRepository;
        private readonly IUnitOfWork unitOfWork;

        public EventService(IRepository<Event> eventRepository, IUnitOfWork unitOfWork)
        {
            this.eventRepository = eventRepository;
            this.unitOfWork = unitOfWork;
        }
        private EventDto ConvertEventFromEventToDto(Event eventEntity)
        {
            //logic for EventDto
            var eventDto = new EventDto();
            eventDto.EventId = eventEntity.EventId;
            eventDto.EventCategoryName = (EventCategoryType) eventEntity.EventCategoryName;
            eventDto.EventType = (EventType) eventEntity.EventType;
            if (eventEntity.StartEventDate != null) eventDto.StartEventDate = (DateTime)eventEntity.StartEventDate;
            if (eventEntity.EndEventDate != null) eventDto.EndEventDate = (DateTime)eventEntity.EndEventDate;
            eventDto.PhoneNumber = eventEntity.PhoneNumber;
            eventDto.Address = eventEntity.Address;
            eventDto.CreatedDate = eventEntity.CreatedDate;
            eventDto.Description = eventEntity.Description;
            eventDto.ImagePath = eventEntity.ImagePath;
            eventDto.UserId = eventEntity.UserId;
            if (eventEntity.Rank != null) eventDto.Rank = (float)eventEntity.Rank;
            eventDto.Title = eventEntity.Title;

            return eventDto;
        }

        public Event ConvertEventFromDtoToEntity(EventDto eventDto)
        {
            var eventEntity = new Event();
            eventEntity.EventId = eventEntity.EventId;
            eventEntity.EventCategoryName =  (int) eventDto.EventCategoryName;
            eventEntity.EventType =  (int) eventDto.EventType;
            eventEntity.StartEventDate = eventDto.StartEventDate;
            eventEntity.EndEventDate = eventDto.EndEventDate;
            eventEntity.PhoneNumber = eventDto.PhoneNumber;
            eventEntity.Address = eventDto.Address;
            eventEntity.CreatedDate = eventDto.CreatedDate;
            eventEntity.Description = eventDto.Description;
            eventEntity.ImagePath = eventDto.ImagePath;
            eventEntity.UserId = eventDto.UserId;
            eventEntity.Rank = eventDto.Rank;
            eventEntity.Title = eventDto.Title;

            return eventEntity;
        }
        public EventDto AddNewEvent(EventDto eventDto)
        {
            var eventEntity = ConvertEventFromDtoToEntity(eventDto);
            eventEntity.EventType=(int) EventType.Event;
            eventEntity.CreatedDate=DateTime.Now;
            eventRepository.Add(eventEntity);
            unitOfWork.Commit();
            return ConvertEventFromEventToDto(eventEntity);
        }

        public List<EventDto> GetEventsByUserId(int userId)
        {
            var listEvents = eventRepository.Query(x => x.UserId == userId).ToList();
            if (listEvents.Count == 0) return null;

            var listEventsDto = new List<EventDto>();
            foreach (var eventEntity in listEvents)
            {
                listEventsDto.Add(ConvertEventFromEventToDto(eventEntity));
            }
            return listEventsDto;
        }
    }
}