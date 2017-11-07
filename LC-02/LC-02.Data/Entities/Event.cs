using System;
using System.Collections.Generic;

namespace LC_02.Data.Entities
{
    public enum EventType
    {
        Event = 0,
        Place
    }
    public enum EventCategoryType
    {
        Diverse=0,
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
        Restaurant = 0,
        Pizzerie,
        Club,
        Bar,
        Pub,
        Cazino,
        Beauty,
        InstitutieDeInvatamant,
        Muzeu,
        Diverse
    }
    public class Event
    {
        public int EventId { get; set; }
        public EventType EventType { get; set; }
        public PlaceCategoryType EventCategoryName { get; set; }
        public string PlaceCategoryName { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public float Rank { get; set; }
        public int OrganizerId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime StartEventDate { get; set; }
        public DateTime EndEventDate { get; set; }
        public List<Comment> Comments { get; set; }
    }
}