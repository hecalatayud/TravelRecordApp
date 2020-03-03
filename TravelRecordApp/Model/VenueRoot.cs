using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TravelRecordApp.Helpers;

namespace TravelRecordApp.Model
{
    public class VenueRoot
    {
        public Response Response { get; set; }

        public static string GenerateUrl(double latitude, double longitude) => string.Format(Constants.VenueSearch, latitude.ToString(CultureInfo.InvariantCulture), longitude.ToString(CultureInfo.InvariantCulture), Constants.ClientId, Constants.ClientSecret, DateTime.Now.ToString("yyyyMMdd"));
    }
}
