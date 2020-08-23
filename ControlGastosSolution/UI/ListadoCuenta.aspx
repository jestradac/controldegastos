<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoCuenta.aspx.cs" Inherits="UI.ListadoCuenta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnAgregar" runat="server" Text="+ Cuenta" onclick="btnAgregar_Click"/>
            <br />
            <div>
                <asp:GridView ID="gvCuenta" runat="server" AutoGenerateColumns="false"
                GridLines="None" Width="100%" EmptyDataText="- No hay datos -"
                onpageindexchanging="gvCuenta_PageIndexChanging"
                ondatabound="gvCuenta_DataBound" OnRowDataBound="gvCuenta_RowDataBound" AllowPaging="True" PageSize="20">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEditar" runat="server">Editar</asp:HyperLink>
                                &nbsp;<asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click">X</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label ID="lblNombre" runat="server" Text="lblNombre"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
