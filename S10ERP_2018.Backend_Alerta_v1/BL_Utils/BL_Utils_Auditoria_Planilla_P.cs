using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Utils
{
  public sealed class BL_Utils_Auditoria_Planilla_P
    {

        private static BL_Impl_Auditoria_Planilla_P_Interface _dataInterface;

        public const string IV = "AUPSJB123456";
        public const string Key = "123456AUPSJB";

        public static BL_Impl_Auditoria_Planilla_P BL_Impl_Auditoria_Planilla_P
        {
            get
            {
                if (_dataInterface == null)
                {
                    _dataInterface = new BL_Impl_Auditoria_Planilla_P();
                }
                return (BL_Impl_Auditoria_Planilla_P)_dataInterface;
            }
        }
    }
}
