using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
   public class BE_Auditoria_Planilla_P
    {
        private string _codigo;
        private string _codUser;
        private string _fecha;
        private string _idItem;
        private string _iP;
        private string _montoLocal;
        private string _montoLocalA;
        private string _nombre;
        private string _cargo;
        private string _centroC;
        private string _gerencia;
        private string _area;

        public BE_Auditoria_Planilla_P()
        {
        }

        public BE_Auditoria_Planilla_P(string tcIdItem, string tcCodUser, string tcCodigo, string tcNombre, string tcMontoLocal, string tcMontoLocalA, string tcIP, string tcFecha, string tcCargo,
            string tcCentroC, string tcArea, string tcGerencia)
        {
            this.IdItem = tcIdItem;
            this.CodUser = tcCodUser;
            this.Codigo = tcCodigo;
            this.Nombre = tcNombre;
            this.MontoLocal = tcMontoLocal;
            this.MontoLocalA = tcMontoLocalA;
            this.IP = tcIP;
            this.Fecha = tcFecha;
            this.CentroC = tcCentroC;
            this.Cargo = tcCargo;
            this.Area = tcArea;
            this.Gerencia = tcGerencia;
        }

        public string Codigo { get => _codigo; set => _codigo = value; }
        public string CodUser { get => _codUser; set => _codUser = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string IdItem { get => _idItem; set => _idItem = value; }
        public string IP { get => _iP; set => _iP = value; }
        public string MontoLocal { get => _montoLocal; set => _montoLocal = value; }
        public string MontoLocalA { get => _montoLocalA; set => _montoLocalA = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Cargo { get => _cargo; set => _cargo = value; }
        public string CentroC { get => _centroC; set => _centroC = value; }
        public string Gerencia { get => _gerencia; set => _gerencia = value; }
        public string Area { get => _area; set => _area = value; }
    }
}
