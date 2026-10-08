using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProject.AlternatingLeaveSchedule
{
   // internal class SessionManagerALS
    public static class SessionManagerALS
    {
        public static string Username { get;set; }
        //public static string Pass { get; private set; }


        public static void SetUser (string Usename1)
        {
            Username = Usename1;
            //Pass = PassWord1;
        }


        public static void ClearUser ()
        {
            Username = null;
            //Pass = null;
        }


    }
}
