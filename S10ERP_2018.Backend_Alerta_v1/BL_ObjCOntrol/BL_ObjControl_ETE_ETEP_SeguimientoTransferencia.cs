using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
    public sealed class BL_ObjControl_ETE_ETEP_SeguimientoTransferencia
    {

        public static object PoblarETE_ETEP_SeguimientoTransferenciaSelAll()
        {
            return BL_Utils.BL_Utils_ETE_ETEP_SeguimientoTransferencia.BL_Impl_ETE_ETEP_SeguimientoTransferencia.ObtenerETE_ETEP_SeguimientoTransferenciaSelAll();
        }
    }
}
