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
            if (!IsPostBack)
            {
                cargarDatos();
            }
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

            BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();
            lblSalgoGlobal.Text = "Bs. " + objCuenta.verSaldoGlobal(objUsuario.idUsuario).ToString();
            repCuenta.DataSource = objCuenta.listartbl_Cuentas(objUsuario.idUsuario);
            repCuenta.DataBind();
        }
        protected void gvAdministracion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        protected void gvAdministracion_DataBound(object sender, EventArgs e)
        {

        }
        protected void gvAdministracion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                BRL.tbl_Transaccion objTransaccion = (BRL.tbl_Transaccion)e.Row.DataItem;

                Label lblFecha = (Label)e.Row.FindControl("lblFecha");
                lblFecha.Text = objTransaccion.fechaTransaccion.ToString();

                Label lblMonto = (Label)e.Row.FindControl("lblMonto");
                lblMonto.Text = objTransaccion.monto.ToString();

                Label lblTipo = (Label)e.Row.FindControl("lblTipo");

                if (objTransaccion.tbl_Concepto.idConcepto > 2)
                {
                    if (objTransaccion.tbl_Concepto.idConcepto.Equals(true))
                    {
                        lblTipo.Text = "Ingreso";
                        lblMonto.CssClass = "float-right success";
                    }
                    else
                    {
                        lblTipo.Text = "Egreso";
                        lblMonto.CssClass = "float-right danger";
                    }
                }
                else
                {
                    lblTipo.Text = "Traspaso";

                    if (objTransaccion.tbl_Concepto.nombre.Equals("Traspaso Ingreso"))
                    {
                        lblMonto.CssClass = "float-right success";
                    }
                    else
                    {
                        lblMonto.CssClass = "float-right danger";
                    }
                }

                Label lblConcepto = (Label)e.Row.FindControl("lblConcepto");
                lblConcepto.Text = objTransaccion.tbl_Concepto.nombre.Trim();
            }
        }
        protected void repCuenta_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                BRL.tbl_Cuenta objCuenta = (BRL.tbl_Cuenta)e.Item.DataItem;
                BRL.tbl_Transaccion objTransaccion = new BRL.tbl_Transaccion();

                Label lblCuentaSaldo = (Label)e.Item.FindControl("lblCuentaSaldo");
                lblCuentaSaldo.Text = objCuenta.nombreSaldo;

                GridView gvAdministracion = (GridView)e.Item.FindControl("gvAdministracion");
                gvAdministracion.DataSource = objTransaccion.listartbl_TransaccionCuenta(objCuenta.idCuenta);
                gvAdministracion.DataBind();
            }
        }
    }
}