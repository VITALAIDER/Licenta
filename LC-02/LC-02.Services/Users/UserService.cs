using System;
using System.Collections.Generic;
using System.Linq;
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
            var user = new User();
            user.Username = userDto.Username;
            user.Email = userDto.Email;

            user.PhoneNumber = userDto.PhoneNumber;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.UserType = userDto.UserType;
            userRepository.Add(user);
            unitOfWork.Commit();
            var addedUserDto=new UserDto();
            addedUserDto.Username = user.Username;
            addedUserDto.Email = user.Email;

            addedUserDto.UserId = user.UserId;
            addedUserDto.PhoneNumber = user.PhoneNumber;
            addedUserDto.FirstName = user.FirstName;
            addedUserDto.LastName = user.LastName;
            addedUserDto.UserType = user.UserType;
            return addedUserDto;
        }
    }
}
