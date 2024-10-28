using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDTO
{
    public class NFCReaderDTO
    {
        public DateTime DocDate { get; set; } = DateTime.Now.Date;
        public string SM232Content { get; set; } = string.Empty;
        public string QRCodeContent { get; set; } = string.Empty;
        public string ResultMatch { get; set; } = string.Empty;
        public string LaserMC { get; set; } = string.Empty;
        public string RGB { get; set; } = string.Empty;
        public string HSV { get; set; } = string.Empty;
        public string RGB2 { get; set; } = string.Empty;
        public string HSV2 { get; set; } = string.Empty;
        public string ColorID { get; set; } = string.Empty;
        public string HaveSpring { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime FromDate { get; set; } = DateTime.Now;
        public DateTime ToDate { get; set; } = DateTime.Now;
    }
}
