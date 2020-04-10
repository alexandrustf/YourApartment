using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using YourApartment.Persistence.EntityFramework;

namespace YourApartment.Tests.Common.Stubs
{
    public static class ContextFactory
    {
        public static YourApartmentContext BuildContext()
        {
            return new YourApartmentContext(new DbContextOptionsBuilder().UseInMemoryDatabase($"YourApartmentContext.{Guid.NewGuid()}").Options);
        }
    }
}
