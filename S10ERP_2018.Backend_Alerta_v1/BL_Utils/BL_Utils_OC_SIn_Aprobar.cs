using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Utils
{
   public sealed class BL_Utils_OC_SIn_Aprobar
    {

        private static BL_Impl_OC_SIn_Aprobar_Interface _dataInterface;

        public const string IV = "AUPSJB123456";
        public const string Key = "123456AUPSJB";

        public static BL_Impl_OC_SIn_Aprobar BL_Impl_OC_SIn_Aprobar
        {
            get
            {
                if (_dataInterface == null)
                {
                    _dataInterface = new BL_Impl_OC_SIn_Aprobar();
                }
                return (BL_Impl_OC_SIn_Aprobar)_dataInterface;
            }
        }
    }
}
