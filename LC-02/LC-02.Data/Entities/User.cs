using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        //for organizer
        public float? Rank { get; set; }
        public List<Event> Events { get; set; }
    }
}