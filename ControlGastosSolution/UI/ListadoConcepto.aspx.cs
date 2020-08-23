using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class ListadoConcepto : System.Web.UI.Page
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
            BRL.tbl_Concepto objConcepto = new BRL.tbl_Concepto();
            this.gvConcepto.DataSource = objConcepto.listartbl_Conceptos();
            this.gvConcepto.DataBind();
        }
        protected void gvConcepto_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BRL.tbl_Concepto objConcepto = (BRL.tbl_Concepto)e.Row.DataItem;

                Label lblNombre = (Label)e.Row.FindControl("lblNombre");
                lblNombre.Text = objConcepto.nombre.Trim();

                Label lblTipoTransaccion = (Label)e.Row.FindControl("lblTipoTransaccion");

                if(objConcepto.tipoTransaccion.Equals(false))
                {
                    lblTipoTransaccion.Text = "Ingreso";
                }
                else
                {
                    lblTipoTransaccion.Text = "Egreso";
                }

                HyperLink hlEditar = (HyperLink)e.Row.FindControl("hlEditar");
                hlEditar.NavigateUrl = "Concepto.aspx?id=" + objConcepto.idConcepto.ToString();

                LinkButton lbEliminar = (LinkButton)e.Row.FindControl("lbEliminar");
                lbEliminar.Attributes.Add("auxID", objConcepto.idConcepto.ToString());
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Concepto.aspx", true);
        }

        protected void lbEliminar_Click(object sender, EventArgs e)
        {
            LinkButton lbEliminar = (LinkButton)sender;

            BRL.tbl_Concepto objConcepto = new BRL.tbl_Concepto();
            objConcepto = objConcepto.traertbl_Concepto(int.Parse(lbEliminar.Attributes["auxID"]));
            objConcepto.eliminado = true;
            objConcepto.modificar();

            this.cargarDatos();
        }

        protected void gvConcepto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.gvConcepto.PageIndex = e.NewPageIndex;
            this.cargarDatos();
        }

        protected void gvConcepto_DataBound(object sender, EventArgs e)
        {
            try
            {
                this.gvConcepto.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }
    }
}