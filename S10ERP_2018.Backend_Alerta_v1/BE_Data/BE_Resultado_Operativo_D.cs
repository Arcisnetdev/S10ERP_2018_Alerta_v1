using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
    public class BE_Resultado_Operativo_D
    {
        private string _grupo;
        private string _recurso;
        private string _presupuesto;
        private string _programado;
        private string _valorizado;
        private string _reall;


        public BE_Resultado_Operativo_D()
        { }

        public BE_Resultado_Operativo_D(string tcGrupo, string tcRecurso, string tcPresupuesto, string tcProgramado, string tcValorizado, string tcReall)
        {
            this.Grupo = tcGrupo;
            this.Recurso = tcRecurso;
            this.Presupuesto = tcPresupuesto;
            this.Programado = tcProgramado;
            this.Valorizado = tcValorizado;
            this.Reall = tcReall;
        }

        public string Grupo { get => _grupo; set => _grupo = value; }
        public string Recurso { get => _recurso; set => _recurso = value; }
        public string Presupuesto { get => _presupuesto; set => _presupuesto = value; }
        public string Programado { get => _programado; set => _programado = value; }
        public string Valorizado { get => _valorizado; set => _valorizado = value; }
        public string Reall { get => _reall; set => _reall = value; }
    }
}
