using System.Threading.Tasks;

namespace GenericUnitOfWork
{
    public interface IUnitOfWork
    {
        IEntityRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
