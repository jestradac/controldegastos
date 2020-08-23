<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Concepto.aspx.cs" Inherits="UI.Concepto" %>

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
                <label>Nombre:</label>
                <asp:TextBox ID="txbNombre" MaxLength="50" runat="server"></asp:TextBox>
            </div>
            <div>
                <label>Tipo de Transacción:</label>
                <asp:DropDownList ID="ddlTipoTransaccion" runat="server">
                    <asp:ListItem>Ingreso</asp:ListItem>
                    <asp:ListItem>Egreso</asp:ListItem>
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
