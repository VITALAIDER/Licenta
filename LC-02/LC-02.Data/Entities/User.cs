using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LC_02.Data.Entities
{
    public enum UserType
    {
        Simple=0,
        Organizer
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        //for organizer
        public float? Rank { get; set; }
        public List<Event> Events { get; set; }
    }
}