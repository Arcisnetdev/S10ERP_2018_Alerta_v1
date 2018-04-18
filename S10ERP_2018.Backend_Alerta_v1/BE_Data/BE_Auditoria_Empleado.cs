using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
   public class BE_Auditoria_Empleado
    {
        private string _codEmp;
        private string _nombreCompleto;
        private string _dNI;
        private string _tipoPlanilla;
        private string _estado;
        private string _cargo;
        private string _fechaIngreso;
        private string _fechaInicioContrato;
        private string _fechaFinContrato;
        private string _fechaCese;
        private string _centroCostos;
        private string _deptoOrganizacion;
        private string _ultimoUsuario;
        private string _ultimaFechaModif;

        public BE_Auditoria_Empleado(string tcCodEmp,string tcNombreCompleto, string tcDNI, string tcTipoPlanilla, string tcEstado, string tcCargo, string tcFechaIngreso, string tcFechaInicioContrato,
            string tcFechaFinContrato, string tcFechaCese, string tcCentoCostos, string tcDptoOrganizacion, string tcUltimoUsuario, string tcUltimaFechaModif)
        {
            this.CodEmp = tcCodEmp;
            this.NombreCompleto = tcNombreCompleto;
            this.DNI = tcDNI;
            this.TipoPlanilla = tcTipoPlanilla;
            this.Estado = tcEstado;
            this.Cargo = tcCargo;
            this.FechaIngreso = tcFechaIngreso;
            this.FechaInicioContrato = tcFechaInicioContrato;
            this.FechaFinContrato = tcFechaFinContrato;
            this.FechaCese = tcFechaCese;
            this.CentroCostos = tcCentoCostos;
            this.DeptoOrganizacion = tcDptoOrganizacion;
            this.UltimoUsuario = tcUltimoUsuario;
            this.UltimaFechaModif = tcUltimaFechaModif;
        }

        public BE_Auditoria_Empleado()
        { }

        public string CodEmp { get => _codEmp; set => _codEmp = value; }
        public string NombreCompleto { get => _nombreCompleto; set => _nombreCompleto = value; }
        public string DNI { get => _dNI; set => _dNI = value; }
        public string TipoPlanilla { get => _tipoPlanilla; set => _tipoPlanilla = value; }
        public string Estado { get => _estado; set => _estado = value; }
        public string Cargo { get => _cargo; set => _cargo = value; }
        public string FechaIngreso { get => _fechaIngreso; set => _fechaIngreso = value; }
        public string FechaInicioContrato { get => _fechaInicioContrato; set => _fechaInicioContrato = value; }
        public string FechaFinContrato { get => _fechaFinContrato; set => _fechaFinContrato = value; }
        public string FechaCese { get => _fechaCese; set => _fechaCese = value; }
        public string CentroCostos { get => _centroCostos; set => _centroCostos = value; }
        public string DeptoOrganizacion { get => _deptoOrganizacion; set => _deptoOrganizacion = value; }
        public string UltimoUsuario { get => _ultimoUsuario; set => _ultimoUsuario = value; }
        public string UltimaFechaModif { get => _ultimaFechaModif; set => _ultimaFechaModif = value; }
    }
}
