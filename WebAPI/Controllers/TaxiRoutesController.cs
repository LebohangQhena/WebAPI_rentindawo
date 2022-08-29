using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class TaxiRoutesController : ApiController
    {
        // GET: api/TaxiRoutes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxiRoutes/5
        public string Get(int id)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT Route_Geocoordinates FROM rentipav_rentindawo.taxi_routes_tbl WHERE Taxi_Routes_ID = '" + id + "'";

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //return "Failure: " + ex;
            }

            string Route_Geocoordinates = "";
            MySqlDataReader fetch_query = query.ExecuteReader();
            while (fetch_query.Read())
            {
                Route_Geocoordinates = fetch_query["Route_Geocoordinates"].ToString();
            }

            String[] Route_Geocoo = Route_Geocoordinates.Split(':');
            TaxiRouteCoordinates Route_Geo = new TaxiRouteCoordinates(Route_Geocoo[0],Route_Geocoo[1].Replace('|', ' '));

            String json_Coordinates = JsonConvert.SerializeObject(Route_Geo);
            return json_Coordinates;
        }

        // POST: api/TaxiRoutes
        public void Post([FromBody]string value)
        {
            String[] strapartment = value.Split(',');
            strapartment[0] = strapartment[0].Remove(0, 1);
            strapartment[strapartment.Length - 1] = strapartment[strapartment.Length - 1].Remove(strapartment[strapartment.Length - 1].Length - 1);

            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "INSERT INTO `rentipav_rentindawo`.`taxi_routes_tbl` (`user_id`, `Route_Name`, `Route_Origin`, `Route_Destination`, `Route_Geocoordinates`, `Route_timesUsed`) VALUES ('" + strapartment[0] + "', '" + strapartment[1] + "', '" + strapartment[2] + "', '" + strapartment[3] + "', '" + strapartment[4] + "', '" + strapartment[5] + "');";

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //Response.Write("Failure: " + ex);
            }

            MySqlDataReader fetch_query = query.ExecuteReader();
            while (fetch_query.Read())
            {
                fetch_query.ToString();
            }
        }

        // PUT: api/TaxiRoutes/5
        public void Put(int id, [FromBody]string value)
        {
            string[] v = value.Split(',');
            v[0] = v[0].Remove(0, 1);
            v[v.Length - 1] = v[v.Length - 1].Remove(v[v.Length - 1].Length - 1);

            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            //update using previous route values
            string Route_Geocoordinates = "";
            Route_Geocoordinates += v[1];
            query.CommandText = "UPDATE rentipav_rentindawo.taxi_routes_tbl SET `Route_Geocoordinates` = '" + Route_Geocoordinates + "' WHERE `Taxi_Routes_ID` = " + id + ";";

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //Response.Write("Failure: " + ex);
            }

            MySqlDataReader fetch_query = query.ExecuteReader();
            while (fetch_query.Read())
            {
                fetch_query.ToString();
            }
        }

        // DELETE: api/TaxiRoutes/5
        public void Delete(int id)
        {
        }
    }
}
