using Microsoft.EntityFrameworkCore;
using Net6.Lab.GenId.Data;

namespace Net6.Lab.GenId
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public class Repository<TEntity> where TEntity : class, IEntity<Guid>
    {
        protected readonly Net6LabGenIdContext _dbContext;
        protected readonly DbSet<TEntity> _dbEntitySet;

        public Repository(Net6LabGenIdContext dbContext)
        {
            _dbContext = dbContext;
            _dbEntitySet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Guid Id, params string[] includes)
        {
            var query = _dbEntitySet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            var result =await query.SingleOrDefaultAsync(c => c.Id == Id);
            return result;
        }

        public async Task<bool> Exist(Guid Id)
        {
            var result = await _dbEntitySet.AnyAsync(c => c.Id == Id);
            return result;
        }

        /// <summary>
        /// Gets all the entities
        /// </summary>
        /// <param name="includes">Option includes for eager loading</param>
        /// <returns></returns>
        public IQueryable<TEntity> List(params string[] includes)
        {
            var query = _dbEntitySet.AsQueryable();
            foreach (var include in includes)
                query = query.Include(include);
            return query;
        }

        /// <summary>
        ///     Creates an entity
        /// </summary>
        /// <param name="model"></param>
        public void Create(TEntity model) => _dbEntitySet.Add(model);

        /// <summary>
        ///     Updates an entity
        /// </summary>
        /// <param name="model"></param>
        public void Update(TEntity model) => _dbEntitySet.Update(model);

        /// <summary>
        /// Removes an entity
        /// </summary>
        /// <param name="model"></param>
        public void Remove(TEntity model) => _dbContext.Entry<TEntity>(model).State = EntityState.Deleted;

        /// <summary>
        /// Saves the database context changes
        /// </summary>
        /// <returns></returns>
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
