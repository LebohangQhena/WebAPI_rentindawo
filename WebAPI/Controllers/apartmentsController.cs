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
    public class apartmentsController : ApiController
    {
        // GET: api/apartments
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
                return new string[1] { "Failure: " + ex };
            }

            MySqlDataReader reader = query.ExecuteReader();
            List<string> apartments = new List<string>();
            while (reader.Read())
            {
                String apartment = reader["user_id"].ToString();
                apartment += ", " + reader["location_id"].ToString();
                apartment += ", " + reader["apartment_price"].ToString();
                apartment += ", " + reader["apartment_availiability"].ToString();
                apartment += ", " + reader["apartment_dateposted"].ToString();
                apartment += ", " + reader["apartment_type"].ToString();
                apartment += ", " + reader["apartment_details"].ToString();
                apartment += ", " + reader["apartment_picture"].ToString();
                apartment += ", " + reader["apartment_views"].ToString();

                apartments.Add(apartment);
            }
            /*
            MySqlDataReader fetch_query = query.ExecuteReader();
            while (fetch_query.Read())
            {
                return new string[] { fetch_query["user_id"].ToString(), fetch_query["location_id"].ToString(), fetch_query["apartment_price"].ToString(), fetch_query["apartment_availiability"].ToString(), fetch_query["apartment_dateposted"].ToString(), fetch_query["apartment_type"].ToString(), fetch_query["apartment_details"].ToString(), fetch_query["apartment_picture"].ToString(), fetch_query["apartment_views"].ToString() };
            }
            */
            return apartments;
        }

        // GET: api/apartments/5
        public IEnumerable<string> Get(int id)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM rentipav_rentindawo.apartment WHERE apartment_id = " + id;

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return new string[] { "Failure: " + ex };
            }

            MySqlDataReader reader = query.ExecuteReader();
            List<userposts> usersapartments = new List<userposts>();
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
                usersapartments.Add(up);
            }

            string serializeobj = JsonConvert.SerializeObject(usersapartments);
            return new string[] { serializeobj };
        }


        // POST: api/apartments
        public void Post([FromBody]string value)
        {
            String[] strapartment = value.Split(',');
            strapartment[0] = strapartment[0].Remove(0, 1);
            strapartment[strapartment.Length - 1] = strapartment[strapartment.Length - 1].Remove(strapartment[strapartment.Length - 1].Length - 1);
            
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "INSERT INTO `rentipav_rentindawo`.`apartment` (`user_id`, `location_id`, `apartment_price`, `apartment_availiability`, `apartment_dateposted`, `apartment_type`, `apartment_details`, `apartment_picture`, `apartment_views`) VALUES ('" + strapartment[0] + "', '" + strapartment[1] + "', '" + strapartment[2] + "', '" + strapartment[3] + "', '" + strapartment[4] + "', '" + strapartment[5] + "', '" + strapartment[6] + "', '" + strapartment[7] + "', '" + strapartment[8] + "');";
            
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

        // PUT: api/apartments/5
        public void Put(int id, [FromBody]userposts up)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "UPDATE `rentipav_rentindawo`.`apartment` SET `apartment_price` = '" + up.apartment_price+ "', `apartment_type` = '" + up.apartment_type+ "', `apartment_details` = '" + up.apartment_details+ "' WHERE `apartment_id` = " + id+";";
            
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

        // DELETE: api/apartments/5
        public void Delete(int id)
        {
        }
    }
}
