using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10ERP_2018.Backend_Alerta_v1.BE_Data
{
   public class BE_Auditoria_Vacaciones_Personal
    {
        private string _codigo;
        private string _codUser;
        private string _derecho;
        private string _fecha;
        private string _idItem;
        private string _iP;
        private string _nombre;
        private string _pendiente;
        private string _periodo;
        private string _utilizado;

        public BE_Auditoria_Vacaciones_Personal()
        {
        }

        public BE_Auditoria_Vacaciones_Personal(string tcIdItem, string tcCodUser, string tcCodigo, string tcNombre, string tcPeriodo, string tcDerecho, string tcUtilizado, string tcPendiente, string tcIP, string tcFecha)
        {
            this.IdItem = tcIdItem;
            this.CodUser = tcCodUser;
            this.Codigo = tcCodigo;
            this.Nombre = tcNombre;
            this.Periodo = tcPeriodo;
            this.Derecho = tcDerecho;
            this.Utilizado = tcUtilizado;
            this.Pendiente = tcPendiente;
            this.IP = tcIP;
            this.Fecha = tcFecha;
        }

        public string Codigo { get => _codigo; set => _codigo = value; }
        public string CodUser { get => _codUser; set => _codUser = value; }
        public string Derecho { get => _derecho; set => _derecho = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string IdItem { get => _idItem; set => _idItem = value; }
        public string IP { get => _iP; set => _iP = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Pendiente { get => _pendiente; set => _pendiente = value; }
        public string Periodo { get => _periodo; set => _periodo = value; }
        public string Utilizado { get => _utilizado; set => _utilizado = value; }
    }
}
