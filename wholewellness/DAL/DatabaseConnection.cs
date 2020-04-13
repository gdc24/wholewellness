using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using wholewellness.Models;

namespace wholewellness.DAL
{
    public class DatabaseConnection
    {
        //public static readonly string SERVER = "127.0.0.1";
        //public static readonly string USER = "postgres";
        //public static readonly string DATABASE = "wholewellness";
        //public static readonly string PASS = "123456";
        public static readonly string SERVER = "drona.db.elephantsql.com";
        public static readonly string USER = "egibmokv";
        public static readonly string DATABASE = "egibmokv";
        public static readonly string PASS = "qWPmZC0XMLX8-jD17nCcEEwALX_-g-Cg";
        public static readonly string MAX_POOL_SIZE = "5";
        public static readonly string CONNECTION_IDLE_LIFETIME = "2"; // in seconds
        public static readonly string CONNECTION_PRUNING_INTERVAL = "1"; // in seconds

        public static NpgsqlConnection GetConnection()
        {
            // Specify connection options and open an connection
            NpgsqlConnection conn = new NpgsqlConnection("" +
                "Server=" + SERVER + ";" +
                "User Id=" + USER + ";" +
                "Password=" + PASS + ";" +
                "Database=" + DATABASE + ";"
                //+ "Connection Idle Lifetime=" + CONNECTION_IDLE_LIFETIME + ";"
                //+ "Connection Pruning Interval=" + CONNECTION_PRUNING_INTERVAL + ";"
                );

            return conn;
        }

    }
}