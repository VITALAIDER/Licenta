using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LC_02.Data.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int EventType { get; set; }
        public int EventCategoryName { get; set; }
        public int PlaceCategoryName { get; set; }
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