using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PQM_v01.Sqlcommon
{
    public class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            //Data Source = LONG; Initial Catalog = TEST; Integrated Security = True
            string datasource = "172.16.0.11";
            string database = "SFT_TECHLINK";
            string username = "soft";
            string password = "techlink@!@#";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}