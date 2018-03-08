using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
  public  class BL_ObjControl_OC_SIn_Aprobar
    {

        public static object PoblarOC_SIn_AprobarSelAll()
        {
            return BL_Utils.BL_Utils_OC_SIn_Aprobar.BL_Impl_OC_SIn_Aprobar.ObtenerOC_SIn_AprobarSelAll();
        }
    }
}
