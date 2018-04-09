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
  public  class BL_Impl_Pedido_Sin_Atender : BL_Impl_Pedido_Sin_Atender_Interface
    {

        private static Database _baseInterface;

        public override BE_Pedido_Sin_Atenders ObtenerPedido_Sin_AtenderSelAll()
        {
            BE_Pedido_Sin_Atenders facturars = new BE_Pedido_Sin_Atenders();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.S10_Pedidos_Sin_Atender");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_Pedido_Sin_Atender item = new BE_Pedido_Sin_Atender(Convert.ToString(reader["PROYECTO"]), Convert.ToString(reader["ALMACEN"]), Convert.ToString(reader["NROPEDIDO"]),
                        Convert.ToString(reader["ESTADO"]), Convert.ToString(reader["FECHAPEDIDO"]), Convert.ToString(reader["CREACIONFECHA"]), Convert.ToString(reader["ACTUALIZACIONFECHA"]),
                        Convert.ToString(reader["FECHAAPROBACION"]), Convert.ToString(reader["TIEMPOENTREGA"]), Convert.ToString(reader["CREACIONUSUARIO"]), Convert.ToString(reader["USUARIOA"]),
                        Convert.ToString(reader["USUARIO"]), Convert.ToString(reader["CODPEDIDOINTERNO"]), Convert.ToString(reader["ORDENDEPRODUCCION"]), Convert.ToString(reader["DESESTADOCOTIZACION"]),
                        Convert.ToString(reader["DESESTADOORDENCOMPRA"]), Convert.ToString(reader["DESESTADOALMACEN"]), Convert.ToString(reader["CENTROCOMPRA"]),
                        Convert.ToString(reader["OBSERVACION"]));
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
