using System;
using System.Collections.Generic;
using System.Text;
using Sieve.Services;

namespace YourApartment.Infrastructure
{
    interface ISieveEntityConfiguration
    {
        void Configure(SievePropertyMapper mapper);
    }
}
