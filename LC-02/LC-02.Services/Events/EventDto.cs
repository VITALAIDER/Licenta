using System;
using System.Collections.Generic;
using LC_02.Services.Comment;

namespace LC_02.Services.Events
{
    public enum EventType
    {
        Nespecificat = 0,
        Event,
        Place
    }
    public enum EventCategoryType
    {
        Nespecificat = 0,
        Diverse,
        Concert,
        Teatru,
        Caritate,
        Targ,
        Expozitie,
        Show,
        Divertisment
    }
    public enum PlaceCategoryType
    {
        Nespecificat = 0,
        Diverse,
        Restaurant,
        Pizzerie,
        Club,
        Bar,
        Pub,
        Cazino,
        Beauty,
        InstitutieDeInvatamant,
        Muzeu

    }
    public class EventDto
    {
        public int EventId { get; set; }
        public EventType EventType { get; set; }
        public EventCategoryType EventCategoryName { get; set; }
        public PlaceCategoryType PlaceCategoryName { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public float Rank { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime StartEventDate { get; set; }
        public DateTime EndEventDate { get; set; }
        public List<CommentDto> Comments { get; set; }
    }

}
