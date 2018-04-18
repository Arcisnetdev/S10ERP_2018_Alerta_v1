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
   public class BL_Impl_Auditoria_Empleado:BL_Impl_Auditoria_Empleado_Interface
    {
        private static Database _baseInterface;
        public override BE_Auditoria_Empleados Obtener_Auditoria_EmpleadoSelAll()
        {
            BE_Auditoria_Empleados ps2 = new BE_Auditoria_Empleados();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.Auditoria_Empleados");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_Auditoria_Empleado item = new BE_Auditoria_Empleado(Convert.ToString(reader["CodEmp"]), Convert.ToString(reader["NombreCompleto"]),
                        Convert.ToString(reader["DNI"]), Convert.ToString(reader["TipoPlanilla"]), Convert.ToString(reader["Estado"]),
                        Convert.ToString(reader["Cargo"]), Convert.ToString(reader["FechaIngreso"]), Convert.ToString(reader["FechaInicioContrato"]),
                        Convert.ToString(reader["FechaFinContrato"]), Convert.ToString(reader["FechaCese"]), Convert.ToString(reader["CentroCostos"]), Convert.ToString(reader["DeptoOrganizacion"]),
                        Convert.ToString(reader["UltimoUsuario"]), Convert.ToString(reader["UltimaFechaModif"]));
                    ps2.Add(item);
                }
            }
            return ps2;
        }

        public override bool Actualizar_Auditoria_EmpleadoSelAll(string IdItem)
        {

            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.Auditoria_Empleados_Actualizar");
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
