using LC_02.Services.Project;

namespace LC_02.Services.Users
{
    public interface IUserService
    {
        UserDto AddNewUser(UserDto userDto);
    }
}
