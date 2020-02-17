using CSharpFunctionalExtensions;
using EnsureThat;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using YourApartment.Common;
using YourApartment.Domain;

namespace YourApartment.Persistence.EntityFramework
{
    internal class ReadRepository<T> : IReadRepository<T>
        where T : Entity
    {
        private readonly YourApartmentContext context;
        
        private readonly IQueryable<T> entitiesSet;

        public ReadRepository()
        {}
        protected ReadRepository(YourApartmentContext context)
        {
            EnsureArg.IsNotNull(context);
            this.context = context;
            entitiesSet = DecorateEntities(context.Set<T>().AsQueryable());
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await entitiesSet.Where(expression).ToListAsync();
        }

        public async Task<Maybe<T>> FindOne(Expression<Func<T, bool>> expression)
        {
            return await entitiesSet.FirstOrDefaultAsync(expression).ToMaybe();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entitiesSet.ToListAsync();
        }

        public Task<Maybe<T>> GetById(Guid id)
        {
            return entitiesSet.FirstOrDefaultAsync(e => e.Id == id).ToMaybe();
        }

        protected virtual IQueryable<T> DecorateEntities(IQueryable<T> entities) => entities;
    }
}
