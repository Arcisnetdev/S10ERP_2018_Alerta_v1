using Microsoft.Practices.EnterpriseLibrary.Data;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
   public abstract class BL_Impl_Kardex_Ceros_Negativo_Interface
    {
        protected BL_Impl_Kardex_Ceros_Negativo_Interface()
        {
        }

        public abstract BE_Kardex_Ceros_Negativos ObtenerKardex_Ceros_NegativoSelAll(); //Guias de Almacen pendientes de regularizacion con factura
        public abstract Database BaseInterface { get; }
    }
}
