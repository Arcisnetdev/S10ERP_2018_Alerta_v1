using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
  public  class BL_Impl_OC_SIn_Aprobar : BL_Impl_OC_SIn_Aprobar_Interface
    {

        private static Database _baseInterface;

        public override BE_OC_SIn_Aprobars ObtenerOC_SIn_AprobarSelAll()
        {
            BE_OC_SIn_Aprobars facturars = new BE_OC_SIn_Aprobars();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.S10_Orden_Compra_Sin_Aprobar");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_OC_SIn_Aprobar item = new BE_OC_SIn_Aprobar(Convert.ToString(reader["PROYECTO"]), Convert.ToString(reader["NROORDEN"]), Convert.ToString(reader["TIPO"]),
                        Convert.ToString(reader["FORMADEPAGO"]), Convert.ToString(reader["MONEDA"]), Convert.ToString(reader["VALORNETO"]), Convert.ToString(reader["ESTADOOC"]),
                        Convert.ToString(reader["PROVEEDORRUC"]), Convert.ToString(reader["PROVEEDOR"]), Convert.ToString(reader["LUGARDEENTREGA"]), Convert.ToString(reader["FECHAORDEN"]),
                        Convert.ToString(reader["FECHAENTREGA"]), Convert.ToString(reader["PROCEDENCIA"]), Convert.ToString(reader["CENTROCOMPRA"]), Convert.ToString(reader["CREACIONUSUARIO"]),
                        Convert.ToString(reader["ACTUALIZACIONUSUARIO"]), Convert.ToString(reader["FECHAENVIOAPROBACION"]), Convert.ToString(reader["USUARIOA"]),
                        Convert.ToString(reader["COMPRADOR"]), Convert.ToString(reader["OBSERVACION"]));
                    facturars.Add(item);
                }
            }
            return facturars;
        }


        public override Database BaseInterface
        {
            get
            {
                if (_baseInterface == null)
                {
                    _baseInterface = new SqlDatabase("Data Source=S10SERVERINCOT;Initial Catalog=Alerta;User ID=sa;Password=incot$2016");
                    //_baseInterface = new SqlDatabase("Data Source=SERVERERP;Initial Catalog=INTERFACES;User ID=consulta;Password=consulta");
                }
                return _baseInterface;
            }
        }
    }
}
