using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
   public class BL_ObjControl_Resultado_Operativo_D
    {

        public static object PoblarResultado_Operativo_DSelAll(string codproyecto, string codpresupuesto)
        {
            return BL_Utils.BL_Utils_Resultado_Operativo_D.BL_Impl_Resultado_Operativo_D.ObtenerResultado_Operativo_DSelAll(codproyecto, codpresupuesto);
        }
    }
}
