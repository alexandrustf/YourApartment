using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YourApartment.Business;
using YourApartment.Infrastructure.SendRequests;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace YourApartment.Infrastructure
{
    public sealed class MapRoute : IMapRoute
    {
        private readonly ISendRequesterAsync sendRequester;

        public MapRoute(ISendRequesterAsync sendRequester)
        {
            this.sendRequester = sendRequester;
        }

        public async Task<IEnumerable<int>> GetTimeForRoutesAsync(double latOrigin, double lngOrigin,
            IEnumerable<Tuple<double, double>> destinations)
        {
            var apiKey = "AIzaSyDfcPgvdVOXTXTzPt-G7fl_BAmjT_6QQcc";

            var url = $"https://maps.googleapis.com/maps/api/distancematrix/json?origins={latOrigin},{lngOrigin}";

            url += "&destinations=";
            url = destinations.Aggregate(url, (current, destination) => current + $"{destination.Item1},{destination.Item2}|");
            url = url.Remove(url.Length - 1);
            url += $"&key={apiKey}";

            var resultObject = await sendRequester.GetAsync(url);
            var timeValues = resultObject["rows"][0]["elements"].Select(r => (int)r["duration"]["value"]);

            return timeValues;
        }
    }
}
