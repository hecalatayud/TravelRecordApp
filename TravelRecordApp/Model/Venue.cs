using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelRecordApp.Model
{
    public class Venue
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public static async Task<IEnumerable<Venue>> GetVenuesAsync(double latitude, double longitude)
        {
            using (var client = new HttpClient())
                return JsonConvert.DeserializeObject<VenueRoot>(await (await client.GetAsync(VenueRoot.GenerateUrl(latitude, longitude))).Content.ReadAsStringAsync()).Response.Venues;
        }
    }
}
