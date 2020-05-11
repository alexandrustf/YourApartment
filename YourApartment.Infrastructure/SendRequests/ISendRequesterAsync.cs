using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace YourApartment.Infrastructure.SendRequests
{
    public interface ISendRequesterAsync
    {
        public Task<JObject> GetAsync(string uri);
    }
}
