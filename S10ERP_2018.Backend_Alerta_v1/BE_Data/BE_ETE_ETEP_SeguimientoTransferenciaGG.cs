using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
  public  class BE_ETE_ETEP_SeguimientoTransferenciaGG
    {
        private string _descripcion;
        private string _estadoProyecto;
        private string _totalPendiente;
        private string _proyectoDestino;

        public BE_ETE_ETEP_SeguimientoTransferenciaGG()
        { }

        public BE_ETE_ETEP_SeguimientoTransferenciaGG(string tcDescripcion, string tcEstadoProyecto,
            string tcTotalPendiente, string tcProyectoDestino)
        {
            this.Descripcion = tcDescripcion;
            this.EstadoProyecto = tcEstadoProyecto;
            this.TotalPendiente = tcTotalPendiente;
            this.ProyectoDestino = tcProyectoDestino;
        }

        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public string EstadoProyecto { get => _estadoProyecto; set => _estadoProyecto = value; }
        public string TotalPendiente { get => _totalPendiente; set => _totalPendiente = value; }
        public string ProyectoDestino { get => _proyectoDestino; set => _proyectoDestino = value; }
    }
}
