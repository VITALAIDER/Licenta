using System.Collections.Generic;

namespace LC_02.Services.Events
{
    public interface IEventService
    {
        EventDto AddNewEvent(EventDto eventDto);
        List<EventDto> GetEventsByUserId(int userId);
        EventDto GetEventById(int eventId);
        EventDto UpdateEvent(EventDto eventDto);
        void DeleteEvent(int eventId);
        List<EventDto> GetEventsByEventCategory(int eventCategory);
        List<EventDto> GetPlacesByPlaceCategory(int placeCategory);
    }
}