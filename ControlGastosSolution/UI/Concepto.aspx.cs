using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class Concepto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.prepararFormulario();
            }
        }
        void prepararFormulario()
        {
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();

            if (Session["usuario"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {
                objUsuario = (BRL.tbl_Usuario)Session["usuario"];
                System.Web.UI.WebControls.Label lblUsuario = (System.Web.UI.WebControls.Label)Master.FindControl("lblUsuario");
                lblUsuario.Text = objUsuario.nombreCompleto;
            }

            if (!String.IsNullOrEmpty(Request["id"]))
            {
                BRL.tbl_Concepto objConcepto = new BRL.tbl_Concepto();
                objConcepto = objConcepto.traertbl_Concepto(int.Parse(Request["id"]));

                this.txbNombre.Text = objConcepto.nombre.Trim();
                this.ddlTipoTransaccion.Enabled = false;

                if (objConcepto.tipoTransaccion.Equals(false))
                {
                    ddlTipoTransaccion.SelectedValue = "Ingreso";
                }
                else
                {
                    ddlTipoTransaccion.SelectedValue = "Egreso";
                }
            }
            else
            {
                this.ddlTipoTransaccion.Enabled = true;
            }
        }
        private void guardar()
        {
            bool esEditar = !String.IsNullOrEmpty(Request["id"]);
            bool auxControl = false;
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();
            objUsuario = (BRL.tbl_Usuario)Session["usuario"];
            BRL.tbl_Concepto objConcepto = new BRL.tbl_Concepto();

            if (esEditar)
            {
                objConcepto = objConcepto.traertbl_Concepto(int.Parse(Request["id"]));
                ddlTipoTransaccion.Enabled = false;
            }

            objConcepto.nombre = this.txbNombre.Text.Trim();
            objConcepto.idUsuario = objUsuario.idUsuario;

            if (ddlTipoTransaccion.SelectedValue.Equals("Ingreso"))
            {
                objConcepto.tipoTransaccion = false;
            }
            else
            {
                objConcepto.tipoTransaccion = true;
            }

            objConcepto.fechaCreacion = DateTime.Now;
            objConcepto.eliminado = false;

            auxControl = esEditar ? objConcepto.modificar() : objConcepto.guardar();

            if (auxControl)
            {
                MessageBox.Show("El concepto se ha registrado de manera exitosa");
                Response.Redirect("ListadoConcepto.aspx", true);
            }
            else
            {
                MessageBox.Show("Hubo un error");
            }
        }
        bool tipoTransaccion()
        {
            if (ddlTipoTransaccion.SelectedValue.Equals("Ingreso"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private String validar()
        {
            //Capturar el Mensaje
            String mensaje = "";
            bool auxTipoTransaccion = tipoTransaccion();
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();
            objUsuario = (BRL.tbl_Usuario)Session["usuario"];
            BRL.tbl_Concepto objConcepto = new BRL.tbl_Concepto();
            
            if (String.IsNullOrEmpty(this.txbNombre.Text))
            {
                mensaje += "- En nombre es obligatorio \n";
            }
            if (objConcepto.existeCombinacion(this.txbNombre.Text.Trim(), auxTipoTransaccion, objUsuario.idUsuario))
            {
                mensaje += "- '" + this.txbNombre.Text + "', ya existe";
            }

            return mensaje;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            String mensaje = this.validar();

            if (String.IsNullOrEmpty(mensaje))
            {
                this.guardar();
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar la cuenta");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoConcepto.aspx", true);
        }
    }
}