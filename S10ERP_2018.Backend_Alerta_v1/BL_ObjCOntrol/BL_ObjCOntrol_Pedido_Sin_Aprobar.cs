using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
   public class BL_ObjCOntrol_Pedido_Sin_Aprobar
    {

        public static object PoblarPedido_Sin_AprobarSelAll()
        {
            return BL_Utils.BL_Utils_Pedido_Sin_Aprobar.BL_Impl_Pedido_Sin_Aprobar.ObtenerPedido_Sin_AprobarSelAll();
        }
    }
}
