using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
   public class BL_ObjControl_Auditoria_Empleado
    {
        public static object PoblarAuditoria_EmpleadoSelAll()
        {
            return BL_Utils.BL_Utils_Auditoria_Empleado.BL_Impl_Auditoria_Empleado.Obtener_Auditoria_EmpleadoSelAll();
        }

        public static object ActualizarAuditoria_EmpleadoSelAll(string IdItem)
        {
            return BL_Utils.BL_Utils_Auditoria_Empleado.BL_Impl_Auditoria_Empleado.Actualizar_Auditoria_EmpleadoSelAll(IdItem);
        }
    }
}
