using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
  public  class BE_Pedido_Sin_Atender
    {

        private string _proyecto;
        private string _almacen;
        private string _nroPedido;
        private string _estado;
        private string _fechaPedido;
        private string _creacionFecha;
        private string _actualizacionFecha;
        private string _fechaAprobacion;
        private string _tiempoEntrega;
        private string _creacionUsuario;
        private string _usuarioA;
        private string _usuario;
        private string _codPedidoInterno;
        private string _ordenProduccion;
        private string _desEstadoCotizacion;
        private string _desEstadoOrdenCompra;
        private string _desEstadoAlmacen;
        private string _centroCompra;
        private string _observacion;

        public BE_Pedido_Sin_Atender()
        { }

        public BE_Pedido_Sin_Atender(string tcProyecto, string tcAlmacen, string tcNroPedido, string tcEstado, string tcFechaPedido, string tcCreacionFecha, string tcActualizacionFecha,
            string tcFechaAprobacion, string tcTiempoEntrega, string tcCreacionUsuario, string tcUsuarioA, string tcUsuario, string tcCodPedidoInterno, string tcOrdenProduccion, string tcDesEstadoCotizacion,
            string tcDesEstadoOrdenCompra, string tcDesEstadoAlmacen, string tcCentroCompra, string tcObservacion)
        {
            this.Proyecto = tcProyecto;
            this.Almacen = tcAlmacen;
            this.NroPedido = tcNroPedido;
            this.Estado = tcEstado;
            this.FechaPedido = tcFechaPedido;
            this.CreacionFecha = tcCreacionFecha;
            this.ActualizacionFecha = tcActualizacionFecha;
            this.FechaAprobacion = tcFechaAprobacion;
            this.TiempoEntrega = tcTiempoEntrega;
            this.CreacionUsuario = tcCreacionUsuario;
            this.UsuarioA = tcUsuarioA;
            this.Usuario = tcUsuario;
            this.CodPedidoInterno = tcCodPedidoInterno;
            this.OrdenProduccion = tcOrdenProduccion;
            this.DesEstadoCotizacion = tcDesEstadoCotizacion;
            this.DesEstadoOrdenCompra = tcDesEstadoOrdenCompra;
            this.DesEstadoAlmacen = tcDesEstadoAlmacen;
            this.CentroCompra = tcCentroCompra;
            this.Observacion = tcObservacion;


        }
        public string Proyecto { get => _proyecto; set => _proyecto = value; }
        public string Almacen { get => _almacen; set => _almacen = value; }
        public string NroPedido { get => _nroPedido; set => _nroPedido = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string FechaPedido { get => _fechaPedido; set => _fechaPedido = value; }
        public string CreacionFecha { get => _creacionFecha; set => _creacionFecha = value; }
        public string ActualizacionFecha { get => _actualizacionFecha; set => _actualizacionFecha = value; }
        public string FechaAprobacion { get => _fechaAprobacion; set => _fechaAprobacion = value; }
        public string TiempoEntrega { get => _tiempoEntrega; set => _tiempoEntrega = value; }
        public string CreacionUsuario { get => _creacionUsuario; set => _creacionUsuario = value; }
        public string UsuarioA { get => _usuarioA; set => _usuarioA = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string CodPedidoInterno { get => _codPedidoInterno; set => _codPedidoInterno = value; }
        public string OrdenProduccion { get => _ordenProduccion; set => _ordenProduccion = value; }
        public string DesEstadoCotizacion { get => _desEstadoCotizacion; set => _desEstadoCotizacion = value; }
        public string DesEstadoOrdenCompra { get => _desEstadoOrdenCompra; set => _desEstadoOrdenCompra = value; }
        public string DesEstadoAlmacen { get => _desEstadoAlmacen; set => _desEstadoAlmacen = value; }
        public string CentroCompra { get => _centroCompra; set => _centroCompra = value; }
        public string Observacion { get => _observacion; set => _observacion = value; }
    }
}
