using Magic_Villa_Web.Models.DTO;
using System.Linq.Expressions;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaNumberServices
    {
        Task<T> GetAllAsync<T>(string token);

        Task<T> GetAsync<T>(int id, string token);
        
        Task<T> CreateAsync<T>(VillaNumberCreatedDto entity, string token);
        
        Task<T> UpdateAsync<T>(VillaNumberUpdatedDto entity, string token);
        
        Task<T> RemoveAsync<T>(int id, string token);
    }
}
