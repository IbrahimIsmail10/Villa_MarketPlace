using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IAuthServices
    {
        Task<T> LoginAsync<T>(LoginRequestDto obj);
        Task<T> RegisterAsync<T>(RegistrationRequestDto obj);
    }
}
