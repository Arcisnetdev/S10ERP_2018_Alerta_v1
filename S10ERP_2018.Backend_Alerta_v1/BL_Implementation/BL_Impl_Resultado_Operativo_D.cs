﻿using Microsoft.Practices.EnterpriseLibrary.Data;
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
    public class BL_Impl_Resultado_Operativo_D : BL_Impl_Resultado_Operativo_D_Interface
    {

        private static Database _baseInterface;

        public override BE_Resultado_Operativo_Ds ObtenerResultado_Operativo_DSelAll(string codproyecto, string codpresupuesto)
        {
            BE_Resultado_Operativo_Ds facturars = new BE_Resultado_Operativo_Ds();
            DbCommand storedProcCommand = this.BaseInterface.GetStoredProcCommand("dbo.S10_Resultado_OperativoD");
            this.BaseInterface.AddInParameter(storedProcCommand, "@CODPROYECTO", DbType.String, codproyecto);
            this.BaseInterface.AddInParameter(storedProcCommand, "@CODPRESUPUESTO", DbType.String, codpresupuesto);
            using (SqlDataReader reader = (System.Data.SqlClient.SqlDataReader)this.BaseInterface.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    BE_Resultado_Operativo_D item = new BE_Resultado_Operativo_D(Convert.ToString(reader["GRUPO"]), Convert.ToString(reader["RECURSO"]), Convert.ToString(reader["PRESUPUESTO"]),
                        Convert.ToString(reader["PROGRAMADO"]), Convert.ToString(reader["VALORIZADO"]), Convert.ToString(reader["REALL"]));
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
                //    }
            }
        }
    }
}
