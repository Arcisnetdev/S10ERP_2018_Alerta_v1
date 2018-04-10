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
   public class BL_Impl_Auditoria_Vacaciones_Personal:BL_Impl_Auditoria_Vacaciones_Personal_Interface
    {
        private static Database _baseInterface;
        public override BE_Auditoria_Vacaciones_Personals Obtener_Auditoria_Vacaciones_PersonalSelAll()
        {
            BE_Auditoria_Vacaciones_Personals vs2 = new BE_Auditoria_Vacaciones_Personals();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.Auditoria_Vacaciones_Personal");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_Auditoria_Vacaciones_Personal item = new BE_Auditoria_Vacaciones_Personal(Convert.ToString(reader["IDITEM"]), Convert.ToString(reader["CODUSER"]),
                        Convert.ToString(reader["CODIGO"]), Convert.ToString(reader["NOMBRE"]), Convert.ToString(reader["PERIODO"]),
                        Convert.ToString(reader["DERECHO"]), Convert.ToString(reader["UTILIZADO"]), Convert.ToString(reader["PENDIENTE"]),
                        Convert.ToString(reader["IP"]), Convert.ToString(reader["FECHA"]));
                    vs2.Add(item);
                }
            }
            return vs2;
        }

        public override bool Actualizar_Vacaciones_PersonalSelAll(string IdItem)
        {
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.Auditoria_Vacaciones_Personal_Actualizar");
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
