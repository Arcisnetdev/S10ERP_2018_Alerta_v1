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

namespace S10ERP_2018.Frontend_Alerta_Resultado_Operativo_C
{
    public partial class Frm_Resultado_Operativo_C : Form
    {
        public Frm_Resultado_Operativo_C()
        {
            InitializeComponent();
        }

        private void Frm_Resultado_Operativo_C_Load(object sender, EventArgs e)
        {
            BE_Resultado_Operativo_Cs controls = (BE_Resultado_Operativo_Cs)BL_ObjControl_Resultado_Operativo_C.PoblarResultado_Operativo_CSelAll();

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
            message.To.Add("jramos@incot.com.pe"); // Resultados Operativos
            //message.To.Add("jgarcia@incot.com.pe"); //Pedidos y Compras (Logistica)
            //message.To.Add("hmonroy@incot.com.pe"); //Pedidos y Compras (Logistica)
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

            message.From = new MailAddress("alerta@qlabsp.com","Resultados Operativos.", Encoding.UTF8);
            //message.From = new MailAddress("alerta@qlabsp.com", diaRes + "  Resultados Operativos.", Encoding.UTF8);
            //message.From = new MailAddress("noresponder@nexcom.com.pe", "Resultados Operativos.", Encoding.UTF8);
            message.Subject = "Alerta de Control -> Resultados Operativos";
            message.SubjectEncoding = Encoding.UTF8;
            //message.Body = this.TextoEnvioAlertaPedidoSinAprobar();
            if (result <= 0)
            {
                message.Body = this.TextoEnvioAlertaPedidoSinAprobar();
            }
            else
            {
               // message.Body = this.TextoEnvioFinPrueba();
            }

            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            //message.Attachments.Add(new Attachment(@"C:\devtroce.com.html"));
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
            str = ((str + "<body><center> " + "<div style='font-size:11px; font-family:Arial; text-align:left; padding:10px; width:650px;'>") +
                "<br><div style='padding-left:30px; padding-right:30px; text-align:justify'><strong>Estimado(a) usuario(a):</strong>" +
                "<br>El listado presentado a continuacion son los que deben ser corroborado en ERP S10.") +
                "</div><br><hr />" + "<div style='font-size:11px; font-family:Arial;padding:20px'>";
            try
            {
                enumerator = ((IEnumerable)BL_ObjControl_Resultado_Operativo_C.PoblarResultado_Operativo_CSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    IEnumerator enumerator2;
                    BE_Resultado_Operativo_C current = (BE_Resultado_Operativo_C)enumerator.Current;
                    str = str + "<table cellspacing='0' cellpadding='0' width='605px'><tr><td colspan='3' width='350'></td><td  style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black;background-color:#C5E3ED' width='85'><strong>PRESUPUESTO</strong></td>" +
                        "<td width='85' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black;background-color:#C5E3ED'><strong>PROGRAMADO</strong></td>" +
                        "<td width='85' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black;background-color:#C5E3ED'><strong>VALORIZADO</strong></td>" +
                        "<td width='85' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black;background-color:#C5E3ED'><strong>REAL</strong></td></tr>";
                    str = str + "<tr><td  style='font-size:10px; font-family:Arial;text-align:left;font-weight: bold;border:1px solid black;background-color:#C5D5E9' colspan='3' width='350'>Proyecto:" + current.Des_Proyecto + "</td>";
                    str = str + "<td align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black;background-color:#FFA6A6'> " + current.Presupuesto + "</td>";
                    str = str + "<td align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black;background-color:#FFA6A6'> " + current.Programado + "</td>";
                    str = str + "<td align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black;background-color:#FFA6A6'> " + current.Valorizado + "</td>";
                    str = str + "<td align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black;background-color:#FFA6A6'> " + current.Reall + "</td>";
                    str = str + "</tr><tr><td style='font-size:10px; font-family:Arial;text-align:left;font-weight: bold;border:1px solid black;background-color:#C5D5E9' colspan='3' width='350'>Presupuestos:" + current.TipoPresupuesto + " - " + current.Des_Presupuesto + "</td>";
                    str = str + "<td colspan='4' rowspan='2' style='border:1px solid black'>&nbsp;</td> </tr><tr><td colspan='3' width='350' style='font-size:10px; font-family:Arial;text-align:left;font-weight: bold;border:1px solid black;background-color:#C5D5E9'>Detalle:</td></tr>";
                    try
                    {
                        enumerator2 = ((IEnumerable)BL_ObjControl_Resultado_Operativo_D.PoblarResultado_Operativo_DSelAll(current.CodProyecto, current.CodPresupuesto)).GetEnumerator();
                        while (enumerator2.MoveNext())
                        {
                            BE_Resultado_Operativo_D rod = (BE_Resultado_Operativo_D)enumerator2.Current;
                            str = str + "<tr>";
                            str = str + "<td colspan='3'  width='350' align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:right;border:1px solid black'> " + rod.Recurso + "</td>";
                            str = str + "<td align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black' width='85'> " + rod.Presupuesto + "</td>";
                            str = str + "<td align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black' width='85'> " + rod.Programado + "</td>";
                            str = str + "<td align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black' width='85'> " + rod.Valorizado + "</td>";
                            str = str + "<td align='right' valign='top' style='font-size:10px; font-family:Arial;text-align:center;border:1px solid black' width='85'> " + rod.Reall + "</td></tr>";
                        }
                    }
                    finally
                    {
                        //if (enumerator2 is IDisposable)
                        //{
                        //    (enumerator2 as IDisposable).Dispose();
                        //}
                    }
                    str = str + "</table><br />";
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
