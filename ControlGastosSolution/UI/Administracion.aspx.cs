using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Administracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void cargarDatos()
        {
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();
            if (Session["usuario"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            else
            {

                objUsuario = (BRL.tbl_Usuario)Session["usuario"];
                Label lblUsuario = (Label)Master.FindControl("lblUsuario");
                lblUsuario.Text = objUsuario.nombreCompleto;
            }
        }

        protected void gvAdministracion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvAdministracion_DataBound(object sender, EventArgs e)
        {

        }

        protected void gvAdministracion_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}