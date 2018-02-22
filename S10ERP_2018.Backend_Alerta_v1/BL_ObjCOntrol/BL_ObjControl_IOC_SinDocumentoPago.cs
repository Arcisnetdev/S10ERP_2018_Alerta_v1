namespace S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol
{
    public  class BL_ObjControl_IOC_SinDocumentoPago
    {
        public static object PoblarGuiasSinFacturarSelAll()
        {
            return BL_Utils.BL_Utils_IOC_SinDocumentoPago.BL_Impl_IOC_SinDocumentoPago.ObtenerGuiasSinFacturarSelAll();
        }

    }
}
