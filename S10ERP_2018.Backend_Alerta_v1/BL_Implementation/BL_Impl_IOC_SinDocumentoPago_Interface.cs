using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
   public abstract class BL_Impl_IOC_SinDocumentoPago_Interface
    {
        protected BL_Impl_IOC_SinDocumentoPago_Interface()
        {
        }

        public abstract BE_IOC_SinDocumentoPagos ObtenerGuiasSinFacturarSelAll(); //Guias de Almacen pendientes de regularizacion con factura
        public abstract Database BaseInterface { get; }
    }
}
