using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class loginController : ApiController
    {
        // GET: api/login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/login
        public string Post([FromBody]string value)
        {
            string[] v = value.Split(',');
            v[0] = v[0].Remove(0, 1);
            v[v.Length - 1] = v[v.Length - 1].Remove(v[v.Length - 1].Length - 1);

            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT user_id, user_password FROM rentipav_rentindawo.tbl_user WHERE user_number = '" + v[0].Remove(0,1)+"'";

            try
            {
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return "Failure: " + ex;
            }

            string password = "";
            string id = "";
            MySqlDataReader fetch_query = query.ExecuteReader();
            while (fetch_query.Read())
            {
                password = fetch_query["user_password"].ToString();
                id = fetch_query["user_id"].ToString();
            }
            if (password.Equals(v[1]))
            {
                return "true "+id;
            }
            return "false";
        }

        // PUT: api/login/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/login/5
        public void Delete(int id)
        {
        }
    }
}
