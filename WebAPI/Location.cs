using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class Location
    {
        public string location_province;
        public string location_city;
        public string location_suburb;

        public Location(string l_p, string l_c, string l_s)
        {
            this.location_province = l_p;
            this.location_city = l_c; 
            this.location_suburb = l_s;

        }
    }
}