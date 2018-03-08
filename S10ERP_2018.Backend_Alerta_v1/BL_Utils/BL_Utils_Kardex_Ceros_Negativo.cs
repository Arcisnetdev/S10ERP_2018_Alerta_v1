using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Utils
{
    class BL_Utils_Kardex_Ceros_Negativo
    {

        private static BL_Impl_Kardex_Ceros_Negativo_Interface _dataInterface;

        public const string IV = "AUPSJB123456";
        public const string Key = "123456AUPSJB";

        public static BL_Impl_Kardex_Ceros_Negativo BL_Impl_Kardex_Ceros_Negativo
        {
            get
            {
                if (_dataInterface == null)
                {
                    _dataInterface = new BL_Impl_Kardex_Ceros_Negativo();
                }
                return (BL_Impl_Kardex_Ceros_Negativo)_dataInterface;
            }
        }
    }

}

