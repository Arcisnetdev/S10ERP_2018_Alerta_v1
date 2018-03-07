using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
    public class BE_Resultado_Operativo_C
    {
        private string _codProyecto;
        private string _des_Proyecto;
        private string _tipoPresupuesto;
        private string _codPresupuesto;
        private string _des_Presupuesto;
        private string _presupuesto;
        private string _programado;
        private string _valorizado;
        private string _reall;
  
            public BE_Resultado_Operativo_C()
        { }

        public BE_Resultado_Operativo_C(string tcCodProyecto, string tcDes_Proyecto, string tcTipoPresupuesto, string tcCodPresupuesto, string tcDes_Presupuesto,
            string tcPresupuesto, string tcProgramado, string tcValorizado, string tcReall)
        {
            this.CodProyecto = tcCodProyecto;
            this.Des_Proyecto = tcDes_Proyecto;
            this.TipoPresupuesto = tcTipoPresupuesto;
            this.CodPresupuesto = tcCodPresupuesto;
            this.Des_Presupuesto = tcDes_Presupuesto;
            this.Presupuesto = tcPresupuesto;
            this.Programado = tcProgramado;
            this.Valorizado = tcValorizado;
            this.Reall = tcReall;
        }

        public string CodProyecto { get => _codProyecto; set => _codProyecto = value; }
        public string Des_Proyecto { get => _des_Proyecto; set => _des_Proyecto = value; }
        public string TipoPresupuesto { get => _tipoPresupuesto; set => _tipoPresupuesto = value; }
        public string CodPresupuesto { get => _codPresupuesto; set => _codPresupuesto = value; }
        public string Des_Presupuesto { get => _des_Presupuesto; set => _des_Presupuesto = value; }
        public string Presupuesto { get => _presupuesto; set => _presupuesto = value; }
        public string Programado { get => _programado; set => _programado = value; }
        public string Valorizado { get => _valorizado; set => _valorizado = value; }
        public string Reall { get => _reall; set => _reall = value; }
    }
}
