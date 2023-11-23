using Magic_Villa_Web.Models.DTO;
using System.Linq.Expressions;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaNumberServices
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetAsync<T>(int id);
        
        Task<T> CreateAsync<T>(VillaNumberCreatedDto entity);
        
        Task<T> UpdateAsync<T>(VillaNumberUpdatedDto entity);
        
        Task<T> RemoveAsync<T>(int id);
    }
}
