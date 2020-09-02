using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UI
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        void Inicializar()
        {
            Session["usuario"] = null;
            txtEmail.Text = "";
            txtPassword.Text = "";
        }
        void VerificarLogIn()
        {
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();
            BRL.tbl_Usuario objUsuario1 = new BRL.tbl_Usuario();
            objUsuario1 = objUsuario.verificarCombinacion(txtEmail.Text.Trim(), txtPassword.Text);

            if (!objUsuario.existeEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("El correo electrónico no existe");

            }
            else if (objUsuario.existeEmail(txtEmail.Text.Trim()) && objUsuario1 == null)
            {
                MessageBox.Show("Los datos no coinciden");
            }
            else
            {
                Session["usuario"] = objUsuario1;
                Response.Redirect("Administracion.aspx", true);
            }
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            VerificarLogIn();
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("SignIn.aspx", true);
        }
    }
}