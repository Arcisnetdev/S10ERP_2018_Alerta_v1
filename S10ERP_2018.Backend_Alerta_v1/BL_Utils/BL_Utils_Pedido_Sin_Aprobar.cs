using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Utils
{
   public sealed class BL_Utils_Pedido_Sin_Aprobar
    {

        private static BL_Impl_Pedido_Sin_Aprobar_Interface _dataInterface;

        public const string IV = "AUPSJB123456";
        public const string Key = "123456AUPSJB";

        public static BL_Impl_Pedido_Sin_Aprobar BL_Impl_Pedido_Sin_Aprobar
        {
            get
            {
                if (_dataInterface == null)
                {
                    _dataInterface = new BL_Impl_Pedido_Sin_Aprobar();
                }
                return (BL_Impl_Pedido_Sin_Aprobar)_dataInterface;
            }
        }
    }
}
