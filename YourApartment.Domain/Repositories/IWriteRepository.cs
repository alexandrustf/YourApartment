using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace YourApartment.Domain
{
    public interface IWriteRepository<T>
        where T : Entity
    {
        Task Create(T entity);

        Task Delete(T entity);

        Task Commit();
    }
}
