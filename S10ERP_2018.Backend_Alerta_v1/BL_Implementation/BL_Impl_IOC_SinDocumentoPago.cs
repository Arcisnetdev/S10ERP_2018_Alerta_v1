using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
    public class BL_Impl_IOC_SinDocumentoPago : BL_Impl_IOC_SinDocumentoPago_Interface
    {

        private static Database _baseInterface;

        public override BE_IOC_SinDocumentoPagos ObtenerGuiasSinFacturarSelAll()
        {
            BE_IOC_SinDocumentoPagos facturars = new BE_IOC_SinDocumentoPagos();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.S10_GuiasIOC_SinFacturar");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_IOC_SinDocumentoPago item = new BE_IOC_SinDocumentoPago(Convert.ToString(reader["PROYECTO"]), Convert.ToString(reader["NROOC"]), Convert.ToString(reader["ALMACEN"]),
                        Convert.ToString(reader["CODGUIA"]), Convert.ToString(reader["FECHAGUIA"]), Convert.ToString(reader["NROGUIAREMISION"]), Convert.ToString(reader["PROVEEDOR"]),
                        Convert.ToString(reader["ESTADOCIERRE"]), Convert.ToString(reader["MOVIMIENTO"]), Convert.ToString(reader["MONEDA"]), Convert.ToString(reader["FORMADEPAGO"]),
                        Convert.ToString(reader["PARCIAL"]));
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
