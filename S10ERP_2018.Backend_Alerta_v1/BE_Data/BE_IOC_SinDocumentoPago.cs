using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
    public class BE_IOC_SinDocumentoPago
    {
        private string _proyecto;
        private string _nrooc;
        private string _almacen;
        private string _codguia;
        private string _fechaguia;
        private string _nroguiaremision;
        private string _proveedor;
        private string _estadocierre;
        private string _movimiento;
        private string _moneda;
        private string _formadepago;
        private string _parcial;


        public BE_IOC_SinDocumentoPago()
        { }

        public BE_IOC_SinDocumentoPago(string tcProyecto, string tcNroOc, string tcAlmacen, string tcCodGuia, string tcFechaGuia, string tcNroGuiaRemision, string tcProveedor,
            string tcEstadoCierre, string tcMovimiento, string tcMoneda, string tcFormaDePago, string tcParcial)
        {
            this.Proyecto = tcProyecto;
            this.Nrooc = tcNroOc;
            this.Almacen = tcAlmacen;
            this.Codguia = tcCodGuia;
            this.Fechaguia = tcFechaGuia;
            this.Nroguiaremision = tcNroGuiaRemision;
            this.Proveedor = tcProveedor;
            this.Estadocierre = tcEstadoCierre;
            this.Movimiento = tcMovimiento;
            this.Moneda = tcMoneda;
            this.Formadepago = tcFormaDePago;
            this.Parcial = tcParcial;
            
        }

        public string Proyecto { get => _proyecto; set => _proyecto = value; }
        public string Nrooc { get => _nrooc; set => _nrooc = value; }
        public string Almacen { get => _almacen; set => _almacen = value; }
        public string Codguia { get => _codguia; set => _codguia = value; }
        public string Fechaguia { get => _fechaguia; set => _fechaguia = value; }
        public string Nroguiaremision { get => _nroguiaremision; set => _nroguiaremision = value; }
        public string Proveedor { get => _proveedor; set => _proveedor = value; }
        public string Estadocierre { get => _estadocierre; set => _estadocierre = value; }
        public string Movimiento { get => _movimiento; set => _movimiento = value; }
        public string Moneda { get => _moneda; set => _moneda = value; }
        public string Formadepago { get => _formadepago; set => _formadepago = value; }
        public string Parcial { get => _parcial; set => _parcial = value; }
    }
}
