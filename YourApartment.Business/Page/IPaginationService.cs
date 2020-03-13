using System;
using System.Collections.Generic;
using System.Text;
using Sieve.Models;
using YourApartment.Domain;

namespace YourApartment.Business
{
    public interface IPaginationService<TEntity, TModel>
        where TEntity : Entity
    {
        PageModel<TModel> GetPage(SieveModel sieveModel);
    }
}
