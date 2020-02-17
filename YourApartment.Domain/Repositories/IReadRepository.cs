using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YourApartment.Domain
{
    public interface IReadRepository<T>
        where T : Entity
    {
        Task<Maybe<T>> FindOne(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAll();

        Task<Maybe<T>> GetById(Guid id);
    }
}
