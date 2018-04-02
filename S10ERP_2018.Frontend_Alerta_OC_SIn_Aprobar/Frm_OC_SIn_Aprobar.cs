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

namespace S10ERP_2018.Frontend_Alerta_OC_SIn_Aprobar
{
    public partial class Frm_OC_SIn_Aprobar : Form
    {
        public Frm_OC_SIn_Aprobar()
        {
            InitializeComponent();
        }

        private void Frm_OC_SIn_Aprobar_Load(object sender, EventArgs e)
        {
            BE_OC_SIn_Aprobars controls = (BE_OC_SIn_Aprobars)BL_ObjControl_OC_SIn_Aprobar.PoblarOC_SIn_AprobarSelAll();

            if (controls.Count > 0)
            {
                this.EnvioAlertaOCSinAprobar();
            }
            this.Dispose();
        }

        private void EnvioAlertaOCSinAprobar()
        {
            DateTime DateEnd = Convert.ToDateTime("31/12/2020").Date;
            DateTime DataStart = DateTime.Now.Date;
            int result = DateTime.Compare(DataStart, DateEnd);
            string diaRes = "Quedan: " + (DateEnd.Day - DataStart.Day) + "  dias de prueba. ";

            MailMessage message = new MailMessage();
            //Lista para envio a Operaciones
            message.To.Add("epariona@siscoperu.com");
            message.To.Add("jgarcia@incot.com.pe");
            message.To.Add("hmonroy@incot.com.pe");
            message.Bcc.Add("alerta@qlabsp.com");
            //message.To.Add("arosales@nexcom.com.pe");
            ////message.Bcc.Add("jcahuana@nexcom.com.pe");
            ////message.Bcc.Add("asilva@nexcom.com.pe");
            ////message.Bcc.Add("klandeo@nexcom.com.pe");
            ////message.Bcc.Add("kvilca@nexcom.com.pe");
            //message.Bcc.Add("jramirez@nexcom.com.pe");

            //Lista para envio a GAF
            //message.Bcc.Add("srondon@nexcom.com.pe");
            //message.Bcc.Add("lperez@nexcom.com.pe");
            //message.Bcc.Add("jguerrero@nexcom.com.pe");

            message.From = new MailAddress("alerta@qlabsp.com", "Ordenes de Compra, pendientes de Aprobación.", Encoding.UTF8);
            //message.From = new MailAddress("alerta@qlabsp.com", diaRes + "  Ordenes de Compra, pendientes de Aprobación.", Encoding.UTF8);
            //message.From = new MailAddress("noresponder@nexcom.com.pe", "Ordenes de Compra, pendientes de Aprobación.", Encoding.UTF8);
            message.Subject = "Alerta de Control -> Ordenes de Compra, pendientes de Aprobación";
            message.SubjectEncoding = Encoding.UTF8;
            //message.Body = this.TextoEnvioAlertaOCSinAprobar();

            if (result <= 0)
            {
                message.Body = this.TextoEnvioAlertaOCSinAprobar();
            }
            else
            {
                message.Body = this.TextoEnvioFinPrueba();
            }
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.ipage.com")
            //SmtpClient client = new SmtpClient("192.168.100.2")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("alerta@qlabsp.com", "Alerta$$123"),
                //Port = 25,
                Host = "pop.ipage.com"
                //Host = "192.168.100.2"
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


        private string TextoEnvioAlertaOCSinAprobar()
        {
            IEnumerator enumerator;
            string str = "<html>";
            str = ((((((((((((((str + "<body><center> " + "<div style='font-size:11px; font-family:Arial; text-align:left; padding:10px; width:850px;'>") +
                "<br><div style='padding-left:30px; padding-right:30px; text-align:justify'><strong>Estimado(a) usuario(a):</strong>" +
                "<br>El listado presentado a continuacion son los que deben ser corroborado en ERP S10.") + "</div><br>" +
                "<div style='font-size:11px; font-family:Arial;background-color:#E8EAEE; padding:20px'>") + "<table width='1300'  cellpadding='3'>" +
                "<tr><td colspan='2'>") + "<hr /> </td></tr>" +
                "<tr><td width='400' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PROYECTO</td>") +
                "<td width='30' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>NRO_ORDEN</td>" +
                "<td width='90' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>TIPO</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>FORMA_PAGO</td>" +
                "<td width='40' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>MONEDA</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>VALOR_NETO</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#FF5733;font-size:8px; font-family:Arial'>ESTADO_OC/S</td>") +
                "<td width='40' valign='top' style='text-align:center;background-color:#DDDDDD; font-size:8px; font-family:Arial'>RUC_PROVEEDOR</td>" +
                "<td width='40' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PROVEEDOR</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>LUGAR_ENTREGA</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>FECHA_ORDEN</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>FECHA_ENTREGA</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PROCEDENCIA</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>CENTRO_COMPRA</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>USUARIO_CREADOR</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>USUARIO_ACTUALIZADOR</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#FF5733;font-size:8px; font-family:Arial'>FECHA_ENVIO_APROBACIÓN</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>USUARIO_APROBADOR</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>COMPRADOR</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>OBSERVACION</td></tr>";
            try
            {
                enumerator = ((IEnumerable)BL_ObjControl_OC_SIn_Aprobar.PoblarOC_SIn_AprobarSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_OC_SIn_Aprobar current = (BE_OC_SIn_Aprobar)enumerator.Current;
                    str = str + "<tr><td width='400' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'>" + current.Proyecto + "</td>";
                    str = str + "<td width='30' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.NroOrden + "</td>";
                    str = str + "<td width='90' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Tipo + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.FormaPago + "</td>";
                    str = str + "<td width='40' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'>" + current.Moneda + "</td>";
                    str = str + "<td width='70' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.ValorNeto + "</td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.EstadoOC + "</td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.ProveedorRUC + "</td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Proveedor + "</td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.LugarEntrega + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.FechaOrden + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.FechaEntrega + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Procedencia + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.CentroCompra + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.CreacionUsuario + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.ActualizacionUsuario + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.FechaEnvioAprobacion + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.UsuarioAprobador + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Comprador + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Observacion + " </td></tr>";
                }
            }
            finally
            {
                //    if (enumerator is IDisposable)
                //    {
                //        (enumerator as IDisposable).Dispose();
                //    }
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
