using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
   public class BL_Impl_Auditoria_Planilla_P:BL_Impl_Auditoria_Planilla_P_Interface
    {
        private static Database _baseInterface;
        public override BE_Auditoria_Planilla_Ps Obtener_Auditoria_Planilla_PSelAll()
        {
            BE_Auditoria_Planilla_Ps ps2 = new BE_Auditoria_Planilla_Ps();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.Auditoria_Monto_Sueldo");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_Auditoria_Planilla_P item = new BE_Auditoria_Planilla_P(Convert.ToString(reader["IDITEM"]), Convert.ToString(reader["CODUSER"]),
                        Convert.ToString(reader["CODIGO"]), Convert.ToString(reader["NOMBRE"]), Convert.ToString(reader["MONTOLOCAL"]),
                        Convert.ToString(reader["MONTOLOCALA"]), Convert.ToString(reader["IP"]), Convert.ToString(reader["FECHA"]),
                        Convert.ToString(reader["PUESTO"]), Convert.ToString(reader["CENTROCOSTOS"]), Convert.ToString(reader["AREA"]), Convert.ToString(reader["GERENCIA"]));
                    ps2.Add(item);
                }
            }
            return ps2;
        }

        public override bool Actualizar_Auditoria_Planilla_PSalarioPSelAll(string IdItem)
        {

            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.Auditoria_Monto_Sueldo_Actualizar");
            this.BaseInterface.AddInParameter(storedProcCommand, "@pIDITEM", DbType.String, IdItem);
            try
            {
                if (this.BaseInterface.ExecuteNonQuery(storedProcCommand) > 0)
                {
                    return true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return false;
        }

        public override Database BaseInterface
        {
            get
            {
                if (_baseInterface == null)
                {
                    //_baseInterfaceSpring = new SqlDatabase("Data Source=S10SERVERINCOT;Initial Catalog=Alerta;User ID=sa;Password=incot$2016");
                    _baseInterface = new SqlDatabase("Data Source=SERVERERP;Initial Catalog=INTERFACES;User ID=consulta;Password=consulta");
                }
                return _baseInterface;
            }
        }

    }
}
