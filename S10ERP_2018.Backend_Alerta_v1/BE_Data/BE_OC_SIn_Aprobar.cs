using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
    public class BE_OC_SIn_Aprobar
    {
        private string _proyecto;
        private string _nroOrden;
        private string _tipo;
        private string _formaPago;
        private string _moneda;
        private string _valorNeto;
        private string _estadoOC;
        private string _proveedorRUC;
        private string _proveedor;
        private string _lugarEntrega;
        private string _fechaOrden;
        private string _fechaEntrega;
        private string _procedencia;
        private string _centroCompra;
        private string _creacionUsuario;
        private string _actualizacionUsuario;
        private string _fechaEnvioAprobacion;
        private string _usuarioAprobador;
        private string _comprador;
        private string _observacion;

        public BE_OC_SIn_Aprobar()
        { }

        public BE_OC_SIn_Aprobar(string tcProyecto, string tcNroOrden, string tcTipo, string tcFormaPago, string tcMoneda, string tcValorNeto, string tcEstadoOC, string tcProveedorRUC,
            string tcProveedor, string tcLugarEntrega, string tcFechaOrden, string tcFechaEntrega, string tcProcedencia, string tcCentroCompra, string tcCreacionUsuario, string tcActualizacionUsuario,
            string tcFechaEnvioAprobacion, string tcUsuarioAprobador, string tcComprador, string tcObservacion)
        {
            this.Proyecto = tcProyecto;
            this.NroOrden = tcNroOrden;
            this.Tipo = tcTipo;
            this.FormaPago = tcFormaPago;
            this.Moneda = tcMoneda;
            this.ValorNeto = tcValorNeto;
            this.EstadoOC = tcEstadoOC;
            this.ProveedorRUC = tcProveedorRUC;
            this.Proveedor = tcProveedor;
            this.LugarEntrega = tcLugarEntrega;
            this.FechaOrden = tcFechaOrden;
            this.FechaEntrega = tcFechaEntrega;
            this.Procedencia = tcProcedencia;
            this.CentroCompra = tcCentroCompra;
            this.CreacionUsuario = tcCreacionUsuario;
            this.ActualizacionUsuario = tcActualizacionUsuario;
            this.FechaEnvioAprobacion = tcFechaEnvioAprobacion;
            this.UsuarioAprobador = tcUsuarioAprobador;
            this.Comprador = tcComprador;
            this.Observacion = tcObservacion;

        }
        public string Proyecto { get => _proyecto; set => _proyecto = value; }
        public string NroOrden { get => _nroOrden; set => _nroOrden = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string FormaPago { get => _formaPago; set => _formaPago = value; }
        public string Moneda { get => _moneda; set => _moneda = value; }
        public string ValorNeto { get => _valorNeto; set => _valorNeto = value; }
        public string EstadoOC { get => _estadoOC; set => _estadoOC = value; }
        public string ProveedorRUC { get => _proveedorRUC; set => _proveedorRUC = value; }
        public string Proveedor { get => _proveedor; set => _proveedor = value; }
        public string LugarEntrega { get => _lugarEntrega; set => _lugarEntrega = value; }
        public string FechaOrden { get => _fechaOrden; set => _fechaOrden = value; }
        public string FechaEntrega { get => _fechaEntrega; set => _fechaEntrega = value; }
        public string Procedencia { get => _procedencia; set => _procedencia = value; }
        public string CentroCompra { get => _centroCompra; set => _centroCompra = value; }
        public string CreacionUsuario { get => _creacionUsuario; set => _creacionUsuario = value; }
        public string ActualizacionUsuario { get => _actualizacionUsuario; set => _actualizacionUsuario = value; }
        public string FechaEnvioAprobacion { get => _fechaEnvioAprobacion; set => _fechaEnvioAprobacion = value; }
        public string UsuarioAprobador { get => _usuarioAprobador; set => _usuarioAprobador = value; }
        public string Comprador { get => _comprador; set => _comprador = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
    }
}
