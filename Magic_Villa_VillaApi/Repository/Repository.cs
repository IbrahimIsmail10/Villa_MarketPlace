using Magic_Villa_VillaApi.Data;
using Magic_Villa_VillaApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Magic_Villa_VillaApi.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbset;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbset = db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbset.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? Fillter = null)
        {
            IQueryable<T> query = dbset;
            if (Fillter != null)
            {
                query = query.Where(Fillter);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>>? Fillter = null, bool tracking = true)
        {
            IQueryable<T> query = dbset;
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            if (Fillter != null)
            {
                query = query.Where(Fillter);
            }

            return await query.FirstOrDefaultAsync();
        }
    

        public async Task RemoveAsync(T entity)
        {
            dbset.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
           await _db.SaveChangesAsync();
        }
    }
}
