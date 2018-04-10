using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
   public class BL_ObjControl_Auditoria_Vacaciones_Personal
    {
        public static object PoblarAuditoria_Vacaciones_PersonalSelAll()
        {
            return BL_Utils.BL_Utils_Auditoria_Vacaciones_Personal.BL_Impl_Auditoria_Planilla_P.Obtener_Auditoria_Vacaciones_PersonalSelAll();
        }

        public static object ActualizarAuditoria_Vacaciones_PersonalSelAll(string IdItem)
        {
            return BL_Utils.BL_Utils_Auditoria_Vacaciones_Personal.BL_Impl_Auditoria_Planilla_P.Actualizar_Vacaciones_PersonalSelAll(IdItem);
        }
    }
}
