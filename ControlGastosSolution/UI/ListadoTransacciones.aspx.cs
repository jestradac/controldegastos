using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class ListadoTransacciones : System.Web.UI.Page
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

            BRL.tbl_Transaccion objTransaccion = new BRL.tbl_Transaccion();
            this.gvTransaccion.DataSource = objTransaccion.listartbl_Transaccions(objUsuario.idUsuario);
            this.gvTransaccion.DataBind();
        }
        protected void gvTransaccion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BRL.tbl_Transaccion objTransaccion = (BRL.tbl_Transaccion)e.Row.DataItem;

                Label lblFechaTransaccion = (Label)e.Row.FindControl("lblFechaTransaccion");
                lblFechaTransaccion.Text = objTransaccion.fechaTransaccion.ToString().Trim();

                Label lblSigno = (Label)e.Row.FindControl("lblSigno");

                Label lblMonto = (Label)e.Row.FindControl("lblMonto");
                lblMonto.Text = objTransaccion.monto.ToString().Trim();
                ///modificar
                if (objTransaccion.tbl_Concepto.tipoTransaccion.Equals(false))
                {
                    lblSigno.Text = "+";
                    lblSigno.CssClass = "text-muted text-bold-700 success text-center";
                    lblMonto.CssClass = "float-right success";
                }
                else
                {
                    lblSigno.Text = "-";
                    lblSigno.CssClass = "text-muted text-bold-700 danger text-center";
                    lblMonto.CssClass = "float-right danger";
                }

                Label lblConcepto = (Label)e.Row.FindControl("lblConcepto");
                lblConcepto.Text = objTransaccion.tbl_Concepto.nombre.Trim();

                Label lblCuenta = (Label)e.Row.FindControl("lblCuenta");
                lblCuenta.Text = objTransaccion.tbl_Cuenta.nombre.Trim();

                HyperLink hlEditar = (HyperLink)e.Row.FindControl("hlEditar");
                hlEditar.NavigateUrl = "Transaccion.aspx?id=" + objTransaccion.idTransaccion.ToString();

                LinkButton lbEliminar = (LinkButton)e.Row.FindControl("lbEliminar");
                lbEliminar.Attributes.Add("auxID", objTransaccion.idTransaccion.ToString());
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Transaccion.aspx", true);
        }
        protected void lbEliminar_Click(object sender, EventArgs e)
        {
            LinkButton lbEliminar = (LinkButton)sender;

            BRL.tbl_Transaccion objTransaccion = new BRL.tbl_Transaccion();
            objTransaccion = objTransaccion.traertbl_Transaccion(int.Parse(lbEliminar.Attributes["auxID"]));
            objTransaccion.eliminado = true;
            objTransaccion.modificar();
            if (objTransaccion.idTransaccionRef != null)
            {
                BRL.tbl_Transaccion objTransaccionRef = new BRL.tbl_Transaccion();
                objTransaccionRef = objTransaccionRef.traertbl_Transaccion(objTransaccion.idTransaccionRef.Value);
                objTransaccionRef.eliminado = true;
                objTransaccionRef.modificar();

            }
            this.cargarDatos();
        }
        protected void gvTransaccion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvTransaccion.PageIndex = e.NewPageIndex;
            this.cargarDatos();
        }

        protected void gvTransaccion_DataBound(object sender, EventArgs e)
        {
            try
            {
                if (gvTransaccion.Rows.Count > 0)
                {
                    this.gvTransaccion.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                
            }
            catch { }
        }
    }
}