using LC_02.Services.Project;

namespace LC_02.Services.Users
{
    public interface IUserService
    {
        UserDto AddNewUser(UserDto userDto);
        UserDto LoginStudent(string username, string password);
        UserDto GetUserByUserName(string username);
        UserDto GetUserById(int userId);
    }
}
