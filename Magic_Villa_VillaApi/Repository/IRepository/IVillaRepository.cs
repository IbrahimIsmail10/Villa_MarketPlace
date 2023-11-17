using Magic_Villa_VillaApi.Models;


namespace Magic_Villa_VillaApi.Repository.IRepository
{
    public interface IVillaRepository : IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
