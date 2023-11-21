using Magic_Villa_Web.Models.DTO;
using System.Linq.Expressions;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaServices
    {
        Task<T> GetAllAsync<T>();

        Task<T> GetAsync<T>(int id);
        
        Task<T> CreateAsync<T>(VillaCreatedDto entity);
        
        Task<T> UpdateAsync<T>(VillaUpdatedDto entity);
        
        Task<T> RemoveAsync<T>(int id);
    }
}
