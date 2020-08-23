using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UI
{
    public partial class SignIn : System.Web.UI.Page
    {
        String mensaje = "";
        bool hayError = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                Inicializar();
            }
        }
        void Inicializar()
        {
            txtNombreCompleto.Text = "";
            txtEmailSigIn.Text = "";
            txtPasswordSignIn.Text = "";
            txtCPassword.Text = "";
        }
        void GuardarUsuario()
        {
            VerificarFormulario();

            if (hayError)
            {
                MessageBox.Show(mensaje);
                hayError = false;
            }
            else
            {
                BRL.tbl_Usuario usuario = new BRL.tbl_Usuario();
                usuario = new BRL.tbl_Usuario();
                usuario.nombreCompleto = txtNombreCompleto.Text;
                usuario.correoElectronico = txtEmailSigIn.Text;
                usuario.contrasena = txtPasswordSignIn.Text;
                usuario.eliminado = false;

                if (usuario.guardar())
                {
                    MessageBox.Show("Se ha guardado el registro de manera exitosa");
                    Response.Redirect("LogIn.aspx", true);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error");
                }
            }
        }
        void VerificarFormulario()
        {
            BRL.tbl_Usuario usuario = new BRL.tbl_Usuario();
            

            if (usuario.existeEmail(this.txtEmailSigIn.Text.Trim()))
            {
                mensaje += "- El correo electrónico ingresado ya existe. \n";
                hayError = true;
            }
            if (!esEmailValido())
            {
                mensaje += "- El formato del correo electrónico no es válido. \n";
                hayError = true;
            }
            if (String.IsNullOrEmpty(this.txtNombreCompleto.Text))
            {
                mensaje += "- Debe ingresar su Nombre Completo \n";
                hayError = true;
            }
            if (String.IsNullOrEmpty(this.txtPasswordSignIn.Text))
            {
                mensaje += "- Debe ingresar una contraseña \n";
                hayError = true;
            }
            if (String.IsNullOrEmpty(this.txtCPassword.Text))
            {
                mensaje += "- Necesita Confirmar Contraseña \n";
                hayError = true;
            }
            if (!txtPasswordSignIn.Text.Equals(this.txtCPassword.Text))
            {
                mensaje += "- Las contraseñas no coinciden \n";
                hayError = true;
            }
        }
        bool esEmailValido()
        {
            try
            {
                return Regex.IsMatch(txtEmailSigIn.Text,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            GuardarUsuario();
        }
    }
}