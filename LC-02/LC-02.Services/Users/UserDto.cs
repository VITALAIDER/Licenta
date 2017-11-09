using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LC_02.Data.Entities;
using LC_02.Services.Events;

namespace LC_02.Services.Project
{
    //public enum UserType
    //{
    //    Simple = 0,
    //    Organizer
    //}
    public class UserDto
    {
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        //for organizer
        public float Rank { get; set; }
        public List<EventDto> Events { get; set; }
    }
}
