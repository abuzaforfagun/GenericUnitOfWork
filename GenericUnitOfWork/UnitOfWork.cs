using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GenericUnitOfWork
{
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {
        protected readonly DbContext _dbContext;
        protected readonly IServiceProvider _serviceProvider;

        public UnitOfWork(DbContext context, IServiceProvider serviceProvider)
        {
            _dbContext = context;
            _serviceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; }

        public IEntityRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var repositoryType = typeof(EntityRepository<TDbContext, TEntity>);
            return (IEntityRepository<TEntity>)_serviceProvider.GetService(repositoryType);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
