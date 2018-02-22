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
   public class BL_Impl_ETE_ETEP_SeguimientoTransferenciaGG : BL_Impl_ETE_ETEP_SeguimientoTransferenciaGG_Interface
    {
        private static Database _baseInterface;


        public override BE_ETE_ETEP_SeguimientoTransferenciaGGs ObtenerETE_ETEP_SeguimientoTransferenciaGGSelAll()
        {
            BE_ETE_ETEP_SeguimientoTransferenciaGGs facturars = new BE_ETE_ETEP_SeguimientoTransferenciaGGs();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.S10_Almacenes_001_004_ETE_ETEP_SeguimientoTransferenciaGG");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_ETE_ETEP_SeguimientoTransferenciaGG item = new BE_ETE_ETEP_SeguimientoTransferenciaGG(Convert.ToString(reader["DESCRIPCION"]), Convert.ToString(reader["ESTADO_PROYECTO"]), Convert.ToString(reader["TOTAL_PENDIENTE"]),
                        Convert.ToString(reader["PROYECTO_DESTINO"]));
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
