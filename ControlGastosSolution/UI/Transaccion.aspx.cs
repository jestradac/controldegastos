using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI
{
    public partial class Transaccion : System.Web.UI.Page
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
            BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();
            ddlCuenta.DataSource = objCuenta.listartbl_Cuentas();
            ddlCuenta.DataValueField = "idCuenta";
            ddlCuenta.DataTextField = "nombre";
            ddlCuenta.DataBind();

            BRL.tbl_Concepto objConcepto = new BRL.tbl_Concepto();
            ddlConcepto.DataSource = objConcepto.listartbl_Conceptos();
            ddlConcepto.DataValueField = "idConcepto";
            ddlConcepto.DataTextField = "nombre";
            ddlConcepto.DataBind();

            //prepararConceptos();
            if (!String.IsNullOrEmpty(Request["id"]))
            {
                BRL.tbl_Transaccion objTransaccion = new BRL.tbl_Transaccion();
                objTransaccion = objTransaccion.traertbl_Transaccion(int.Parse(Request["id"]));

                try
                {
                    this.ddlCuenta.SelectedValue = objTransaccion.idCuenta.ToString();
                    this.ddlConcepto.SelectedValue = objTransaccion.idConcepto.ToString();
                }
                catch
                {
                    this.ddlCuenta.SelectedIndex = 0;
                    this.ddlConcepto.SelectedIndex = 0;
                }
                this.txbMonto.Text = objTransaccion.monto.ToString();
                this.txbFechaTrasaccion.Text = objTransaccion.fechaTransaccion.ToString();
                
            }
            prepararConceptos();
        }
        bool tipoTransaccion()
        {
            if (ddlTipoTransaccion.SelectedValue.Equals("Ingreso"))
            {
                return false;
            }
            else if (ddlTipoTransaccion.SelectedValue.Equals("Traspaso"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void prepararConceptos()
        {
            bool auxTipoTransaccion = tipoTransaccion();
            BRL.tbl_Concepto objConcepto = new BRL.tbl_Concepto();
            List<BRL.tbl_Concepto> lConcepto = new List<BRL.tbl_Concepto>();
            lConcepto = objConcepto.listarTipoTransaccion(auxTipoTransaccion);
            ddlConcepto.Items.Clear();

            if (lConcepto.Count() > 0)
            {
                for (int i = 0; i < lConcepto.Count; i++)
                {
                    ddlConcepto.Items.Add(new ListItem(lConcepto[i].nombre, lConcepto[i].idConcepto.ToString()));
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            prepararConceptos();
        }
    }
}