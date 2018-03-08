using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Utils
{
   public sealed class BL_Utils_ETE_ETEP_SeguimientoTransferencia
    {

        private static BL_Impl_ETE_ETEP_SeguimientoTransferencia_Interface _dataInterface;

        public const string IV = "AUPSJB123456";
        public const string Key = "123456AUPSJB";

        public static BL_Impl_ETE_ETEP_SeguimientoTransferencia BL_Impl_ETE_ETEP_SeguimientoTransferencia
        {
            get
            {
                if (_dataInterface == null)
                {
                    _dataInterface = new BL_Impl_ETE_ETEP_SeguimientoTransferencia();
                }
                return (BL_Impl_ETE_ETEP_SeguimientoTransferencia)_dataInterface;
            }
        }
    }
}
