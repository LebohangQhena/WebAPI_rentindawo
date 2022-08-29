using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "SELECT * FROM rentipav_rentindawo.tbl_user WHERE user_id =" + id;

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
                user userdetails = new user(fetch_query["user_name"].ToString(), fetch_query["user_surname"].ToString(), fetch_query["user_number"].ToString(), fetch_query["user_email"].ToString());
                serializeduserobj = JsonConvert.SerializeObject(userdetails);
            }

            return serializeduserobj;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            string[] v = value.Split(',');
            v[0] = v[0].Remove(0, 1);
            v[v.Length-1] = v[v.Length - 1].Remove(v[v.Length-1].Length-1);
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();
            query.CommandText = "INSERT INTO rentipav_rentindawo.tbl_user (user_id, user_name, user_surname, user_number, user_email, user_password) VALUES (0,'" + v[0]+"', '"+v[1]+ "', " + v[3] + ", '" + v[2] + "', '"+v[4]+"');";

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

        // PUT api/values/5
        public void Put(int id, [FromBody]user userdetails)
        {
            MySqlConnection conn = WebApiConfig.conn();
            MySqlCommand query = conn.CreateCommand();

            query.CommandText = "UPDATE `rentipav_rentindawo`.`tbl_user` SET `user_name` = '" + userdetails.getname() + "', `user_surname` = '" + userdetails.getsurname() + "', `user_number` = '" + userdetails.getnumbers() + "', `user_email` = '" + userdetails.getemail() + "' WHERE `user_id` = " + id + ";";

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

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
