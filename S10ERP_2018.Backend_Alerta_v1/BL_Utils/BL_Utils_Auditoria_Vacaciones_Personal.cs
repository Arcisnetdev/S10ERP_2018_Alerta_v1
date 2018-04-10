using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Utils
{
   public sealed class BL_Utils_Auditoria_Vacaciones_Personal
    {
        private static BL_Impl_Auditoria_Vacaciones_Personal_Interface _dataInterface;

        public const string IV = "AUPSJB123456";
        public const string Key = "123456AUPSJB";

        public static BL_Impl_Auditoria_Vacaciones_Personal BL_Impl_Auditoria_Planilla_P
        {
            get
            {
                if (_dataInterface == null)
                {
                    _dataInterface = new BL_Impl_Auditoria_Vacaciones_Personal();
                }
                return (BL_Impl_Auditoria_Vacaciones_Personal)_dataInterface;
            }
        }
    }
}
