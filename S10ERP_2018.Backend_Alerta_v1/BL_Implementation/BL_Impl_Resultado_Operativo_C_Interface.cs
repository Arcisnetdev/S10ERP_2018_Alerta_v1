using Microsoft.Practices.EnterpriseLibrary.Data;
using S10ERP_2018.Backend_Alerta_v1.BE_Data;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Implementation
{
    public abstract  class BL_Impl_Resultado_Operativo_C_Interface
    {
        protected BL_Impl_Resultado_Operativo_C_Interface()
        {
        }

        public abstract BE_Resultado_Operativo_Cs ObtenerResultado_Operativo_CSelAll(); //Guias de Almacen pendientes de regularizacion con factura
        public abstract Database BaseInterface { get; }
    }
}

