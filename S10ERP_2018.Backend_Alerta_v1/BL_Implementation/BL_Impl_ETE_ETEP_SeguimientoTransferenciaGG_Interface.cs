using Microsoft.Practices.EnterpriseLibrary.Data;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
    public abstract  class BL_Impl_ETE_ETEP_SeguimientoTransferenciaGG_Interface
    {

        protected BL_Impl_ETE_ETEP_SeguimientoTransferenciaGG_Interface()
        {
        }

        public abstract BE_ETE_ETEP_SeguimientoTransferenciaGGs ObtenerETE_ETEP_SeguimientoTransferenciaGGSelAll(); //Guias de Almacen pendientes de regularizacion con factura
        public abstract Database BaseInterface { get; }
    }
}

