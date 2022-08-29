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
    public class TaxiRouteUsersController : ApiController
    {
        // GET: api/TaxiRouteUsers
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TaxiRouteUsers/5
        public string Get(int id)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM rentipav_rentindawo.users_tbl_route";

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return "Failure: " + ex;
            }

            string serializeduserobj = "";

            MySqlDataReader fetch_query = query.ExecuteReader();
            while (fetch_query.Read())
            {
                user userdetails = new user(fetch_query["user_name"].ToString(), fetch_query["user_surname"].ToString(), fetch_query["user_number"].ToString(), fetch_query["user_NumRoutes"].ToString());
                serializeduserobj = JsonConvert.SerializeObject(userdetails);
            }

            return serializeduserobj;
        }

        // POST: api/TaxiRouteUsers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TaxiRouteUsers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TaxiRouteUsers/5
        public void Delete(int id)
        {
        }
    }
}
