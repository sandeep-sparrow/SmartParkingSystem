using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    public class Helper
    {
        // this is a static method which takes in the string value i.e. Database name and returns a string value of connection to RDBMS...
        // the ConfigurationManager class provides access to client Application exampleL: SQL server....
        // using the get & set property ConnectionString from class ConnectionStringSettings you get the ConnectionString of your Default Db connection...
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
