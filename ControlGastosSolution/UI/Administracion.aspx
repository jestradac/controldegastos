<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="UI.Administracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-body">
        <div class="row">
            <div class="col-xl-12 col-md-12">
                <div class="card">
                    <div class="card-content">
                        <div class="media align-items-stretch">
                            <div class="p-2 media-middle">
                                <h1 class="success"><asp:Label ID="lblSalgoGlobal" runat="server"></asp:Label></h1>
                            </div>
                            <div class="media-body p-2">
                                <h4>Saldo Global</h4>
                                <span>Estado de Cuentas</span>
                            </div>
                            <div class="media-right bg-success p-2 media-middle rounded-right">
                                <i class="icon-wallet font-large-2 text-white"></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Repeater ID="repCuenta" runat="server" OnItemDataBound="repCuenta_ItemDataBound">
            <ItemTemplate>
                <div class="row">
                    <div class="col-12">
                        <div class="card">
                            <div class="card-header">
                                <h1 class="succes"><asp:Label ID="lblCuentaSaldo" runat="server"></asp:Label></h1>
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
                                <div class="card-content collapse show">
                                    <div class="card-body card-dashboard">
                                        <asp:GridView ID="gvAdministracion" CssClass="table table-striped table-bordered zero-configuration" runat="server" AutoGenerateColumns="false"
                                            GridLines="None" Width="100%" EmptyDataText="- No hay datos -"
                                            OnPageIndexChanging="gvAdministracion_PageIndexChanging"
                                            OnDataBound="gvAdministracion_DataBound" OnRowDataBound="gvAdministracion_RowDataBound" AllowPaging="True" PageSize="20">
                                            <AlternatingRowStyle BackColor="#F0F0F0" Font-Overline="False" Wrap="True" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Fecha">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFecha" runat="server" Text="lblFecha"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Monto">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblMonto" runat="server" Text="lblMonto"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tipo Transacción">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTipo" runat="server" Text="lblTipo"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Concepto">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblConcepto" runat="server" Text="lblConcepto"></asp:Label>
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
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
