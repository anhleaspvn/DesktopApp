using ASPData.ASPDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class NFCReaderDAO
    {
        private SQLHelper _sqlHelper = new SQLHelper();
        public DataTable GetNFCQRCode(NFCReaderDTO nfcDto)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                { "@FromDate", nfcDto.FromDate.Date },
                { "@ToDate", nfcDto.ToDate.Date }
            };

            dt = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPGetNFCQRCode", dicParams);

            return dt;
        }

        public void InsertNFCQRCode(NFCReaderDTO nfcDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@DocDate", nfcDto.DocDate },
                { "@SM232Content", nfcDto.SM232Content },
                { "@QRCodeContent", nfcDto.QRCodeContent },
                { "@ResultMatch", nfcDto.ResultMatch },
                { "@LaserMC", nfcDto.LaserMC },
                { "@RGB", nfcDto.RGB },
                { "@HSV", nfcDto.HSV },
                { "@RGB2", nfcDto.RGB2 },
                { "@HSV2", nfcDto.HSV2 },
                { "@ColorID", nfcDto.ColorID },
                { "@HaveSpring", nfcDto.HaveSpring },
                { "@CreatedBy", nfcDto.CreatedBy },
                { "@CreatedDate", nfcDto.CreatedDate }
            };

            _sqlHelper.ExecProcedureNonData("sp_ASPInsertNFCQRCode", dicParams);
        }

        public DataTable FindProductColorFromRange(int Area1Red, int Area1Green, int Area1Blue, int Area2Red, int Area2Green, int Area2Blue)
        {
            DataTable dt = new DataTable();

            var dicParams = new Dictionary<string, object>()
            {
                {"@AREA1RED", Area1Red},
                {"@AREA1GREEN", Area1Green },
                {"@AREA1BLUE", Area1Blue },
                {"@AREA2RED", Area2Red},
                {"@AREA2GREEN", Area2Green },
                {"@AREA2BLUE", Area2Blue },
            };

            dt = _sqlHelper.ExecProcedureDataAsDataTable("sp_ASPFindProductColorFromRange", dicParams);

            return dt;
        }
    }
}
