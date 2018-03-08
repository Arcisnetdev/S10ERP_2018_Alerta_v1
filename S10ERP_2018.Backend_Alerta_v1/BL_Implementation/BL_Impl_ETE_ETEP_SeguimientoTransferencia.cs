using System;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{


    public class BL_Impl_ETE_ETEP_SeguimientoTransferencia : BL_Impl_ETE_ETEP_SeguimientoTransferencia_Interface
    {
        private static Database _baseInterface;
        public override BE_ETE_ETEP_SeguimientoTransferencias ObtenerETE_ETEP_SeguimientoTransferenciaSelAll()
        {
            BE_ETE_ETEP_SeguimientoTransferencias facturars = new BE_ETE_ETEP_SeguimientoTransferencias();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.S10_Almacenes_ETE_ETEP_SeguimientoTransferencia");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_ETE_ETEP_SeguimientoTransferencia item = new BE_ETE_ETEP_SeguimientoTransferencia(Convert.ToString(reader["PROYECTO"]), Convert.ToString(reader["ALMACEN"]), Convert.ToString(reader["CODGUIA"]),
                        Convert.ToString(reader["FECHAGUIA"]), Convert.ToString(reader["SERIEDOCUMENTO"]), Convert.ToString(reader["NRODOCUMENTO"]), Convert.ToString(reader["MOVIMIENTOORIGEN"]),
                        Convert.ToString(reader["ESTADOCIERRE"]), Convert.ToString(reader["CODRECURSO"]), Convert.ToString(reader["RECURSO"]), Convert.ToString(reader["SIMBOLO"]),
                        Convert.ToString(reader["PARCIAL"]), Convert.ToString(reader["CODPEDIDO"]), Convert.ToString(reader["PROYECTODESTINO"]), Convert.ToString(reader["CODGUIARELACION"]),
                        Convert.ToString(reader["CREACIONUSUARIO"]), Convert.ToString(reader["CREACIONFECHA"]), Convert.ToString(reader["ACTUALIZACIONUSUARIO"]), Convert.ToString(reader["ACTUALIZACIONFECHA"]), Convert.ToString(reader["ANO"]));
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
                    _baseInterface = new SqlDatabase("Data Source=SERVERERP;Initial Catalog=INTERFACES;User ID=consulta;Password=consulta");
                }
                return _baseInterface;
            }
        }
    }
}
