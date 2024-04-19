using Microsoft.EntityFrameworkCore;

namespace HBApi.Persistance
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private DbSet<T> DBSet => dbContext.Set<T>();

        public async Task<T> Update(T model)
        {
            dbContext.Entry(model).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<T> GetById(int id)
        {
            var result = await DBSet.FindAsync(id);

            if (result is null)
            {
                throw new Exception("NotFound!...");
            }

            return result;
        }
    }
}