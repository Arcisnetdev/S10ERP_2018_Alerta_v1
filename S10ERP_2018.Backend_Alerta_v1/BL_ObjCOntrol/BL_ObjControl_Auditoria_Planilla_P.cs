using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
  public  class BL_ObjControl_Auditoria_Planilla_P
    {
        public static object PoblarAuditoria_Planilla_PSelAll()
        {
            return BL_Utils.BL_Utils_Auditoria_Planilla_P.BL_Impl_Auditoria_Planilla_P.Obtener_Auditoria_Planilla_PSelAll();
        }

        public static object ActualizarAuditoria_Planilla_PSelAll(string IdItem)
        {
            return BL_Utils.BL_Utils_Auditoria_Planilla_P.BL_Impl_Auditoria_Planilla_P.Actualizar_Auditoria_Planilla_PSalarioPSelAll(IdItem);
        }


    }
}
