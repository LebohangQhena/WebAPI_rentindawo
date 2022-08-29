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
    public class LocationController : ApiController
    {
        // GET: api/Location
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Location/5
        public IEnumerable<string> Get(int id)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM rentipav_rentindawo.tbl_location WHERE location_id = " + id;

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return new string[] { "Failure: " + ex };
            }

            MySqlDataReader reader = query.ExecuteReader();
            Location apartmentlocation = null;
            while (reader.Read())
            {
                apartmentlocation = new Location(reader["location_province"].ToString(), reader["location_city"].ToString(), reader["location_suburb"].ToString());
                
            }

            string serializeobj = JsonConvert.SerializeObject(apartmentlocation);
            return new string[] { serializeobj };
        }

        // POST: api/Location
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Location/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Location/5
        public void Delete(int id)
        {
        }
    }
}
