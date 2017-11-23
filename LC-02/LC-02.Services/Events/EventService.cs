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
        private EventDto ConvertEventFromEntityToDto(Event eventEntity)
        {
            //logic for EventDto
            var eventDto = new EventDto();
            eventDto.EventId = eventEntity.EventId;
            eventDto.EventCategoryName = (EventCategoryType) eventEntity.EventCategoryName;
            eventDto.PlaceCategoryName = (PlaceCategoryType)eventEntity.PlaceCategoryName;
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

            eventEntity.EventId = eventDto.EventId;
            eventEntity.EventCategoryName =  (int) eventDto.EventCategoryName;
            eventEntity.PlaceCategoryName = (int) eventDto.PlaceCategoryName;
            eventEntity.EventType =  (int) eventDto.EventType;
            if(eventDto.StartEventDate==DateTime.MinValue) eventEntity.StartEventDate= DateTime.Now;
            else eventEntity.StartEventDate = eventDto.StartEventDate;
            if (eventDto.EndEventDate == DateTime.MinValue) eventEntity.EndEventDate = DateTime.Now;
            else eventEntity.EndEventDate = eventDto.EndEventDate;
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
            eventEntity.EventType=(int) eventDto.EventType;
            eventEntity.CreatedDate=DateTime.Now;
            eventRepository.Add(eventEntity);
            unitOfWork.Commit();
            return ConvertEventFromEntityToDto(eventEntity);
        }

        public List<EventDto> GetEventsByUserId(int userId)
        {
            var listEvents = eventRepository.Query(x => x.UserId == userId).ToList();
            if (listEvents.Count == 0) return null;

            var listEventsDto = new List<EventDto>();
            foreach (var eventEntity in listEvents)
            {
                listEventsDto.Add(ConvertEventFromEntityToDto(eventEntity));
            }
            return listEventsDto;
        }

        public EventDto GetEventById(int eventId)
        {
            return ConvertEventFromEntityToDto(eventRepository.Query(x => x.EventId == eventId).FirstOrDefault());
        }

        public EventDto UpdateEvent(EventDto eventDto)
        {
            var eventEntity = ConvertEventFromDtoToEntity(eventDto);
            var entity = eventRepository.Query(x => x.EventId == eventEntity.EventId).FirstOrDefault();
            if (entity == null) return null;

            if (entity.Title != eventEntity.Title) entity.Title = eventEntity.Title;
            if (entity.Address != eventEntity.Address) entity.Address = eventEntity.Address;
            if (entity.Description != eventEntity.Description) entity.Description = eventEntity.Description;
            if (entity.ImagePath != eventEntity.ImagePath && eventEntity.ImagePath!=null) entity.ImagePath = eventEntity.ImagePath;
            if (entity.PhoneNumber != eventEntity.PhoneNumber) entity.PhoneNumber = eventEntity.PhoneNumber;
            if (entity.PlaceCategoryName != eventEntity.PlaceCategoryName) entity.PlaceCategoryName = eventEntity.PlaceCategoryName;
            if (entity.EventCategoryName != eventEntity.EventCategoryName) entity.EventCategoryName = eventEntity.EventCategoryName;
            
            if (entity.EndEventDate != eventEntity.EndEventDate && eventEntity.EndEventDate!=DateTime.MinValue) entity.EndEventDate = eventEntity.EndEventDate;
            if (entity.StartEventDate != eventEntity.StartEventDate && eventEntity.StartEventDate != DateTime.MinValue) entity.StartEventDate = eventEntity.StartEventDate;
            
            eventRepository.Update(entity);
            unitOfWork.Commit();

            return ConvertEventFromEntityToDto(entity);
        }

        public void DeleteEvent(int eventId)
        {
            var eventEntity = eventRepository.Query(x => x.EventId == eventId).FirstOrDefault();
            eventRepository.Delete(eventEntity);
            unitOfWork.Commit();
        }

        public List<EventDto> GetEventsByEventCategory(int eventCategory)
        {
            
            var listOfEvents = eventRepository.Query(x => x.EventCategoryName == eventCategory);
            if (listOfEvents == null) return null;

            var listOfEventsDto = new List<EventDto>();
            foreach (var eventEntity in listOfEvents)
            {
                listOfEventsDto.Add(ConvertEventFromEntityToDto(eventEntity));
            }
            return listOfEventsDto;
        }
        public List<EventDto> GetPlacesByPlaceCategory(int placeCategory)
        {

            var listOfEvents = eventRepository.Query(x => x.PlaceCategoryName == placeCategory);
            if (listOfEvents == null) return null;

            var listOfEventsDto = new List<EventDto>();
            foreach (var eventEntity in listOfEvents)
            {
                listOfEventsDto.Add(ConvertEventFromEntityToDto(eventEntity));
            }
            return listOfEventsDto;
        }
    }
}