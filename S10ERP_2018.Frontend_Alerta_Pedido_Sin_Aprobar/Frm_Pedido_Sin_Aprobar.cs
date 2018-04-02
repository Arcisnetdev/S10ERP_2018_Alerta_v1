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

namespace S10ERP_2018.Frontend_Alerta_Pedido_Sin_Aprobar
{
    public partial class Frm_Pedido_Sin_Aprobar : Form
    {
        public Frm_Pedido_Sin_Aprobar()
        {
            InitializeComponent();
        }

        private void Frm_Pedido_Sin_Aprobar_Load(object sender, EventArgs e)
        {
            BE_Pedido_Sin_Aprobars controls = (BE_Pedido_Sin_Aprobars)BL_ObjCOntrol_Pedido_Sin_Aprobar.PoblarPedido_Sin_AprobarSelAll();

            if (controls.Count > 0)
            {
                this.EnvioAlertaPedidoSinAprobar();
            }
            this.Dispose();
        }


        private void EnvioAlertaPedidoSinAprobar()
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

            message.From = new MailAddress("alerta@qlabsp.com", "Pedidos de Compra, pendientes de Aprobar, Observados y No Aprobados.", Encoding.UTF8);
            //message.From = new MailAddress("alerta@qlabsp.com", diaRes + "  Pedidos de Compra, pendientes de Aprobar, Observados y No Aprobados.", Encoding.UTF8);
            //message.From = new MailAddress("noresponder@nexcom.com.pe", "Pedidos de Compra, pendientes de Aprobar, Observados y No Aprobados.", Encoding.UTF8);
            message.Subject = "Alerta de Control -> Pedidos de Compra, pendientes de Aprobar, Observados y No Aprobados";
            message.SubjectEncoding = Encoding.UTF8;
            //message.Body = this.TextoEnvioAlertaPedidoSinAprobar();
            if (result <= 0)
            {
                message.Body = this.TextoEnvioAlertaPedidoSinAprobar();
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


        private string TextoEnvioAlertaPedidoSinAprobar()
        {
            IEnumerator enumerator;
            string str = "<html>";
            str = (((((((((((((str + "<body><center> " + "<div style='font-size:11px; font-family:Arial; text-align:left; padding:10px; width:850px;'>") +
                "<br><div style='padding-left:30px; padding-right:30px; text-align:justify'><strong>Estimado(a) usuario(a):</strong>" +
                "<br>El listado presentado a continuacion son los que deben ser corroborado en ERP S10.") + "</div><br>" +
                "<div style='font-size:11px; font-family:Arial;background-color:#E8EAEE; padding:20px'>") + "<table width='1300'  cellpadding='3'>" +
                "<tr><td colspan='2'>") + "<hr /> </td></tr>" +
                "<tr><td width='400' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PROYECTO</td>") +
                "<td width='30' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>ALMACEN</td>" +
                "<td width='90' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>NROPEDIDO</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#FF5733;font-size:8px; font-family:Arial'>ESTADO</td>" +
                "<td width='40' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>FECHA_PEDIDO</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>FECHA_CREACION</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>FECHA_ACTUALIZACION</td>") +
                "<td width='40' valign='top' style='text-align:center;background-color:#DDDDDD; font-size:8px; font-family:Arial'>FECHA_APROBACION</td>" +
                "<td width='40' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>TIEMPO_ENTREGA</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>USUARIO_CREADOR</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>USUARIO_APROBADOR</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>USUARIO_ACTUALIZADOR</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>NROPEDIDO_INTERNO</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>ORDEN_PRODUCCION</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#FF5733;font-size:8px; font-family:Arial'>ESTADO_COTIZACION</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#FF5733;font-size:8px; font-family:Arial'>ESTADO_ORDEN_COMPRA</td>" +
                "<td width='180' valign='top' style='text-align:center;background-color:#FF5733;font-size:8px; font-family:Arial'>ESTADO_ALMACEN</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>CENTRO_COMPRA</td>" +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>OBSERVACION</td></tr>";
            try
            {
                enumerator = ((IEnumerable)BL_ObjCOntrol_Pedido_Sin_Aprobar.PoblarPedido_Sin_AprobarSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_Pedido_Sin_Aprobar current = (BE_Pedido_Sin_Aprobar)enumerator.Current;
                    str = str + "<tr><td width='400' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'>" + current.Proyecto + "</td>";
                    str = str + "<td width='30' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Almacen + "</td>";
                    str = str + "<td width='90' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.NroPedido + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.Estado + "</td>";
                    str = str + "<td width='40' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'>" + current.FechaPedido + "</td>";
                    str = str + "<td width='70' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.CreacionFecha + "</td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.ActualizacionFecha + "</td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.FechaAprobacion + "</td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.TiempoEntrega + "</td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.CreacionUsuario + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.UsuarioA + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Usuario + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.CodPedidoInterno + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.OrdenProduccion + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.DesEstadoCotizacion + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.DesEstadoOrdenCompra + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.DesEstadoAlmacen + " </td>";
                    str = str + "<td width='180' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.CentroCompra + " </td>";
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

