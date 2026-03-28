using AutoMapper;
using PracticeApi.Models;

namespace PracticeApi.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserReadDto>();
        }
    }
}
