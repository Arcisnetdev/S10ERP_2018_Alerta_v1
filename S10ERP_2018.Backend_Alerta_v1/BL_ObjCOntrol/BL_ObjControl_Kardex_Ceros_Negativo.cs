using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
   public class BL_ObjControl_Kardex_Ceros_Negativo
    {
        public static object PoblarKardex_Ceros_NegativoSelAll()
        {
            return BL_Utils.BL_Utils_Kardex_Ceros_Negativo.BL_Impl_Kardex_Ceros_Negativo.ObtenerKardex_Ceros_NegativoSelAll();
        }
    }
}
