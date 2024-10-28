using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.ASPDAO
{
    public class DefectiveModeDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetAllDefectiveMode()
        {
            var dicParams = new Dictionary<string, object>();

            DataTable DefectDt = new DataTable();
            DefectDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllDefectiveMode", dicParams);

            return DefectDt;
        }

        public void DeleteDefectiveMode(DefectiveModeDTO.DefectiveModeDTO defectDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@DefectID", defectDto.DefectID}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPDeleteDefectiveMode", dicParams);
        }

        public void InsertDefectiveMode(DefectiveModeDTO.DefectiveModeDTO defectDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@DefectID", defectDto.DefectID},
                { "@DefectName", defectDto.DefectName},
                { "@DefectType", defectDto.DefectType },
                { "@DefectLevel", defectDto.DefectLevel },
                { "@Mold_Assembly", defectDto.Mold_Assembly },
                { "@MainStep", defectDto.MainStep },
                { "@CreatedBy", defectDto.CreatedBy},
                { "@CreatedDate", defectDto.CreatedDate}
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPInsertDefectiveMode", dicParams);
        }
        public void UpdateDefectiveMode(DefectiveModeDTO.DefectiveModeDTO defectDto)
        {
            var dicParams = new Dictionary<string, object>
            {
                { "@DefectID", defectDto.DefectID},
                { "@DefectName", defectDto.DefectName},
                { "@DefectType", defectDto.DefectType },
                { "@DefectLevel", defectDto.DefectLevel },
                { "@Mold_Assembly", defectDto.Mold_Assembly },
                { "@MainStep", defectDto.MainStep },
                { "@LastModifiedBy", defectDto.LastModifiedBy },
                { "@LastModifiedDate", defectDto.LastModifiedDate }
            };

            var delEmp = _sqlhelper.ExecProcedureSacalar("sp_ASPUpdateDefectiveMode", dicParams);
        }
    }
}
