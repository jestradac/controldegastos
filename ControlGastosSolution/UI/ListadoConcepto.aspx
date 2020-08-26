<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="ListadoConcepto.aspx.cs" Inherits="UI.ListadoConcepto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-header row">
        <div class="content-header-left col-md-8 col-12 mb-2 breadcrumb-new">
            <h3 class="content-header-title mb-0 d-inline-block">Administración de Conceptos</h3>
        </div>
        <div class="content-header-left col-md-8 col-12 mb-2 breadcrumb-new">
            <asp:Button ID="btnAgregar" class="btn btn-success btn-min-width mr-1 mb-1" runat="server" Text="Agregar" onclick="btnAgregar_Click"/>
        </div>
    </div>

    <div>
        <section id="configuration">
            <div class="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Listado de Conceptos</h4>
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
                                <asp:GridView ID="gvConcepto" CssClass="table table-striped table-bordered zero-configuration" runat="server" AutoGenerateColumns="false"
                                    GridLines="None" Width="100%" EmptyDataText="- No hay datos -"
                                    OnPageIndexChanging="gvConcepto_PageIndexChanging"
                                    OnDataBound="gvConcepto_DataBound" OnRowDataBound="gvConcepto_RowDataBound" AllowPaging="True" PageSize="20">
                                    <AlternatingRowStyle BackColor="#F0F0F0" Font-Overline="False" Wrap="True" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Opciones">
                                            <ItemTemplate>
                                                <asp:HyperLink ID="hlEditar" runat="server"><i class="ft-edit"></i></asp:HyperLink>
                                                &nbsp;<asp:LinkButton ID="lbEliminar" runat="server" OnClick="lbEliminar_Click"><i class="ft-trash-2"></i></asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNombre" runat="server" Text="lblNombre"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tipo de Transacción">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTipoTransaccion" runat="server" Text="lblTipoTransaccion"></asp:Label>
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