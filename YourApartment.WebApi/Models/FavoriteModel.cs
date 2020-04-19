using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YourApartment.WebApi.Models
{
    public class FavoriteModel
    {
        public Guid IdApartment { get; set; }

        public bool Favorite { get; set; }
    }
}
