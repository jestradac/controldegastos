using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class Cuenta : System.Web.UI.Page
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
                BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();
                objCuenta = objCuenta.traertbl_Cuenta(int.Parse(Request["id"]));

                this.txbNombre.Text = objCuenta.nombre.Trim();
            }
        }
        private void guardar()
        {
            bool esEditar = !String.IsNullOrEmpty(Request["id"]);
            bool auxControl = false;
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();
            objUsuario = (BRL.tbl_Usuario)Session["usuario"];

            BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();

            if (esEditar)
            {
                objCuenta = objCuenta.traertbl_Cuenta(int.Parse(Request["id"]));
            }

            objCuenta.nombre = this.txbNombre.Text.Trim();
            objCuenta.idUsuario = objUsuario.idUsuario;
            objCuenta.fechaCreacion = DateTime.Now;
            objCuenta.eliminado = false;

            auxControl = esEditar ? objCuenta.modificar() : objCuenta.guardar();

            if (auxControl)
            {
                MessageBox.Show("La cuenta se ha registrado de manera exitosa");
                Response.Redirect("ListadoCuenta.aspx", true);
            }
            else
            {
                MessageBox.Show("Hubo un error");
            }
        }
        private String validar()
        {
            //Capturar el Mensaje
            String mensaje = "";
            BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();
            objUsuario = (BRL.tbl_Usuario)Session["usuario"];

            if (String.IsNullOrEmpty(this.txbNombre.Text))
            {
                mensaje += "- En nombre es obligatorio \n";
            }
            if (objCuenta.existeNombre(this.txbNombre.Text.Trim(), objUsuario.idUsuario))
            {
                mensaje += "- '" + this.txbNombre.Text + "', ya existe";
            }
            //Retornando
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
            Response.Redirect("ListadoCuenta.aspx", true);
        }
    }
}