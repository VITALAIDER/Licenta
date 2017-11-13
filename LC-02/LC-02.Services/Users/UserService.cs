using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Autoconnect.Data.Infrastructure;
using LC_02.Data.Entities;
using LC_02.Data.Infrastructure;
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
        public UserDto AddNewUser(UserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email
            };
            var md5Hash = MD5.Create();
            user.Password = GetMd5Hash(md5Hash, userDto.Password);
            user.PhoneNumber = userDto.PhoneNumber;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.UserType = userDto.UserType;
            userRepository.Add(user);
            unitOfWork.Commit();

            var addedUserDto = new UserDto
            {
                Username = user.Username,
                Email = user.Email,
                UserId = user.UserId,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType
            };

            return addedUserDto;
        }
        public UserDto LoginStudent(string username, string password)
        {
            MD5 md5Hash = MD5.Create();

            var user = userRepository.Query().FirstOrDefault(x => x.Username == username);
            if (user == null) return null;
            var passwordMatch = VerifyMd5Hash(md5Hash, password, user.Password);
            if (!passwordMatch) return null;
            return new UserDto()
            {
                Username = user.Username,
                Email = user.Email,
                UserId = user.UserId,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserType = user.UserType
            };
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

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            var comparer = StringComparer.OrdinalIgnoreCase;

            return 0 == comparer.Compare(hashOfInput, hash);
        }
        //
    }
}
