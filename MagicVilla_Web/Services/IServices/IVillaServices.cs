using Magic_Villa_Web.Models.DTO;
using System.Linq.Expressions;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaServices
    {
        Task<T> GetAllAsync<T>(string token);

        Task<T> GetAsync<T>(int id, string token);
        
        Task<T> CreateAsync<T>(VillaCreatedDto entity, string token);
        
        Task<T> UpdateAsync<T>(VillaUpdatedDto entity, string token);
        
        Task<T> RemoveAsync<T>(int id, string token);
    }
}
