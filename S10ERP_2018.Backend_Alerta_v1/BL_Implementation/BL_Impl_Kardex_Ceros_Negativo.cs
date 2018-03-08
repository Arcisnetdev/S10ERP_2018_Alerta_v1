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
    public class BL_Impl_Kardex_Ceros_Negativo : BL_Impl_Kardex_Ceros_Negativo_Interface
    {

        private static Database _baseInterface;

        public override BE_Kardex_Ceros_Negativos ObtenerKardex_Ceros_NegativoSelAll()
        {
            BE_Kardex_Ceros_Negativos facturars = new BE_Kardex_Ceros_Negativos();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.Kardex_Cantidades_Cero_Negativos");
            using (SqlDataReader reader = (SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_Kardex_Ceros_Negativo item = new BE_Kardex_Ceros_Negativo(Convert.ToString(reader["PROYECTO"]), Convert.ToString(reader["ALMACEN"]), Convert.ToString(reader["CODRECURSO"]),
                        Convert.ToString(reader["RECURSO"]), Convert.ToString(reader["UNIDAD"]), Convert.ToString(reader["FECHAGUIA"]), Convert.ToString(reader["NROGUIA"]),
                        Convert.ToString(reader["MOVIMIENTO"]), Convert.ToString(reader["MONEDA"]), Convert.ToString(reader["CANTIDAD"]), Convert.ToString(reader["PRECIO"]),
                        Convert.ToString(reader["STOCKANTERIOR"]), Convert.ToString(reader["STOCKACTUAL"]), Convert.ToString(reader["PROYECTOTRANS"]), Convert.ToString(reader["ALMACENTRANS"]));
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