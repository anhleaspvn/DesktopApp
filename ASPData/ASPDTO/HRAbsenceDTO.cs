using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDTO
{
    public class HRAbsenceDTO
    {
        public string Stt { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string EmpID { get; set; } = string.Empty;
        public string EmpName { get; set; } = string.Empty;
        public string EmpPosition { get; set; } = string.Empty;
        public DateTime TimeOff { get; set; }
        public double NumDateOff { get; set; } = 0;
        public string TypeOfAbsence { get; set; } = string.Empty;
        public string ReasonOfAbsence { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime InsertDate { get; set; }
        public bool AHDStatus { get; set; } = false;
        public bool HRStatus { get; set; } = false;
        public bool DLDStatus { get; set; } = false;
        public bool ABODStatus { get; set; } = false;
        public bool LineLeaderStatus { get; set; } = false;
        public string AHDBy { get; set; } = string.Empty;
        public string ABODBy { get; set; } = string.Empty;
        public DateTime AHDDate { get; set; }
        public DateTime ABODDate { get; set; }
        public string HRBy { get; set; } = string.Empty;
        public string LineLeaderBy { get; set; } = string.Empty;
        public DateTime HRDate { get; set; }
        public DateTime LineLeaderDate { get; set; }
        public string DLDBy { get; set; } = string.Empty;
        public DateTime DLDDate { get; set; }
        public string UpdateType { get; set; } = string.Empty;
        public string TimekeepID { get; set; } = string.Empty;
        public string FactoryID { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public int TypeEmp { get; set; } = 0;
    }

    public class HRAbsenceStaffDTO
    {
        public DateTime TimeOff { get; set; } = DateTime.Now;
        public int NumDateOff { get; set; } = 0;
        public string TypeOfAbsence { get; set; } = string.Empty;
        public string ReasonOfAbsence { get;set; } = string.Empty;
        public string ApprovedEmp { get; set; } = string.Empty;
        public string ApprovedHOD { get; set; } = string.Empty;
        public string ApprovedHR { get; set; } = string.Empty;
        public string ApprovedBOD { get; set; } = string.Empty;
    }
}
