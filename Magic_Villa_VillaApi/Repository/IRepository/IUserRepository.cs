using Magic_Villa_VillaApi.Models;
using Magic_Villa_VillaApi.Models.UserDTO;

namespace Magic_Villa_VillaApi.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string userName);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<Users> Register(RegistrationRequestDto registrationRequestDto);

    }
}
