using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.EmployeeDTO
{
    public class EmployeeDTO
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public string Position { get; set; }
        public string LineID { get; set; }
        public string Direct { get; set; }
        public bool QuitJob { get; set; }   
        public bool QuitMaternity { get; set; }
        public string HREmpID { get; set; }
        public bool IsOfficialEmp { get; set; }   
        public string Description { get; set;  }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
