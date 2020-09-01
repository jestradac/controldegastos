using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

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

            BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();
            ddlCuenta.DataSource = objCuenta.listartbl_Cuentas(objUsuario.idUsuario);
            ddlCuenta.DataValueField = "idCuenta";
            ddlCuenta.DataTextField = "nombre";
            ddlCuenta.DataBind();

            ddlCuentaDestino.DataSource = objCuenta.listartbl_Cuentas(objUsuario.idUsuario);
            ddlCuentaDestino.DataValueField = "idCuenta";
            ddlCuentaDestino.DataTextField = "nombre";
            ddlCuentaDestino.DataBind();

            ddlTipoTransaccion.Items.Clear();
            ddlTipoTransaccion.Items.Add(new ListItem("Ingreso", "I"));
            ddlTipoTransaccion.Items.Add(new ListItem("Egreso", "E"));
            ddlTipoTransaccion.Items.Add(new ListItem("Traspaso", "T"));
            ddlTipoTransaccion.SelectedIndex = 0;
            lblTitulo.Text = "Concepto";
            ddlCuentaDestino.Visible = false;
            ddlConcepto.Visible = true;
            cargarDDLConcepto(objUsuario.idUsuario, ddlTipoTransaccion.SelectedValue == "E");

            if (!String.IsNullOrEmpty(Request["id"]))
            {
                BRL.tbl_Transaccion objTransaccion = new BRL.tbl_Transaccion();
                objTransaccion = objTransaccion.traertbl_Transaccion(int.Parse(Request["id"]));
                ddlTipoTransaccion.Enabled = false;
                this.ddlCuenta.SelectedValue = objTransaccion.idCuenta.ToString();

                if (objTransaccion.idConcepto <= 2) //Es Traspaso
                {
                    BRL.tbl_Transaccion objTransaccionRef = new BRL.tbl_Transaccion();
                    objTransaccionRef = objTransaccionRef.traertbl_Transaccion(objTransaccion.idTransaccionRef.Value);
                    ddlCuentaDestino.SelectedValue = objTransaccionRef.idCuenta.ToString();
                    ddlTipoTransaccion.SelectedIndex = 2;
                    lblTitulo.Text = "Cuenta Destino";
                    ddlConcepto.Visible = false;
                    ddlCuentaDestino.Visible = true;
                    ddlCuentaDestino.Enabled = false;
                    ddlCuenta.Enabled = false;
                    txbMonto.Enabled = false;
                    Button1.Enabled = false;
                }
                else
                {
                    try
                    {
                        if (objTransaccion.tbl_Concepto.tipoTransaccion == false)
                        {
                            ddlTipoTransaccion.SelectedIndex = 0;
                        }
                        else
                        {
                            ddlTipoTransaccion.SelectedIndex = 1;
                        }
                        cargarDDLConcepto(objUsuario.idUsuario, ddlTipoTransaccion.SelectedValue == "E");
                        this.ddlConcepto.SelectedValue = objTransaccion.idConcepto.ToString();
                    }
                    catch
                    {
                        this.ddlTipoTransaccion.SelectedIndex = 0;
                        this.ddlCuenta.SelectedIndex = 0;
                        this.ddlConcepto.SelectedIndex = 0;
                    }
                }

                String monto = objTransaccion.monto.ToString();
                monto = monto.Replace(",", ".");
                this.txbMonto.Text = monto;
                //this.txbFechaTrasaccion.Text = objTransaccion.fechaTransaccion.ToString();
                
            }
        }

        void cargarDDLConcepto(int idUsuario, bool esEgreso)
        {
            BRL.tbl_Concepto objConcepto = new BRL.tbl_Concepto();
            //listar conceptos de ingresos o egreso
            ddlConcepto.DataSource = objConcepto.listartbl_Conceptos(idUsuario, esEgreso);
            ddlConcepto.DataValueField = "idConcepto";
            ddlConcepto.DataTextField = "nombre";
            ddlConcepto.DataBind();
        }

        private void guardar()
        {
            bool esEditar = !String.IsNullOrEmpty(Request["id"]);
            bool auxControl = false;
            decimal saldo = 0;
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();
            objUsuario = (BRL.tbl_Usuario)Session["usuario"];

            BRL.tbl_Transaccion objTransaccion = new BRL.tbl_Transaccion();
            BRL.tbl_Cuenta objCuenta = new BRL.tbl_Cuenta();
            saldo = objCuenta.verSaldo(int.Parse(ddlCuenta.SelectedValue));

            if (esEditar)
            {
                objTransaccion = objTransaccion.traertbl_Transaccion(int.Parse(Request["id"]));
                
            }
            String monto = this.txbMonto.Text;
            monto = monto.Replace(".", ",");
            
            BRL.tbl_Concepto auxConcepto = new BRL.tbl_Concepto();
            auxConcepto = auxConcepto.traertbl_Concepto(int.Parse(ddlConcepto.SelectedValue));
            if (auxConcepto.tipoTransaccion)
            {
                if (saldo < decimal.Parse(monto)) //Verifico si tengo saldo
                {
                    MessageBox.Show("Saldo Insuficiente");
                    return;
                }
                monto = "-" + monto;
            }
            objTransaccion.monto = Decimal.Parse(monto);
            objTransaccion.fechaTransaccion = DateTime.Now;
            objTransaccion.idCuenta = int.Parse(ddlCuenta.SelectedValue);
            if (ddlTipoTransaccion.SelectedValue == "T")
            {
                objTransaccion.idConcepto = 2;//Traspaso Egreso
            }
            else
            {
                objTransaccion.idConcepto = int.Parse(ddlConcepto.SelectedValue);
            }
            objTransaccion.eliminado = false;

            auxControl = esEditar ? objTransaccion.modificar() : objTransaccion.guardar();
            if (ddlTipoTransaccion.SelectedValue == "T")
            {
                BRL.tbl_Transaccion objTransaccionRef = new BRL.tbl_Transaccion();
                objTransaccionRef.monto = objTransaccion.monto;
                objTransaccionRef.idConcepto = 1;
                objTransaccionRef.idCuenta = int.Parse(ddlCuentaDestino.SelectedValue);
                objTransaccionRef.fechaTransaccion = objTransaccion.fechaTransaccion;
                objTransaccionRef.eliminado = false;
                objTransaccionRef.idTransaccionRef = objTransaccion.idTransaccion;
                objTransaccionRef.guardar();
                objTransaccion.idTransaccionRef = objTransaccionRef.idTransaccion;
                objTransaccion.modificar();
            }

            if (auxControl)
            {
                MessageBox.Show("La transacción se ha registrado de manera exitosa");
                Response.Redirect("ListadoTransacciones.aspx", true);
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
            else if (ddlTipoTransaccion.SelectedValue.Equals("Traspaso"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
      
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoTransacciones.aspx");
        }

        protected void ddlTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            BRL.tbl_Usuario objUsuario = new BRL.tbl_Usuario();
            objUsuario = (BRL.tbl_Usuario)Session["usuario"];

            if (ddlTipoTransaccion.SelectedValue == "T")
            {
                lblTitulo.Text = "Cuenta Destino";
                ddlConcepto.Visible = false;
                ddlCuentaDestino.Visible = true;
            }
            else
            {
                lblTitulo.Text = "Concepto";
                cargarDDLConcepto(objUsuario.idUsuario, ddlTipoTransaccion.SelectedValue == "E");
                ddlCuentaDestino.Visible = false;
                ddlConcepto.Visible = true;
            }
        }

        protected void ddlTipoTransaccion_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}