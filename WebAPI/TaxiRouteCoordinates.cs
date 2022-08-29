using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class TaxiRouteCoordinates
    {
        public String taxiRoute_latitude;
        public String taxiRoute_longitude;

        public TaxiRouteCoordinates(String latitude, String longitude)
        {
            this.taxiRoute_latitude = latitude;
            this.taxiRoute_longitude = longitude;

        }
    }
}