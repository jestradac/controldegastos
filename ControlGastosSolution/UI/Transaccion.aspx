<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transaccion.aspx.cs" Inherits="UI.Transaccion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <label>Monto:</label>
                <asp:TextBox ID="txbMonto" TextMode="Number" MaxLength="10" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Fecha de Transacción:</label>
                <asp:TextBox ID="txbFechaTrasaccion" TextMode="Date" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Tipo de Transacción:</label>
                <asp:DropDownList ID="ddlTipoTransaccion" runat="server" onselectedindexchanged="ddlTipoTransaccion_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem>Ingreso</asp:ListItem>
                    <asp:ListItem>Egreso</asp:ListItem>
                    <asp:ListItem>Traspaso</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <label id="lblCuentaOrigen">Cuenta:</label>
                <asp:DropDownList ID="ddlCuenta" runat="server">
                </asp:DropDownList>
            </div>
            <div>
                <label id="lblConcepto">Concepto:</label>
                <asp:DropDownList ID="ddlConcepto" runat="server" >
                </asp:DropDownList>
            </div>
            <div>
                <label id="lblCuentDestino">Cuenta Destino:</label>
                <asp:DropDownList ID="ddlCuentaDestino" runat="server">
                </asp:DropDownList>
            </div>
            <div>
                <label id="lblConceptoDestino">Concepto:</label>
                <asp:DropDownList ID="ddlConceptoDestino" runat="server" >
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
