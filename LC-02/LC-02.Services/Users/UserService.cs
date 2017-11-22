using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Autoconnect.Data.Infrastructure;
using LC_02.Data.Entities;
using LC_02.Data.Infrastructure;
using LC_02.Services.Events;
using LC_02.Services.Project;

namespace LC_02.Services.Users
{


    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        private EventDto ConvertEventFromEntityToDto(Event eventEntity)
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
        private UserDto ConvertUserFromEntityToDto(User user)
        {
            var userDto = new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType,
            };
            userDto.Events = new List<EventDto>();
            if (user.Events != null)
            {
                foreach (var eventEntity in user.Events)
                {
                    userDto.Events.Add(ConvertEventFromEntityToDto(eventEntity));
                }
            }
            return userDto;
        }

        private User ConvertUserFromDtoToEntity(UserDto userDto)
        {
            var userEntity = new User
            {
                UserId = userDto.UserId,
                Username = userDto.Username,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                UserType = userDto.UserType,
            };
            return userEntity;
        }
        public UserDto AddNewUser(UserDto userDto)
        {
            var user = ConvertUserFromDtoToEntity(userDto);
            var md5Hash = MD5.Create();
            user.Password = GetMd5Hash(md5Hash, userDto.Password);
            userRepository.Add(user);

            unitOfWork.Commit();

            return ConvertUserFromEntityToDto(user);
        }
        public UserDto LoginStudent(string username, string password)
        {
            MD5 md5Hash = MD5.Create();

            var user = userRepository.Query().FirstOrDefault(x => x.Username == username);
            if (user == null) return null;

            var passwordMatch = VerifyMd5Hash(md5Hash, password, user.Password);
            if (!passwordMatch) return null;

            return ConvertUserFromEntityToDto(user);

        }

        public UserDto GetUserByUserName(string username)
        {
            var user = userRepository.Query().FirstOrDefault(x => x.Username == username);
            if (user == null) return null;
            return ConvertUserFromEntityToDto(user);
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            var comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }
    }
}
