using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace YourApartment.Infrastructure
{
    public static class InfrastructureAssembly
    {
        public static Assembly Value => typeof(InfrastructureAssembly).Assembly;
    }
}
