using Microsoft.Practices.EnterpriseLibrary.Data;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
   public abstract class BL_Impl_Auditoria_Empleado_Interface
    {
        protected BL_Impl_Auditoria_Empleado_Interface()
        { }

        public abstract BE_Auditoria_Empleados Obtener_Auditoria_EmpleadoSelAll(); //Leer la tabla de auditoria
        public abstract bool Actualizar_Auditoria_EmpleadoSelAll(string IdItem); //Actualizar la tabla de auditoria
        public abstract Database BaseInterface { get; }
    }
}
