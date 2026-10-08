using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPProject.SkillMap
{
    internal class SessionMangerSkillMap
    {
        public static string Username { get; private set; }
        //public static string Pass { get; private set; }


        public static void SetUser(string Usename1)
        {
            Username = Usename1;
            //Pass = PassWord1;
        }


        public static void ClearUser()
        {
            Username = null;
            //Pass = null;
        }

    }
}
