using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;

namespace S10ERP_2018.Backend_Alerta_v1.BL_Utils
{
    public sealed class BL_Utils_IOC_SinDocumentoPago
    {
        private static BL_Impl_IOC_SinDocumentoPago_Interface _dataInterface;

        public const string IV = "AUPSJB123456";
        public const string Key = "123456AUPSJB";

        public static BL_Impl_IOC_SinDocumentoPago BL_Impl_IOC_SinDocumentoPago
        {
            get
            {
                if (_dataInterface == null)
                {
                    _dataInterface = new BL_Impl_IOC_SinDocumentoPago();
                }
                return (BL_Impl_IOC_SinDocumentoPago)_dataInterface;
            }
        }
    }


}
