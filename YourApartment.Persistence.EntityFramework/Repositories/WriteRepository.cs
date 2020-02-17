using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework
{
    internal sealed class WriteRepository<T> : IWriteRepository<T>
        where T : Entity
    {
        private readonly YourApartmentContext context;
        public WriteRepository()
        {}
        public WriteRepository(YourApartmentContext context)
        {
            this.context = context;
        }

        public async Task Create(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
    }
}
