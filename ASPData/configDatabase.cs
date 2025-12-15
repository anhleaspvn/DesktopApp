using System;
using System.Data.SqlClient;
using System.Configuration;

namespace ASPData
{
    public partial class configDatabase
    {
        //NTAStone
        //user: NTAStone
        //pass: I5xl?44g
        public static string CONNECT_STRING_SQLITE = "";
        public static string IP_SERVER_NAME = "";
        public static string USERNAME_DB = "";
        public static string PASSWORD_DB= "";
        public static string DATABASE = "";
        public static int TIME_OUT = 360;
        public static bool IS_CONNECTED = true;

        //public static string CONNECTION_STRINGS = "YKg3l0z98XvbHzahT6MMZhE6ocv4MrKGT+fb/bJ/omwgmZ+XGQyksJvL3Ze2Qfz1HnD7zT+Gq9ss8mOH2ufJbnpc2jVogIxCQr5HX8TW9Hgp44E7DMCEXP0+p0srjGE0mIuUhRiO+x7tZ9IiAoZwwizK7AhBnQWZjV9qJIchtoVkt6eFJgI/N8duEY05DZY+1r4bBBCT9GhlhtnR8q8DkY7sNXDmyGGsW09m5r3Yj4kde1QmLUrYp/E5hBXuDJvpwLefTwSmot7ZIqK5Lo7NIw==";
        public static string CONNECTION_STRINGS = "YKg3l0z98XvbHzahT6MMZhE6ocv4MrKGT+fb/bJ/omwgmZ+XGQyksJvL3Ze2Qfz1HnD7zT+Gq9ss8mOH2ufJbnpc2jVogIxCQr5HX8TW9Hgp44E7DMCEXP0+p0srjGE08oqePJmW9MC1jxoVo17U9aaoKBkzZ9Lb0D78WYnLKJxJtSG7rWqd7pU4ogO0hV5WJgGuKfjL8OvA3b7FnCIzjUFgO5CC5zrgOqT11neZjSdsohzBX5iVYmF4g8nXAtAPDHq+KDSZUdkwYOMBZE1K5A==";
        public enum LOGIN_STATUS
        {
            LOGGINED,
            LOCKED,
            UN_LOGGIN,
        }

        public string ConnectString()
        {
            CONNECTION_STRINGS = $"Server={IP_SERVER_NAME};Database={DATABASE};User Id={USERNAME_DB};Password={PASSWORD_DB};Connection Timeout={TIME_OUT}";
            return CONNECTION_STRINGS;
        }

        public bool CheckConnectionString(string connnection_string)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connnection_string);
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
