using AB_testing.Data;
using AB_testing.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AB_testing.Repos
{
    public class GenericRepo<T>(AppDbContext dbContext, ILogger logger) : IGenericRepo<T> where T : class
    {
        //repository with generic functionality 
        //sets nessessory dependency injection for children implementation 

        protected AppDbContext dbContext = dbContext;

        public readonly ILogger logger = logger;

        internal DbSet<T> dbSet = dbContext.Set<T>();

        public virtual async Task<IEnumerable<T>?> GetAllAsync()
        {
            try
            {
                return await dbSet.ToListAsync();

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"AchivmentRepo GetAll,{typeof(GenericRepo<T>)}");
                throw;
            }
        }

        public virtual async Task<T?> GetSingleAsync(Guid Id)
        {
            var entity =await dbSet.FindAsync(Id);
            return entity;
        }

        public virtual async Task<bool> CreateAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $" Error Occurs in GenericRepo while processing  Create method of {typeof(GenericRepo<T>)} entity");
                return false;
            }
        }

        public virtual Task<bool> UpDateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> RemoveAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
