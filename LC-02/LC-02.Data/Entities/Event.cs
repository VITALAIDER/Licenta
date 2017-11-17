using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        Charity,
        Concerts,
        Outside,
        Sport,
        Show,
    }
    public enum PlaceCategoryType
    {
        Restaurant = 0,
        Pizzerias,
        Club,
        Pub,
        Cazino,
        Beauty,
        EducationalInstitution,
        Museum,
        Diverse
    }
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public int UserId { get; set; }
        public EventType EventType { get; set; }
        public PlaceCategoryType EventCategoryName { get; set; }
        public PlaceCategoryType PlaceCategoryName { get; set; }
        public string Title { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public float? Rank { get; set; }
        

        public DateTime CreatedDate { get; set; }
        public DateTime? StartEventDate { get; set; }
        public DateTime? EndEventDate { get; set; }
        public List<Comment> Comments { get; set; }
    }
}