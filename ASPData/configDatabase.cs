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

        //public static string CONNECTION_STRINGS = "YKg3l0z98XvbHzahT6MMZpjkXtsSngYHytlBKM0saicB9TNFPZL+4Ks9HBeSDubdY6/bKzXWFYjo+QRnv0B9jxmH0kqw+LGgtiCQ5SIJ5sHQ+GC1X1/Q/u6nCd61sLpV3emWa/8ArQ1aY3jLB+ktyr/87g1M0shLCt9vRD0YClFEvYoYUz83gQ/s2/JktioH/YBQjHBkAqC9kGqsaX7gUw==";
        public static string CONNECTION_STRINGS = "YKg3l0z98XvbHzahT6MMZhE6ocv4MrKGT+fb/bJ/omwgmZ+XGQyksJvL3Ze2Qfz1HnD7zT+Gq9ss8mOH2ufJbnpc2jVogIxCQr5HX8TW9Hgp44E7DMCEXP0+p0srjGE08oqePJmW9MC1jxoVo17U9aaoKBkzZ9Lb0D78WYnLKJxJtSG7rWqd7pU4ogO0hV5WmlRmda2rNiPw+jvWNmHXzg==";
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
