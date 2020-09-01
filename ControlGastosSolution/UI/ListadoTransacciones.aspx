<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListadoTransacciones.aspx.cs" Inherits="UI.ListadoTransacciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header row">
        <div class="content-header-left col-md-8 col-12 mb-2 breadcrumb-new">
            <h3 class="content-header-title mb-0 d-inline-block">Administración de Transacciones</h3>
        </div>
        <div class="content-header-left col-md-8 col-12 mb-2 breadcrumb-new">
            <asp:Button ID="btnAgregar" class="btn btn-success btn-min-width mr-1 mb-1" runat="server" Text="Agregar" onClick="btnAgregar_Click"/>
        </div>
    </div>

    <div>
        <section id="configuration">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Listado de Transacciones</h4>
                            <a class="heading-elements-toggle"><i class="fa fa-ellipsis-v font-medium-3"></i></a>
                            <div class="heading-elements">
                                <ul class="list-inline mb-0">
                                    <li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                                    <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                                    <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="card-content collapse show">
                            <div class="card-body card-dashboard">
                                <asp:GridView ID="gvTransaccion" CssClass="table table-striped table-bordered zero-configuration" runat="server" AutoGenerateColumns="false"
                                    GridLines="None" Width="100%" EmptyDataText="- No hay datos -"
                                    OnPageIndexChanging="gvTransaccion_PageIndexChanging"
                                    OnDataBound="gvTransaccion_DataBound" OnRowDataBound="gvTransaccion_RowDataBound" AllowPaging="True" PageSize="20">
                                    <AlternatingRowStyle BackColor="#F0F0F0" Font-Overline="False" Wrap="True" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Opciones">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlEditar" runat="server"><i class="ft-edit"></i></asp:HyperLink>
                                                &nbsp;<asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click"><i class="ft-trash-2"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha de Transacción">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFechaTransaccion" runat="server" Text="lblFechaTransaccion"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Monto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSigno" runat="server" Text=""></asp:Label>
                                                <asp:Label ID="lblMonto" runat="server" Text="lblMonto"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Concepto">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConcepto" runat="server" Text="lblConcepto"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cuenta">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCuenta" runat="server" Text="lblCuenta"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="Silver" HorizontalAlign="Left" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
