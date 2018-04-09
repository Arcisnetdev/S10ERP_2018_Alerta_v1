using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
  public  class BL_ObjCOntrol_Pedido_Sin_Atender
    {

        public static object PoblarPedido_Sin_AtenderSelAll()
        {
            return BL_Utils.BL_Utils_Pedido_Sin_Atender.BL_Impl_Pedido_Sin_Aprobar.ObtenerPedido_Sin_AtenderSelAll();
        }
    }
}
