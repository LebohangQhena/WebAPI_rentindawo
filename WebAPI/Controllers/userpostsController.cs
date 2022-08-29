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
    public class userpostsController : ApiController
    {
        // GET: api/userposts
        public IEnumerable<string> Get()
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM rentipav_rentindawo.apartment";

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return new string[] { "Failure: " + ex };
            }

            MySqlDataReader reader = query.ExecuteReader();
            List<userposts> apartments = new List<userposts>();
            while (reader.Read())
            {
                userposts up = new userposts(reader["apartment_id"].ToString(), reader["user_id"].ToString(), reader["location_id"].ToString(), reader["apartment_price"].ToString(), reader["apartment_availiability"].ToString(), reader["apartment_dateposted"].ToString(), reader["apartment_type"].ToString(), reader["apartment_details"].ToString(), reader["apartment_picture"].ToString(), reader["apartment_views"].ToString());

                apartments.Add(up);
            }

            string serializedobj = JsonConvert.SerializeObject(apartments);
            return new string[] { serializedobj };//JsonSerializer.Create().Serialize(apartments);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/userposts/5
        public IEnumerable<string> Get(int id)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            //update number of views
            query.CommandText = "SELECT * FROM rentipav_rentindawo.apartment WHERE user_id = " + id;

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return new string[] { "Failure: " + ex };
            }

            MySqlDataReader reader = query.ExecuteReader();
            List<userposts> apartments = new List<userposts>();
            while (reader.Read())
            {
                /*
                String apartment = reader["user_id"].ToString();
                apartment += ", " + reader["location_id"].ToString();
                apartment += ", " + reader["apartment_price"].ToString();
                apartment += ", " + reader["apartment_availiability"].ToString();
                apartment += ", " + reader["apartment_dateposted"].ToString();
                apartment += ", " + reader["apartment_type"].ToString();
                apartment += ", " + reader["apartment_details"].ToString();
                apartment += ", " + reader["apartment_picture"].ToString();
                apartment += ", " + reader["apartment_views"].ToString();
                */

                userposts up = new userposts(reader["apartment_id"].ToString(), reader["user_id"].ToString(), reader["location_id"].ToString(), reader["apartment_price"].ToString(), reader["apartment_availiability"].ToString(), reader["apartment_dateposted"].ToString(), reader["apartment_type"].ToString(), reader["apartment_details"].ToString(), reader["apartment_picture"].ToString(), reader["apartment_views"].ToString());

                apartments.Add(up);
            }

            string serializedobj = JsonConvert.SerializeObject(apartments);
            return new string[] { serializedobj };//JsonSerializer.Create().Serialize(apartments);
        }

        // POST: api/userposts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/userposts/5
        public void Put(int id, [FromBody]string apartment_views)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            
            //Update number of views
            int intviews = int.Parse(apartment_views) + 1;
            query.CommandText = "UPDATE `rentipav_rentindawo`.`apartment` SET `apartment_views` = '" + intviews + "' WHERE `apartment_id` = " + id + ";";

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

        // DELETE: api/userposts/5
        public void Delete(int id)
        {
        }
    }
}
