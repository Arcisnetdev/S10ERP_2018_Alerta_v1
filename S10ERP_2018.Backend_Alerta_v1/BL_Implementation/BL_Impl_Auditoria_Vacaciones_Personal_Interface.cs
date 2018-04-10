using Microsoft.Practices.EnterpriseLibrary.Data;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
   public abstract class BL_Impl_Auditoria_Vacaciones_Personal_Interface
    {
        protected BL_Impl_Auditoria_Vacaciones_Personal_Interface()
        { }

        public abstract BE_Auditoria_Vacaciones_Personals Obtener_Auditoria_Vacaciones_PersonalSelAll(); //Leer la tabla de auditoria
        public abstract bool Actualizar_Vacaciones_PersonalSelAll(string IdItem); //Actualizar la tabla de auditoria
        public abstract Database BaseInterface { get; }
    }
}
