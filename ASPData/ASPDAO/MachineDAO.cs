using ASPData.ASPDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPData.MachineDAO
{
    public class MachineDAO
    {
        private readonly configDatabase _config = new configDatabase();
        private readonly SQLHelper _sqlhelper = new SQLHelper();

        public DataTable GetAllMachine()
        {
            var dicParams = new Dictionary<string, object>();

            DataTable MachineDt = new DataTable();
            MachineDt = _sqlhelper.ExecProcedureDataAsDataTable("sp_ASPGetAllMachine", dicParams);

            return MachineDt;
        }

        public void ImportExcelMachine(MachineDTO.MachineDTO machineDto)
        {
            var dicParams = new Dictionary<string, object>()
            {
                { "@MachineID", machineDto.MachineID },
                { "@MachineName", machineDto.MachineName },
                { "@MaintenanceMonth", machineDto.MaintenanceMonth },
                { "@MachineGroup", machineDto.MachineGroup },
                { "@ACCID", machineDto.ACCID },
                { "@WarehouseEntryDate", machineDto.WarehouseEntryDate },
                { "@MachineOrigin", machineDto.MachineOrigin },
                { "@TypeID", machineDto.TypeID },
                { "@Supplier", machineDto.Supplier },
                { "@CreatedBy", machineDto.CreatedBy },
                { "@CreatedDate", machineDto.CreatedDate },
                { "@LastModifiedBy", machineDto.LastModifiedBy },
                { "@LastModifiedDate", machineDto.LastModifiedDate }
            };

            _sqlhelper.ExecProcedureNonData("sp_ASPImportExcelMachine", dicParams);
        }
    }
}
