﻿using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Utils
{
  public sealed  class BL_Utils_Resultado_Operativo_D
    {

        private static BL_Impl_Resultado_Operativo_D_Interface _dataInterface;

        public const string IV = "AUPSJB123456";
        public const string Key = "123456AUPSJB";

        public static BL_Impl_Resultado_Operativo_D BL_Impl_Resultado_Operativo_D
        {
            get
            {
                if (_dataInterface == null)
                {
                    _dataInterface = new BL_Impl_Resultado_Operativo_D();
                }
                return (BL_Impl_Resultado_Operativo_D)_dataInterface;
            }
        }
    }
}
