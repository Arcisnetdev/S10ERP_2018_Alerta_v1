using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
    public class BE_Kardex_Ceros_Negativo
    {
        private string _proyecto;
        private string _almacen;
        private string _codRecurso;
        private string _recurso;
        private string _unidad;
        private string _fechaGuia;
        private string _nroGuia;
        private string _movimiento;
        private string _moneda;
        private string _cantidad;
        private string _precio;
        private string _stockAnterior;
        private string stockActual;
        private string _proyectoTransferencia;
        private string _almacenTransferencia;

        public BE_Kardex_Ceros_Negativo()
        { }

        public BE_Kardex_Ceros_Negativo(string tcProyecto, string tcAlmaccen, string tcCodRecurso, string tcRecurso, string tcUnidad, string tcFechaGuia, string tcNroGuia,
            string tcMovimiento, string tcMoneda, string tcCantidad, string tcPrecio, string tcStockAnterior, string tcStockActual, string tcProyectoTransferencia, string tcAlmacenTransferencia)
        {
            this.Proyecto = tcProyecto;
            this.Almacen = tcAlmaccen;
            this.CodRecurso = tcCodRecurso;
            this.Recurso = tcRecurso;
            this.Unidad = tcUnidad;
            this.FechaGuia = tcFechaGuia;
            this.NroGuia = tcNroGuia;
            this.Movimiento = tcMovimiento;
            this.Moneda = tcMoneda;
            this.Cantidad = tcCantidad;
            this.Precio = tcPrecio;
            this.StockAnterior = tcStockAnterior;
            this.StockActual = tcStockActual;
            this.ProyectoTransferencia = tcProyectoTransferencia;
            this.AlmacenTransferencia = tcAlmacenTransferencia;


        }

        public string Proyecto { get => _proyecto; set => _proyecto = value; }
        public string Almacen { get => _almacen; set => _almacen = value; }
        public string CodRecurso { get => _codRecurso; set => _codRecurso = value; }
        public string Recurso { get => _recurso; set => _recurso = value; }
        public string Unidad { get => _unidad; set => _unidad = value; }
        public string FechaGuia { get => _fechaGuia; set => _fechaGuia = value; }
        public string NroGuia { get => _nroGuia; set => _nroGuia = value; }
        public string Movimiento { get => _movimiento; set => _movimiento = value; }
        public string Moneda { get => _moneda; set => _moneda = value; }
        public string Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Precio { get => _precio; set => _precio = value; }
        public string StockAnterior { get => _stockAnterior; set => _stockAnterior = value; }
        public string StockActual { get => stockActual; set => stockActual = value; }
        public string ProyectoTransferencia { get => _proyectoTransferencia; set => _proyectoTransferencia = value; }
        public string AlmacenTransferencia { get => _almacenTransferencia; set => _almacenTransferencia = value; }
    }
}
