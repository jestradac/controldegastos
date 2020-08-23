using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace UI
{
    public class UtilScript
    {
        /// <summary>
        /// Estructura de Mensaje
        /// </summary>
        public enum TMensaje
        {
            Primario,
            Exito,
            Peligro,
            Alerta,
            Info,
            Custom
        }

        public static string StrMsjIni = "<div id=\"Mensaje\" style=\"visibility: hidden\"></div>";

        //Variables
        private static String _mensajeError = "Error, no se pudo guardar la informacion";

        /// <summary>
        /// Escribir Titulo al Formulario Actual
        /// </summary>
        /// <param name="strTitulo"></param>
        public static void escribirTitulo(String strTitulo)
        {
            System.Web.UI.Page pagActual = (System.Web.UI.Page)HttpContext.Current.Handler;
            ((System.Web.UI.WebControls.Label)(pagActual.Master.FindControl("lblTitulo"))).Text = strTitulo;
        }

        /// <summary>
        /// Mensaje de Error por Defecto
        /// </summary>
        public static void abrirAlertaError()
        {
            abrirAlertaError(_mensajeError);
        }

        /// <summary>
        /// Escribir Mensaje de Error
        /// </summary>
        /// <param name="strMensaje"></param>
        public static void abrirAlertaError(String strMensaje)
        {
            //Armando JS
            String strJS = "";
            strJS += "$(document).ready(function() {";
            strJS += "      toastr.error('" + strMensaje.Trim() + "');";
            strJS += "})";

            //Escribiendo JS
            System.Web.UI.Page pagActual = (System.Web.UI.Page)HttpContext.Current.Handler;
            pagActual.ClientScript.RegisterStartupScript(pagActual.GetType(), "alerta-error", strJS, true);
        }

        /// <summary>
        /// Implementando CheckAll ID
        /// </summary>
        /// <param name="strControlID"></param>
        public static void checkAllJS(ref CheckBox cbCheck)
        {
            //Agregando On Change
            cbCheck.Attributes.Add("onchange", "checkAll()");

            //JS
            String strJS = "";
            strJS += "function checkAll() { \r\n";
            strJS += "  var ele = document.getElementById('" + cbCheck.ClientID + "'); \r\n";
            strJS += "  var checkboxes = document.getElementsByTagName('input'); \r\n";
            strJS += "  if (ele.checked) { \r\n";
            strJS += "      for (var i = 0; i < checkboxes.length; i++) \r\n";
            strJS += "      { \r\n";
            strJS += "          if ( (checkboxes[i].type == 'checkbox') && (checkboxes[i].id != '" + cbCheck.ClientID + "') ) \r\n";
            strJS += "          { \r\n";
            strJS += "              checkboxes[i].checked = true; \r\n";
            strJS += "          } \r\n";
            strJS += "      } \r\n";
            strJS += "  } else \r\n";
            strJS += "  { \r\n";
            strJS += "      for (var i = 0; i < checkboxes.length; i++) \r\n";
            strJS += "      { \r\n";
            strJS += "          if ( (checkboxes[i].type == 'checkbox') && (checkboxes[i].id != '" + cbCheck.ClientID + "') ) \r\n";
            strJS += "          { \r\n";
            strJS += "              checkboxes[i].checked = false; \r\n";
            strJS += "          } \r\n";
            strJS += "      } \r\n";
            strJS += "  } \r\n";
            strJS += "} \r\n";

            //Escribiendo JS
            System.Web.UI.Page pagActual = (System.Web.UI.Page)HttpContext.Current.Handler;
            pagActual.ClientScript.RegisterStartupScript(pagActual.GetType(), "checkall-js", strJS, true);
        }

        /// <summary>
        /// Abrir Alerta
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="tm"></param>
        /// <param name="lit"></param>
        public static void abrirAlertaError1(string msj, TMensaje tm, Literal lit)
        {
            String strJS = "";
            switch (tm)
            {
                case TMensaje.Primario: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-icon-right alert-primary alert-dismissible mb-2\" role =\"alert\" >";
                    strJS += "<span class=\"alert-icon\" ><i class=\"icon-heart5\"></i></span>";
                    break;

                case TMensaje.Exito: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-icon-right alert-success alert-dismissible mb-2\" role =\"alert\" >";
                    strJS += "<span class=\"alert-icon\" ><i class=\"icon-thumbs-up-alt\"></i></span>";
                    break;

                case TMensaje.Peligro: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-icon-right alert-danger alert-dismissible mb-2\" role =\"alert\" >";
                    strJS += "<span class=\"alert-icon\" ><i class=\"icon-thumbs-down-alt\"></i></span>";
                    break;

                case TMensaje.Alerta: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-icon-right alert-danger alert-dismissible mb-2\" role =\"alert\" >";
                    strJS += "<span class=\"alert-icon\" ><i class=\"icon-exclamation-sign\"></i></span>";
                    break;

                case TMensaje.Info: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-icon-right alert-info alert-dismissible mb-2\" role =\"alert\" >";
                    strJS += "<span class=\"alert-icon\" ><i class=\"icon-info-sign\"></i></span>";
                    break;

                default:
                    strJS = "";
                    break;
            }
            if (strJS != "")
            {
                strJS += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\" >";
                strJS += "<span aria-hidden=\"true\">×</span></button>";
                strJS += "<strong>" + msj + "</strong></div>";
            }

            //Escribiendo Literal
            lit.Text = strJS;
        }

        /// <summary>
        /// Abrir Mensaje
        /// NOTA: Se debe reparar el uso de la alerta y procurar usar este metodo y no el anterior con 1 al final
        /// </summary>
        /// <param name="msj"></param>
        /// <param name="tm"></param>
        /// <param name="lit"></param>
        public static void abrirMensaje(string msj, TMensaje tm, Literal lit)
        {
            String strJS = "";
            switch (tm)
            {
                case TMensaje.Primario: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-primary alert-dismissible mb-2\" role =\"alert\">";
                    break;

                case TMensaje.Exito: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-success alert-dismissible mb-2\" role =\"alert\">";
                    break;

                case TMensaje.Peligro: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-danger alert-dismissible mb-2\" role =\"alert\">";
                    break;

                case TMensaje.Alerta: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-danger alert-dismissible mb-2\" role =\"alert\">";
                    break;

                case TMensaje.Info: //ok
                    strJS = "<div id=\"Mensaje\" class=\"alert alert-info alert-dismissible mb-2\" role =\"alert\">";
                    break;

                default:
                    strJS = "";
                    break;
            }

            //Fin
            if (strJS != "")
            {
                strJS += "<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">";
                strJS += "<span aria-hidden=\"true\">×</span></button>";
                strJS += "<strong>" + msj + "</strong></div>";
            }

            //Mensaje
            lit.Text = strJS;
        }

        /// <summary>
        /// Armar Fecha
        /// </summary>
        /// <param name="txbCampo"></param>
        public static void armarFecha(ref System.Web.UI.WebControls.TextBox txbCampo, String strTitulo = "")
        {
            //Aplicando Atributos para Armar Fecha
            txbCampo.Attributes.Add("type", "date");
            txbCampo.Attributes.Add("data-toggle", "tooltip");
            txbCampo.Attributes.Add("data-trigger", "hover");
            txbCampo.Attributes.Add("data-placement", "top");
            txbCampo.Attributes.Add("data-title", strTitulo.Trim());
        }

        /// <summary>
        /// Armar Fecha y Hora
        /// </summary>
        /// <param name="txbCampo"></param>
        /// <param name="strTitulo"></param>
        public static void armarFechaHora(ref System.Web.UI.WebControls.TextBox txbCampo, String strTitulo)
        {
            //Aplicando Atributos para Armar Fecha
            txbCampo.Attributes.Add("type", "datetime-local");
            txbCampo.Attributes.Add("data-toggle", "tooltip");
            txbCampo.Attributes.Add("data-trigger", "hover");
            txbCampo.Attributes.Add("data-placement", "top");
            txbCampo.Attributes.Add("data-title", strTitulo.Trim());
        }

        /// <summary>
        /// Armar Hora
        /// </summary>
        /// <param name="txbCampo"></param>
        /// <param name="horaMin"></param>
        /// <param name="horaMax"></param>
        public static void armarHora(ref System.Web.UI.WebControls.TextBox txbCampo, String horaMin, String horaMax)
        {
            //Aplicando Atributos para Armar Fecha
            txbCampo.Attributes.Add("type", "time");
            txbCampo.Attributes.Add("min", horaMin);
            txbCampo.Attributes.Add("max", horaMax);
        }

        /// <summary>
        /// Armar Campo Numero
        /// </summary>
        /// <param name="txbCampo"></param>
        public static void armarNumero(ref System.Web.UI.WebControls.TextBox txbCampo)
        {
            txbCampo.Attributes.Add("type", "number");
            txbCampo.Attributes.Add("step", "1");
            txbCampo.Attributes.Add("min", "0");
        }

        public static void armarDecimal(ref System.Web.UI.WebControls.TextBox txbCampo)
        {
            txbCampo.Attributes.Add("type", "number");
            txbCampo.Attributes.Add("step", "0.1");
            txbCampo.Attributes.Add("min", "0");
        }

        /// <summary>
        /// Armar Componente Color Picker
        /// </summary>
        /// <param name="txbCampo"></param>
        public static void armarColor(ref System.Web.UI.WebControls.TextBox txbCampo)
        {
            txbCampo.Attributes.Add("type", "color");
        }

        /// <summary>
        /// Validando Fechas
        /// </summary>
        /// <param name="txbCampo"></param>
        /// <returns></returns>
        public static bool esFechaValida(ref System.Web.UI.WebControls.TextBox txbCampo)
        {
            try
            {
                System.DateTime.Parse(txbCampo.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Es Numero Valido
        /// </summary>
        /// <param name="txbCampo"></param>
        /// <returns></returns>
        public static bool esNumeroValido(ref System.Web.UI.WebControls.TextBox txbCampo)
        {
            try
            {
                Decimal.Parse(txbCampo.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Formatear Decimal
        /// </summary>
        /// <param name="strValor"></param>
        /// <returns></returns>
        public static String formatearDecimalUI(Decimal strValor)
        {
            try
            {
                return strValor.ToString().Replace(",", ".");
            }
            catch
            {
                return "E";
            }
        }

        /// <summary>
        /// Escribir Mensaje de Error
        /// </summary>
        /// <param name="strCampoID"></param>
        public static void armarChosenBuscar(String strCampoID)
        {
            //Armando JS
            String strJS = "";

            strJS +="$(\"#" + strCampoID + "\").chosen({";
            strJS += " disable_search_threshold: 0,";
            strJS += " no_results_text: \"Oops, nothing found!\"";
            strJS += " });";

            //Escribiendo JS
            System.Web.UI.Page pagActual = (System.Web.UI.Page)HttpContext.Current.Handler;
            pagActual.ClientScript.RegisterStartupScript(pagActual.GetType(), "alerta-error", strJS, true);
        }

        public static void armarChosenBuscar_obj(ref System.Web.UI.WebControls.DropDownList ddlObjeto)
        {
            //Armando JS
            String strJS = "";
            strJS += "$(\"#" + ddlObjeto.ClientID + "\").chosen({";
            strJS += " disable_search_threshold: 0,";
            strJS += " no_results_text: \"Oops, nothing found!\"";
            strJS += " });";

            //Escribiendo JS
            System.Web.UI.Page pagActual = (System.Web.UI.Page)HttpContext.Current.Handler;
            //pagActual.ClientScript.RegisterStartupScript(pagActual.GetType(), "alerta-error", strJS, true);
            pagActual.ClientScript.RegisterStartupScript(pagActual.GetType(), ddlObjeto.ClientID.ToString(), strJS, true);
        }

        /// <summary>
        /// Armar Color Picker
        /// </summary>
        /// <param name="strClientID"></param>
        public static void armarColorPicker(String strClientID)
        {
            //JS
            String strJS = "";
            strJS += "$(function () { \r\n";
            strJS += "  $('#" + strClientID + "').colorpicker(); \r\n \r\n";
            strJS += "  $('#" + strClientID + "').on('colorpickerChange', function(event) { \r\n";
            strJS += "      $('#" + strClientID + "').css('background-color', event.color.toString()); \r\n";
            strJS += "  }); \r\n";
            strJS += "}); \r\n";

            //Escribiendo JS
            System.Web.UI.Page pagActual = (System.Web.UI.Page)HttpContext.Current.Handler;
            pagActual.ClientScript.RegisterStartupScript(pagActual.GetType(), "color-picker", strJS, true);
        }

        /// <summary>
        /// Agregar Componente Calendario
        /// </summary>
        /// <param name="divID"></param>
        public static void agregarComponenteCalendario( String divID, String auxContrato )
        {
            String strScript = "";
            strScript += "//Objeto \r\n";
            strScript += "var calendarEl = document.getElementById('" + divID + "'); \r\n";
            
            strScript += "//Parametros \r\n";
            strScript += "var calendario = new FullCalendar.Calendar(calendarEl, { \r\n";
            strScript += "  plugins: ['interaction', 'dayGrid', 'timeGrid', 'list'], \r\n";
            strScript += "  header: { \r\n";
            strScript += "      left: 'prev,next today', \r\n";
            strScript += "      center: 'title', \r\n";
            strScript += "      right: 'dayGridMonth,listMonth' \r\n";
            strScript += "  }, \r\n";
            strScript += "  defaultDate: '" + DateTime.Now.ToString("yyyy-MM-dd") + "', \r\n";
            strScript += "  locale: 'es', \r\n";
            strScript += "  buttonIcons: false, \r\n";
            strScript += "  weekNumbers: false, \r\n";
            strScript += "  navLinks: true, \r\n";
            strScript += "  editable: true, \r\n";
            strScript += "  eventLimit: false, \r\n";
            strScript += "  dateClick: function (info) { \r\n";
            strScript += "       location.href = 'IUProgramarDia.aspx?fecha=' + info.dateStr + '&idC=" + auxContrato +  "'; \r\n";
            strScript += "       console.log( info.dateStr ); \r\n";
            strScript += "  } \r\n";
            strScript += "}); \r\n";
            strScript += "\r\n \r\n";
            strScript += "calendario.render(); \r\n";

            //Escribiendo JS
            System.Web.UI.Page pagActual = (System.Web.UI.Page)HttpContext.Current.Handler;
            pagActual.ClientScript.RegisterStartupScript(pagActual.GetType(), "evento-calendario", strScript, true);
        }

        /// <summary>
        /// Agregar Evento para Calendario
        /// </summary>
        /// <param name="strTitulo"></param>
        /// <param name="auxFechaInicio"></param>
        /// <param name="auxFechaFin"></param>
        /// <param name="strColorFondo"></param>
        /// <param name="strColorBorde"></param>
        public static void agregarEventoCalendario(String strTitulo, DateTime auxFechaInicio, DateTime auxFechaFin, String strColorFondo, String strColorBorde, String strColorLetra, String strURL = "")
        {
            //Auxiliares IDs
            String strID = Guid.NewGuid().ToString().Replace("-", "");
            String strNombreObjeto = "ev" + strID;

            //Fecha Inicio
            String strFechaInicio = "new Date(%Anho%, %Mes%, %Dia%, %Hora%, %Minuto%, 0, 0);";
            String strFechaFin = "new Date(%Anho%, %Mes%, %Dia%, %Hora%, %Minuto%, 0, 0);";

            //Remplazando Valores
            // ++ Inicio
            strFechaInicio = strFechaInicio.Replace("%Anho%", auxFechaInicio.Year.ToString());
            strFechaInicio = strFechaInicio.Replace("%Mes%", (auxFechaInicio.Month - 1).ToString());
            strFechaInicio = strFechaInicio.Replace("%Dia%", auxFechaInicio.Day.ToString());
            strFechaInicio = strFechaInicio.Replace("%Hora%", auxFechaInicio.Hour.ToString());
            strFechaInicio = strFechaInicio.Replace("%Minuto%", auxFechaInicio.Minute.ToString());

            // ++ Fin
            strFechaFin = strFechaFin.Replace("%Anho%", auxFechaFin.Year.ToString());
            strFechaFin = strFechaFin.Replace("%Mes%", (auxFechaFin.Month - 1).ToString());
            strFechaFin = strFechaFin.Replace("%Dia%", auxFechaFin.Day.ToString());
            strFechaFin = strFechaFin.Replace("%Hora%", auxFechaFin.Hour.ToString());
            strFechaFin = strFechaFin.Replace("%Minuto%", auxFechaFin.Minute.ToString());

            //Script
            String strScript = "";
            strScript += "var " + strNombreObjeto + " = new Object(); \r\n";
            strScript += strNombreObjeto + ".id = '" + strID + "'; \r\n";
            strScript += strNombreObjeto + ".allDay = false; \r\n";
            strScript += strNombreObjeto + ".start = " + strFechaInicio + " \r\n";
            strScript += strNombreObjeto + ".end = " + strFechaFin + " \r\n";
            strScript += strNombreObjeto + ".title = '" + strTitulo.Trim() + "'; \r\n";
            strScript += strNombreObjeto + ".url = '" + strURL + "'; \r\n";
            strScript += strNombreObjeto + ".className = '';  \r\n";
            strScript += strNombreObjeto + ".editable = true; \r\n";
            strScript += strNombreObjeto + ".backgroundColor = '" + strColorFondo + "'; \r\n";
            strScript += strNombreObjeto + ".borderColor = '" + strColorBorde + "'; \r\n";
            strScript += strNombreObjeto + ".textColor = '" + strColorLetra + "'; \r\n";
            strScript += "calendario.addEvent(" + strNombreObjeto + "); \r\n";

            //Escribiendo JS
            System.Web.UI.Page pagActual = (System.Web.UI.Page)HttpContext.Current.Handler;
            pagActual.ClientScript.RegisterStartupScript(pagActual.GetType(), "evento-" + strID, strScript, true);
        }
    }

}