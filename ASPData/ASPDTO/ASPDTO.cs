using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDTO
{
    public partial class ASPDTO
    {
        //LOGIN
        private string _userName;
        private string _password;

        public string UserName { get { return _userName; } set { _userName = value; } }
        public string Password { get { return _password; } set { _password = value; } }

        public string FuncID { get; set; }
        public string FuncName { get; set; }
        public object FuncValue { get; set; }

        //Factory
        public string FactoryID { get; set; }
        public string FactoryName { get; set; } = string.Empty;

    }
}
