using S10ERP_2018.Backend_Alerta_v1.BE_Data;
using S10ERP_2018.Backend_Alerta_v1.BL_ObjCOntrol;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S10ERP_2018.Frontend_Alerta_Auditoria_Empleado
{
    public partial class Frm_Auditoria_Empleado : Form
    {
        public Frm_Auditoria_Empleado()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BE_Auditoria_Empleados controls = (BE_Auditoria_Empleados)BL_ObjControl_Auditoria_Empleado.PoblarAuditoria_EmpleadoSelAll();

            if (controls.Count > 0)
            {
                this.EnvioAlertaAuditoriaAuditoria();
                this.Actualizar_Dato_Empleado();
            }

            this.Dispose();
        }

        private void EnvioAlertaAuditoriaAuditoria()
        {
            DateTime DateEnd = Convert.ToDateTime("31/12/2020").Date;
            DateTime DataStart = DateTime.Now.Date;
            int result = DateTime.Compare(DataStart, DateEnd);
            string diaRes = "Quedan: " + (DateEnd.Day - DataStart.Day) + "  dias de prueba. ";

            MailMessage message = new MailMessage();
            //Lista para envio a Destino
            message.To.Add("mcastillo@nexcom.com.pe");
            message.CC.Add("mloa@nexcom.com.pe");
            message.Bcc.Add("arosales@nexcom.com.pe");
            message.Bcc.Add("odepando@nexcom.com.pe");
            message.Bcc.Add("mbuchanan@nexcom.com.pe");

            //Lista para envio a GAF
            //message.Bcc.Add("srondon@nexcom.com.pe");
            //message.Bcc.Add("lperez@nexcom.com.pe");
            //message.Bcc.Add("jguerrero@nexcom.com.pe");

            //message.From = new MailAddress("alerta@qlabsp.com", "Auditoria de Estado de Personal, verificar en el Spring.", Encoding.UTF8);
            //message.From = new MailAddress("alerta@qlabsp.com", diaRes + "Auditoria de Estado de Personal, verificar en el Spring.", Encoding.UTF8);
            message.From = new MailAddress("noresponder@nexcom.com.pe", "Auditoria de Estado de Personal, verificar en el Spring.", Encoding.UTF8);
            message.Subject = "Alerta de Control -> Auditoria Estado de Personal Spring";
            message.SubjectEncoding = Encoding.UTF8;
            //message.Body = this.TextoEnvioAlertaEmpleado();
            if (result <= 0)
            {
                message.Body = this.TextoEnvioAlertaEmpleado();
            }
            else
            {
                message.Body = this.TextoEnvioFinPrueba();
            }

            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            //SmtpClient client = new SmtpClient("smtp.ipage.com")
            SmtpClient client = new SmtpClient("192.168.100.2")
            {
                //Port = 587,
                //Credentials = new System.Net.NetworkCredential("alerta@qlabsp.com", "Alerta$$123"),
                Port = 25,
                //Host = "pop.ipage.com"
                Host = "192.168.100.2"
            };
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                SmtpException exception = ex;
            }
        }

        private void Actualizar_Dato_Empleado()
        {
            IEnumerator enumerator;
            try
            {
                enumerator = ((IEnumerable)BL_ObjControl_Auditoria_Empleado.PoblarAuditoria_EmpleadoSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_Auditoria_Empleado current = (BE_Auditoria_Empleado)enumerator.Current;
                    BL_ObjControl_Auditoria_Empleado.ActualizarAuditoria_EmpleadoSelAll(current.CodEmp);
                }
            }
            finally
            {
                //if (enumerator is IDisposable)
                //{
                //    (enumerator as IDisposable).Dispose();
                //}
            }
        }

        private string TextoEnvioAlertaEmpleado()
        {
            IEnumerator enumerator;
            string str = "<html>";
            str = (((((((((((str + "<body><center> " + "<div style='font-size:11px; font-family:Arial; text-align:left; padding:10px; width:650px;'>")
                + "<br><div style='padding-left:30px; padding-right:30px; text-align:justify'><strong>Estimado(a) usuario(a):</strong>"
                + "<br>El listado presentado a continuacion son los que deben ser corroborado en ERP SPRING, en el ESTADO DEL TRABAJADOR.")
                + "</div><br>" + "<div style='font-size:11px; font-family:Arial;background-color:#E8EAEE; padding:20px'>") + "<table width='1200'  cellpadding='7'>"
                + "<tr><td colspan='2'>") + "<hr /> </td></tr>" + "<tr><td width='200' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>NOMBRE COMPLETO</td>")
                + "<td width='80' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>DNI</td>"
                + "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>TIPO PLANILLA</td>")
                + "<td width='60' valign='top' style='text-align:center;background-color:#ff3300;font-size:11px; font-family:Arial'>ESTADO</td>"
                + "<td width='200' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>CARGO</td>")
                + "<td width='80' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>FECHA INGRESO</td>"
                + "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>FECHA INICIO CONTRATO</td>")
                + "<td width='80' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>FECHA FIN CONTRATO</td>"
                + "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>FECHA CESE</td>")
                + "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>CENTRO DE COSTO</td>"
                + "<td width='80' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>DEPARTAMENTO</td>")
                + "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>ULTIMO USUARIO</td>" 
                +"<td width='80' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>ULTIMA FECHA MODIFICACION</td></tr>");
            try
            {
                enumerator = ((IEnumerable)BL_ObjControl_Auditoria_Empleado.PoblarAuditoria_EmpleadoSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_Auditoria_Empleado current = (BE_Auditoria_Empleado)enumerator.Current;
                    str = str + "<tr><td width='200' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.NombreCompleto + "</td>";
                    str = str + "<td width='80' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'> " + current.DNI + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'> " + current.TipoPlanilla + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;color:red'> " + current.Estado + "</td>";
                    str = str + "<td width='200' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.Cargo + "</td>";
                    str = str + "<td width='80' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.FechaIngreso + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.FechaInicioContrato + "</td>";
                    str = str + "<td width='80' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.FechaFinContrato + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.FechaCese + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.CentroCostos + "</td>";
                    str = str + "<td width='80' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.DeptoOrganizacion + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.UltimoUsuario + "</td>";
                    str = str + "<td width='80' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.UltimaFechaModif + "</td></tr>";
                }
            }
            finally
            {
                //if (enumerator is IDisposable)
                //{
                //    (enumerator as IDisposable).Dispose();
                //}
            }
            return (((str + "</table>" + "</div>") + "<hr /><div style='font-size:10px; padding-left:30px; padding-right:30px'>" +
             "<strong><em>QLABSP Investors</em></strong><br><br>") +
             //"<strong><em>Nexos Comerciales S.A</em></strong><br><br>") +
             "<strong>P.D:</strong> Este correo es solo para confirmar el estado de recepcion. Agradeceremos no responderlo.</div> </div>" +
            "</center></body></html>");
        }

        private string TextoEnvioFinPrueba()
        {
            string str = "<html>";
            str = ((((str + "<body><center> " + "<div style='font-size:11px; font-family:Arial; text-align:left; padding:10px; width:850px;'>") +
                "<br><div style='padding-left:30px; padding-right:30px; text-align:justify'><strong>Estimado(a) usuario(a):</strong>" +
                "<br>El listado presentado a continuacion son los que deben ser corroborado en ERP S10.") + "</div><br>" +
                "<div style='font-size:11px; font-family:Arial;background-color:#E8EAEE; padding:20px'>") + "<table width='1300'  cellpadding='3'>" +
                "<tr><td colspan='2'>") + "<hr /> </td></tr>" +
              "<td width='700' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>ESTADO_ALERTA</td></tr>";
            try
            {
                {
                    str = str + "<td width='700' valign='top' style='font-size:12px; font-family:Arial;text-align:center;color:red'> " +
                        " Contáctese con soporte a la dirección: arosales@arcisnetdev.com para tener activa la alerta, su período de prueba ha finalizado" + " </td></tr>";
                }
            }
            finally
            {
            }
            return (((str + "</table>" + "</div>") + "<hr /><div style='font-size:10px; padding-left:30px; padding-right:30px'>" +
                "<strong><em>QLABSP Investors</em></strong><br><br>") +
                //"<strong><em>Nexos Comerciales S.A</em></strong><br><br>") +
                "<strong>P.D:</strong> Este correo es solo para confirmar el estado de recepcion. Agradeceremos no responderlo.</div> </div>" +
                "</center></body></html>");
        }

    }
}
