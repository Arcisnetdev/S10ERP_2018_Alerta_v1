using S10ERP_2018.Backend_Alerta_v1.BE_Data;
using S10ERP_2018.Backend_Alerta_v1.BL_Implementation;
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

namespace S10ERP_2018.Frontend_Alerta_ETE_ETEP_SeguimientoTransf
{
    public partial class Frm_SeguimientoTransferencia : Form
    {
        public Frm_SeguimientoTransferencia()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BE_ETE_ETEP_SeguimientoTransferencias controls = (BE_ETE_ETEP_SeguimientoTransferencias)BL_ObjControl_ETE_ETEP_SeguimientoTransferencia.PoblarETE_ETEP_SeguimientoTransferenciaSelAll();

            if (controls.Count > 0)
            {
                this.EnvioAlertaTransferencias();
            }
            this.Dispose();

        }

        void EnvioAlertaTransferencias()
        {
            MailMessage message = new MailMessage();
            //Lista para enviar a Operaciones
            message.Bcc.Add("arosales@nexcom.com.pe");
            message.To.Add("mvalencia@nexcom.com.pe");
            message.To.Add("jcahuana@nexcom.com.pe");
            message.CC.Add("personal_almacen@nexcom.com.pe");

            //Lista para enviar a GAF
            message.To.Add("lperez@nexcom.com.pe");
            message.CC.Add("scelestino@nexcom.com.pe");
            //message.CC.Add("odepando@nexcom.com.pe");
            //message.CC.Add("mbuchanan@nexcom.com.pe");

            message.From = new MailAddress("noresponder@nexcom.com.pe", "Movimientos de Almacen ETE y ETEP Pendientes de Ingreso Proyecto destino.", Encoding.UTF8);
            message.Subject = "Alerta de Control -> Movimientos de Almacen ETE y ETEP Pendientes de Ingreso Proyecto destino.";
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = this.ContenidoAlertaTransf();
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("192.168.100.2")
            {
                Port = 25,
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



        private string ContenidoAlertaTransf()
        {
            IEnumerator enumerator;
            string str = "<html>";
            str = (((((str + "<body><center> " + "<div style='font-size:11px; font-family:Arial; text-align:left; padding:10px; width:800px;'>") +
                "<br><div style='padding-left:30px; padding-right:30px; text-align:justify'><strong>Estimado(a) usuario(a):</strong>" +
                "<br>El listado presentado a continuacion son los que deben ser corroborado en ERP S10.") + "</div><br>" +
                "<div style='font-size:11px; font-family:Arial;background-color:#E8EAEE; padding:20px'>") + "<table width='2200'  cellpadding='2'>" +
                "<tr><td width='880' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PROYECTO_ORIGEN</td>") +
                "<td width='80' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>VALORIZADO (S/.)</td>" +
                "<td width='80' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>ESTADO_PROYECTO</td>") +
                "<td width='880' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PROYECTO_DESTINO</td></tr>";
            try
            {
                enumerator = ((IEnumerable)BL_OBjControl_ETE_ETEP_SeguimientoTransferenciaGG.PoblarETE_ETEP_SeguimientoTransferenciaGGSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_ETE_ETEP_SeguimientoTransferenciaGG current = (BE_ETE_ETEP_SeguimientoTransferenciaGG)enumerator.Current;
                    str = str + "<tr><td width='880' valign='top' style='font-size:8px; font-family:Arial;text-align:left;color:#000000'>" + current.Descripcion + "</td>";
                    str = str + "<td width='80' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.TotalPendiente + "</td>";
                    str = str + "<td width='80' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.EstadoProyecto + "</td>";
                    str = str + "<td width='880' valign='top' style='font-size:8px; font-family:Arial;text-align:left;color:#000000'>" + current.ProyectoDestino + "</td></tr>";
                }
            }
            finally
            {
                //if (enumerator is IDisposable)
                //{
                //    (enumerator as IDisposable).Dispose();
                //}
            }
            str = (((((((((((((((str + "</table>") + "</div>" + "<hr /> </td></tr>") + "<table width='2200'  cellpadding='2'>" +
                "<tr><td colspan='7'>") + "</td></tr>" + "<tr><td colspan='7'>") + "</div><br>" +
                "<div style='font-size:11px; font-family:Arial;background-color:#E8EAEE; padding:20px'>") +
                "<tr><td width='100' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-bottom-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>Proyecto</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>Almacen</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>CodGuia</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>FechaGuia</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>SerieDocumento</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>NroDocumento</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>MovimientoOrigen</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>EstadoCierre</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>CodigoRecurso</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>Recurso</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>Simbolo</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>Parcial</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>CodPedido</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>ProyectoDestino</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#DF0101;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>CodGuiaRelacion</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>CreacionUsuario</td>") +
                "<td width='100' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>CreacionFecha</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>ActualizacionUsuario</td>") +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>ActualizacionFecha</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#ECF9FF;font-size:8px; font-family:Arial;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'>Año</td></tr>"); 
            try
            {
                enumerator = ((IEnumerable)BL_ObjControl_ETE_ETEP_SeguimientoTransferencia.PoblarETE_ETEP_SeguimientoTransferenciaSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_ETE_ETEP_SeguimientoTransferencia current = (BE_ETE_ETEP_SeguimientoTransferencia)enumerator.Current;
                    str = str + "<tr><td width='100' valign='top' style='font-size:8px; font-family:Arial;text-align:left;border-color:#999;border-left-style: dashed;border-left-width:1px;border-bottom-style: dashed;border-bottom-width:1px'> " + current.Proyecto + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'> " + current.Almacen + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'> " + current.CodGuia + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.FechaGuia + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.SerieDocumento + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.NroDocumento + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'> " + current.MovimientoOrigen + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'> " + current.EstadoCierre + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'> " + current.CodRecurso + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'> " + current.Recurso + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'> " + current.Simbolo + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'> " + current.Parcial + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.CodPedido + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.ProyectoDestino + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.CodGuiaRelacion + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.CreacionUsuario + "</td>";
                    str = str + "<td width='100' valign='top' style='font-size:8px; font-family:Arial;text-align:left;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.CreacionFecha + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.ActualizacionUsuario + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.ActualizacionFecha + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;border-color:#999;border-bottom-style: dashed;border-bottom-width:1px'>" + current.Ano + "</td></tr>";
                }
            }
            finally
            {
                //if (enumerator2 is IDisposable)
                //{
                //    (enumerator2 as IDisposable).Dispose();
                //}
            }
            return (((str + "</table>" + "</div>") + "<hr /><div style='font-size:10px; padding-left:30px; padding-right:30px'>" +
                "<strong><em>Nexos Comerciales S.A.C</em></strong><br><br>") +
                "<strong>P.D:</strong> Este correo es solo para confirmar el estado de recepcion. Agradeceremos no responderlo.</div> </div>" +
                "</center></body></html>");
        }


    }
}
