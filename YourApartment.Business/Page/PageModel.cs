using System;
using System.Collections.Generic;
using System.Text;

namespace YourApartment.Business
{
    public sealed class PageModel<T>
    {
        public int TotalNumberOfRecords { get; set; }

        public IEnumerable<T> Records { get; set; }
    }
}
