﻿using S10ERP_2018.Backend_Alerta_v1.BE_Data;
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

namespace S10ERP_2018.Frontend_Alerta_Auditoria_Vacaciones_Personal
{
    public partial class Frm_Auditoria_Vacaciones_Personal : Form
    {
        public Frm_Auditoria_Vacaciones_Personal()
        {
            InitializeComponent();
        }

        private void Frm_Auditoria_Vacaciones_Personal_Load(object sender, EventArgs e)
        {
            BE_Auditoria_Vacaciones_Personals controls = (BE_Auditoria_Vacaciones_Personals)BL_ObjControl_Auditoria_Vacaciones_Personal.PoblarAuditoria_Vacaciones_PersonalSelAll();

            if (controls.Count > 0)
            {
                this.EnvioAlertaAuditoriaVacaciones();
                this.Actualizar_Dato_Vacaciones();
            }

            this.Dispose();
        }

        private void EnvioAlertaAuditoriaVacaciones()
        {
            DateTime DateEnd = Convert.ToDateTime("31/12/2018").Date;
            DateTime DataStart = DateTime.Now.Date;
            int result = DateTime.Compare(DataStart, DateEnd);
            string diaRes = "Quedan: " + (DateEnd.Day - DataStart.Day) + "  dias de prueba. ";

            MailMessage message = new MailMessage();
            //Lista para envio a Operaciones
            //message.To.Add("epariona@siscoperu.com");
            //message.To.Add("jgarcia@incot.com.pe");
            //message.To.Add("hmonroy@incot.com.pe");
            //message.Bcc.Add("alerta@qlabsp.com");
            message.To.Add("arosales@nexcom.com.pe");
            ////message.Bcc.Add("jcahuana@nexcom.com.pe");
            ////message.Bcc.Add("asilva@nexcom.com.pe");
            ////message.Bcc.Add("klandeo@nexcom.com.pe");
            ////message.Bcc.Add("kvilca@nexcom.com.pe");
            //message.Bcc.Add("jramirez@nexcom.com.pe");

            //Lista para envio a GAF
            //message.Bcc.Add("srondon@nexcom.com.pe");
            //message.Bcc.Add("lperez@nexcom.com.pe");
            //message.Bcc.Add("jguerrero@nexcom.com.pe");

            //message.From = new MailAddress("alerta@qlabsp.com", "Auditoria de Vacaciones del Personal, verificar en Spring.", Encoding.UTF8);
            message.From = new MailAddress("alerta@qlabsp.com", diaRes + "Auditoria de Vacaciones del Personal, verificar en Spring.", Encoding.UTF8);
            //message.From = new MailAddress("noresponder@nexcom.com.pe", "Auditoria de Vacaciones del Personal, verificar en Spring.", Encoding.UTF8);
            message.Subject = "Alerta de Control -> Auditoria Monto devacaciones del Personal";
            message.SubjectEncoding = Encoding.UTF8;
            //message.Body = this.TextoEnvioAlertaPedidoSinAprobar();
            if (result <= 0)
            {
                message.Body = this.TextoEnvioAlertaVacaciones();
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

        private void Actualizar_Dato_Vacaciones()
        {
            IEnumerator enumerator;
            try
            {
                enumerator = ((IEnumerable)BL_ObjControl_Auditoria_Vacaciones_Personal.PoblarAuditoria_Vacaciones_PersonalSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_Auditoria_Vacaciones_Personal current = (BE_Auditoria_Vacaciones_Personal)enumerator.Current;
                    BL_ObjControl_Auditoria_Vacaciones_Personal.ActualizarAuditoria_Vacaciones_PersonalSelAll(current.IdItem);
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

        private string TextoEnvioAlertaVacaciones()
        {
            IEnumerator enumerator;
            string str = "<html>";
            str = ((((((((str + "<body><center> " + "<div style='font-size:11px; font-family:Arial; text-align:left; padding:10px; width:650px;'>") +
                "<br><div style='padding-left:30px; padding-right:30px; text-align:justify'><strong>Estimado(a) usuario(a):</strong>" +
                "<br>El listado presentado a continuacion son los que deben ser corroborado en ERP SPRING, en las Vacaciones del TRABAJADOR.") +
                "</div><br>" + "<div style='font-size:11px; font-family:Arial;background-color:#E8EAEE; padding:20px'>") + "<table width='730'  cellpadding='7'>" +
                "<tr><td colspan='2'>") + "<hr /> </td></tr>" + "<tr><td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>CODIGO</td>") +
                "<td width='230' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>NOMBRE</td>" +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>PERIODO</td>") +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>DERECHO</td>" +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>UTILIZADO</td>") +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>PENDIENTE</td>" +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>USUARIO</td>") +
                "<td width='80' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>MAQUINA</td>" +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:11px; font-family:Arial'>FECHA</td></tr>";
            try
            {
                enumerator = ((IEnumerable)BL_ObjControl_Auditoria_Vacaciones_Personal.PoblarAuditoria_Vacaciones_PersonalSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_Auditoria_Vacaciones_Personal current = (BE_Auditoria_Vacaciones_Personal)enumerator.Current;
                    str = str + "<tr><td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.Codigo + "</td>";
                    str = str + "<td width='230' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'> " + current.Nombre + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'> " + current.Periodo + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'> " + current.Derecho + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'> " + current.Utilizado + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'> " + current.Pendiente + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.CodUser + "</td>";
                    str = str + "<td width='80' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.IP + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:11px; font-family:Arial;text-align:center;'>" + current.Fecha + "</td></tr>";
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
