using System.Threading.Tasks;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework
{
    internal sealed class WriteRepository<T> : IWriteRepository<T>
        where T : Entity
    {
        private readonly YourApartmentContext context;
        
        public WriteRepository(YourApartmentContext context)
        {
            this.context = context;
        }

        public Task Create(T entity)
        {
            context.Set<T>().Add(entity);
            return Task.CompletedTask;
        }

        public Task Commit()
        {
            return context.SaveChangesAsync();
        }
    }
}
