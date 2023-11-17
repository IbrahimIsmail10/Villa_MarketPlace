using System.Linq.Expressions;

namespace Magic_Villa_VillaApi.Repository.IRepository
{
    public interface IRepository<T> where T : class 
    {
        public Task<List<T>> GetAllAsync(Expression<Func<T,bool>>? Fillter = null);
        public Task<T> GetAsync(Expression<Func<T, bool>>? Fillter = null,bool tracking = true);
        public Task CreateAsync(T entity);
        public Task RemoveAsync(T entity);
        public Task SaveAsync();
    }
}
