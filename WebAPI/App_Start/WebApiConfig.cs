using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace WebAPI
{
    
    public static class WebApiConfig
    {
        public static MySqlConnection conn()
        {
            String conn_string = "server=192.168.110.34;port=3306;database=rentipav_rentindawo;username=rentipav_lebo;password=gmveaxk9lqdscjiyhrub;";
            //
            //localUser - "server=127.0.0.1;port=3306;database=taxiroutes;username=root;password=;";

            MySqlConnection conn = new MySqlConnection(conn_string);

            return conn;
        }
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
