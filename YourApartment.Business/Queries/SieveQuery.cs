using System;
using System.Collections.Generic;
using System.Text;
using EnsureThat;
using Sieve.Models;

namespace YourApartment.Business
{
    public sealed class SieveQuery
    {
        public SieveQuery(SieveModel model)
        {
            EnsureArg.IsNotNull(model);
            Model = model;
        }

        public SieveModel Model { get; set; }  
    }
}
