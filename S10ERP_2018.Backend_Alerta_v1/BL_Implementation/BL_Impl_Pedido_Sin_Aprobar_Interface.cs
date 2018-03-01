using Microsoft.Practices.EnterpriseLibrary.Data;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
  public abstract  class BL_Impl_Pedido_Sin_Aprobar_Interface
    {

        protected BL_Impl_Pedido_Sin_Aprobar_Interface()
        {
        }

        public abstract BE_Pedido_Sin_Aprobars ObtenerPedido_Sin_AprobarSelAll(); //Guias de Almacen pendientes de regularizacion con factura
        public abstract Database BaseInterface { get; }
    }
}
