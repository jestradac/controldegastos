<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Transaccion.aspx.cs" Inherits="UI.Transaccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header row">
        <div class="content-header-left col-md-8 col-12 mb-2 breadcrumb-new">
            <h3 class="content-header-title mb-0 d-inline-block">Administración de Transacciones</h3>
        </div>
    </div>
    <div class="content-body">
        <section id="horizontal-form-layouts">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <a class="heading-elements-toggle"><i class="fa fa-ellipsis-v font-medium-3"></i></a>
                            <div class="heading-elements">
                                <ul class="list-inline mb-0">
                                    <li><a data-action="collapse"><i class="ft-minus"></i></a></li>
                                    <li><a data-action="reload"><i class="ft-rotate-cw"></i></a></li>
                                    <li><a data-action="expand"><i class="ft-maximize"></i></a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="card-content collpase show">
                            <div class="card-body">
                                <div class="form form-horizontal">
                                    <div class="form-body">
                                        <h4 class="form-section"><i class="icon-wallet"></i>Registro de Transacciones</h4>
                                        <div class="form-group row">
                                            <label class="col-md-3 label-control" for="projectinput1">Monto</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txbMonto" class="form-control"  TextMode="Number" step=".01" placeholder="00.01" name="fname" MaxLength="10" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 label-control" for="projectinput6">Tipo de Transacción</label>
                                            <div class="col-md-9">
                                                <asp:DropDownList class="form-control" ID="ddlTipoTransaccion" runat="server" OnSelectedIndexChanged="ddlTipoTransaccion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 label-control" for="projectinput6">Cuenta</label>
                                            <div class="col-md-9">
                                                <asp:DropDownList class="form-control" ID="ddlCuenta" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group row">
                                            <label class="col-md-3 label-control" for="projectinput6"><asp:Label runat="server" ID="lblTitulo"></asp:Label></label>
                                            <div class="col-md-9">
                                                <asp:DropDownList class="form-control" ID="ddlCuentaDestino" runat="server"></asp:DropDownList>
                                                <asp:DropDownList class="form-control" ID="ddlConcepto" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-actions">
                                            <asp:Button ID="Button1" class="btn btn-success mr-1" runat="server" Text="Guardar" OnClick="btnGuardar_Click"></asp:Button>
                                            <asp:Button ID="Button2" class="btn btn-warning" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
