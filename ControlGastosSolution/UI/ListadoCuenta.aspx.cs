using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class ListadoCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.cargarDatos();
            }
        }
        private void cargarDatos()
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

            BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();
            this.gvCuenta.DataSource = objCuenta.listartbl_Cuentas(objUsuario.idUsuario);
            this.gvCuenta.DataBind();
        }
        protected void gvCuenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BRL.tbl_Cuenta objCuenta = (BRL.tbl_Cuenta)e.Row.DataItem;
                BRL.tbl_Cuenta objCuentaAux = new BRL.tbl_Cuenta();

                Label lblNombre = (Label)e.Row.FindControl("lblNombre");
                lblNombre.Text = objCuenta.nombre.Trim();

                Label lblFechaCreacion = (Label)e.Row.FindControl("lblFechaCreacion");
                lblFechaCreacion.Text = objCuenta.fechaCreacion.ToString().Trim();

                Label lblSaldo = (Label)e.Row.FindControl("lblSaldo");
                lblSaldo.Text = objCuentaAux.verSaldo(objCuenta.idCuenta).ToString();

                HyperLink hlEditar = (HyperLink)e.Row.FindControl("hlEditar");
                hlEditar.NavigateUrl = "Cuenta.aspx?id=" + objCuenta.idCuenta.ToString();

                LinkButton lbEliminar = (LinkButton)e.Row.FindControl("lbEliminar");
                lbEliminar.Attributes.Add("auxID", objCuenta.idCuenta.ToString());
            }
        }
        protected void lbEliminar_Click(object sender, EventArgs e)
        {
            LinkButton lbEliminar = (LinkButton)sender;

            BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();
            objCuenta = objCuenta.traertbl_Cuenta(int.Parse(lbEliminar.Attributes["auxID"]));
            objCuenta.eliminado = true;
            objCuenta.modificar();
            this.cargarDatos();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cuenta.aspx", true);
        }
        protected void gvCuenta_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvCuenta.PageIndex = e.NewPageIndex;
            this.cargarDatos();
        }
        protected void gvCuenta_DataBound(object sender, EventArgs e)
        {
            try
            {
                if (gvCuenta.Rows.Count > 0)
                {
                    this.gvCuenta.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                
            }
            catch { }
        }
    }
}