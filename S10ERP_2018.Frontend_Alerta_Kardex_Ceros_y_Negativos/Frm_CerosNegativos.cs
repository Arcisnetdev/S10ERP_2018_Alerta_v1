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

namespace S10ERP_2018.Frontend_Alerta_Kardex_Ceros_y_Negativos
{
    public partial class Frm_CerosNegativos : Form
    {
        public Frm_CerosNegativos()
        {
            InitializeComponent();
        }

        private void Frm_CerosNegativos_Load(object sender, EventArgs e)
        {
            BE_Kardex_Ceros_Negativos kardexCeroNegativo = (BE_Kardex_Ceros_Negativos)BL_ObjControl_Kardex_Ceros_Negativo.PoblarKardex_Ceros_NegativoSelAll();
            if (kardexCeroNegativo.Count > 0)
            {
                this.EnvioKceroNegativo();
            }
            this.Dispose();
        }


        private void EnvioKceroNegativo()
        {
            MailMessage message = new MailMessage();
            //Lista para enviar a Operaciones
            message.To.Add("personal_almacen@nexcom.com.pe");
            message.CC.Add("asilva@nexcom.com.pe");
            message.Bcc.Add("arosales@nexcom.com.pe");
            //message.Bcc.Add("vmelendez@nexcom.com.pe");

            //Lista para enviar a GAF
            //message.Bcc.Add("lperez@nexcom.com.pe");
            //message.Bcc.Add("scelestino@nexcom.com.pe");

            message.From = new MailAddress("noresponder@nexcom.com.pe", "Kardex con cantidades negativas en Stock actual, Precios en ceros y/o negativos", Encoding.UTF8);
            message.Subject = "Alerta de Control -> Kardex con cantidades negativas en Stock actual, Precios en ceros y/o negativos";
            message.SubjectEncoding = Encoding.UTF8;
            message.Body = this.TextoKceroNegativo();
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


        private string TextoKceroNegativo()
        {
            IEnumerator enumerator;
            string str = "<html>";
            str = (((((((((((str + "<body><center> " + "<div style='font-size:11px; font-family:Arial; text-align:left; padding:10px; width:650px;'>") +
                "<br><div style='padding-left:30px; padding-right:30px; text-align:justify'><strong>Estimado(a) usuario(a):</strong>" +
                "<br>El listado presentado a continuaci\x00f3n es el Kardex con cantidades (Stock actual) negativas y los Precios en ceros y negativos.") +
                "</div><br>" + "<div style='font-size:11px; font-family:Arial;background-color:#E8EAEE; padding:20px'>") +
                "<table width='1210'  cellpadding='3'>" + "<tr><td colspan='2'>") +
                "<hr /> </td></tr>" + "<tr><td width='120' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PROYECTO</td>") +
                "<td width='120' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>ALMACEN</td>" +
                "<td width='50' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>CODRECURSO</td>") +
                "<td width='370' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>RECURSO</td>" +
                "<td width='30' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>UNIDAD</td>") +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>FECHAGUIA</td>" +
                "<td width='30' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>NROGUIA</td>") +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>MOVIMIENTO</td>" +
                "<td width='30' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>MONEDA</td>") +
                "<td width='40' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>CANTIDAD</td>" +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PRECIO</td>") +
                "<td width='60' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>STOCK_ANTERIOR</td>" +
                "<td width='40' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>STOCK_ACTUAL</td>") +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>PROYECTO_TRANSFERENCIA</td>" +
                "<td width='70' valign='top' style='text-align:center;background-color:#DDDDDD;font-size:8px; font-family:Arial'>ALMACEN_TRANSFERENCIA</td></tr>";
            try
            {
                
                   enumerator = ((IEnumerable)BL_ObjControl_Kardex_Ceros_Negativo.PoblarKardex_Ceros_NegativoSelAll()).GetEnumerator();
                while (enumerator.MoveNext())
                {
                    BE_Kardex_Ceros_Negativo current = (BE_Kardex_Ceros_Negativo)enumerator.Current;
                    str = str + "<tr><td width='120' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'>" + current.Proyecto + "</td>";
                    str = str + "<td width='120' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Almacen + "</td>";
                    str = str + "<td width='50' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.CodRecurso + "</td>";
                    str = str + "<td width='370' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Recurso + "</td>";
                    str = str + "<td width='30' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Unidad + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.FechaGuia + "</td>";
                    str = str + "<td width='30' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'>" + current.NroGuia + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Movimiento + "</td>";
                    str = str + "<td width='30' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Moneda + "</td>";
                    str = str + "<td width='40' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'>" + current.Cantidad + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.Precio + "</td>";
                    str = str + "<td width='60' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'> " + current.StockActual + "</td>";
                    str = str + "<td width='40' valign='top' style='font-size:8px; font-family:Arial;text-align:center;color:red'>" + current.StockAnterior + "</td>";
                    str = str + "<td width='70' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'> " + current.ProyectoTransferencia + "</td>";
                    str = str + "<td width='70' valign='top' style='font-size:8px; font-family:Arial;text-align:center;'>" + current.AlmacenTransferencia + "</td></tr>";
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
                "<strong><em>Nexos Comerciales S.A.C</em></strong><br><br>") +
                "<strong>P.D:</strong> Este correo es solo para confirmar el estado de recepcion. Agradeceremos no responderlo.</div> </div>" +
                "</center></body></html>");
        }




    }
}
