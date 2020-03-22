using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace YourApartment.Persistence.EntityFramework
{
    public static class PersistenceAssembly
    {
        public static Assembly Value => typeof(PersistenceAssembly).Assembly;
    }
}
