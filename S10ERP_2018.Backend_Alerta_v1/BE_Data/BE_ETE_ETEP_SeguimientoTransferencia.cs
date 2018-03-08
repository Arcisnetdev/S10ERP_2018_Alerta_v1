using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
    public class BE_ETE_ETEP_SeguimientoTransferencia
    {
        private string _proyecto;
        private string _almacen;
        private string _codGuia;
        private string _fechaGuia;
        private string _serieDocumento;
        private string _nroDocumento;
        private string _movimientoOrigen;
        private string _estadoCierre;
        private string _codRecurso;
        private string _recurso;
        private string _simbolo;
        private string _parcial;
        private string _codPedido;
        private string _proyectoDestino;
        private string _codGuiaRelacion;
        private string _creacionUsuario;
        private string _creacionFecha;
        private string _actualizacionUsuario;
        private string _actualizacionFecha;
        private string _ano;


        public BE_ETE_ETEP_SeguimientoTransferencia()
        { }

        public BE_ETE_ETEP_SeguimientoTransferencia(string tcProyecto, string tcAlmacen, string tcCodGuia, string tcFechaGuia, string tcSerieDocumento, string tcNroDocumento, string tcMovimientoOrigen,
            string tcEstadoCierre, string tcCodRecurso, string tcRecurso, string tcSimbolo, string tcParcial, string tcCodPedido, string tcProyectoDestino, string tcCodGuiaRelacion, string tcCreacionUsuario,
            string tcCreacionFecha, string tcActualizacionUsuario, string tcActualizacionFecha, string tcAno)
        {
            this.Proyecto = tcProyecto;
            this.Almacen = tcAlmacen;
            this.CodGuia = tcCodGuia;
            this.FechaGuia = tcFechaGuia;
            this.SerieDocumento = tcSerieDocumento;
            this.NroDocumento = tcNroDocumento;
            this.MovimientoOrigen = tcMovimientoOrigen;
            this.EstadoCierre = tcEstadoCierre;
            this.CodRecurso = tcCodRecurso;
            this.Recurso = tcRecurso;
            this.Simbolo = tcSimbolo;
            this.Parcial = tcParcial;
            this.CodPedido = tcCodPedido;
            this.ProyectoDestino = tcProyectoDestino;
            this.CodGuiaRelacion = tcCodGuiaRelacion;
            this.CreacionUsuario = tcCreacionUsuario;
            this.CreacionFecha = tcCreacionFecha;
            this.ActualizacionUsuario = tcActualizacionUsuario;
            this.ActualizacionFecha = tcActualizacionFecha;
            this.Ano = tcAno;

        }


        public string Proyecto { get => _proyecto; set => _proyecto = value; }
        public string Almacen { get => _almacen; set => _almacen = value; }
        public string CodGuia { get => _codGuia; set => _codGuia = value; }
        public string FechaGuia { get => _fechaGuia; set => _fechaGuia = value; }
        public string SerieDocumento { get => _serieDocumento; set => _serieDocumento = value; }
        public string NroDocumento { get => _nroDocumento; set => _nroDocumento = value; }
        public string MovimientoOrigen { get => _movimientoOrigen; set => _movimientoOrigen = value; }
        public string EstadoCierre { get => _estadoCierre; set => _estadoCierre = value; }
        public string CodRecurso { get => _codRecurso; set => _codRecurso = value; }
        public string Recurso { get => _recurso; set => _recurso = value; }
        public string Simbolo { get => _simbolo; set => _simbolo = value; }
        public string Parcial { get => _parcial; set => _parcial = value; }
        public string CodPedido { get => _codPedido; set => _codPedido = value; }
        public string ProyectoDestino { get => _proyectoDestino; set => _proyectoDestino = value; }
        public string CodGuiaRelacion { get => _codGuiaRelacion; set => _codGuiaRelacion = value; }
        public string CreacionUsuario { get => _creacionUsuario; set => _creacionUsuario = value; }
        public string CreacionFecha { get => _creacionFecha; set => _creacionFecha = value; }
        public string ActualizacionUsuario { get => _actualizacionUsuario; set => _actualizacionUsuario = value; }
        public string ActualizacionFecha { get => _actualizacionFecha; set => _actualizacionFecha = value; }
        public string Ano { get => _ano; set => _ano = value; }
    }
}
