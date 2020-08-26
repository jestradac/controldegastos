<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Cuenta.aspx.cs" Inherits="UI.Cuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header row">
        <div class="content-header-left col-md-8 col-12 mb-2 breadcrumb-new">
            <h3 class="content-header-title mb-0 d-inline-block">Administración de Cuentas / Monderos</h3>
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
                                        <h4 class="form-section"><i class="icon-wallet"></i>Registro de Cuenta / Monedero</h4>
                                        <div class="form-group row">
                                            <label class="col-md-3 label-control" for="projectinput1">Nombre</label>
                                            <div class="col-md-9">
                                                <asp:TextBox ID="txbNombre" class="form-control" placeholder="Nombre de la Cuenta/Monedero" name="fname" MaxLength="50" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-actions">
                                            <asp:Button ID="btnGuardar" class="btn btn-success mr-1" runat="server" Text="Guardar" OnClick="btnGuardar_Click"></asp:Button>
                                            <asp:Button ID="btnCancelar" class="btn btn-warning" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />

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

