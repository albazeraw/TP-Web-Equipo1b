<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="IngresoDatos.aspx.cs" Inherits="TP_Web_Equipo_1b.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row">
            <hr />
            <h2 class="display-6 fw-bold mb-4">Ingresa tus datos</h2>
            <div class="col-4 mb-3">
                <asp:Label ID="LblDni" runat="server" CssClass="form-label" Text="DNI"></asp:Label>
                <asp:TextBox ID="txtDni" CssClass="form-control" runat="server" placeholder="42424242"></asp:TextBox>
            </div>
            <div class="row">
                <div class="col-4 mb-3">
                    <asp:Label ID="lblNombre" runat="server" CssClass="form-label" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" placeholder="Nombre"></asp:TextBox>
                </div>
                <div class="col-4 mb-3">
                    <asp:Label ID="lblApellido" runat="server" CssClass="form-label" Text="Apellido"></asp:Label>
                    <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server" placeholder="Apellido"></asp:TextBox>
                </div>
                <div class="col-4 mb-3">
                    <asp:Label ID="lblEmail" runat="server" CssClass="form-label" Text="Email"></asp:Label>
                    <asp:TextBox ID="TxtEmail" type="email" CssClass="form-control" runat="server" placeholder="nombre@ejemplo.com"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-4 mb-3">
                    <asp:Label ID="lblDireccion" runat="server" CssClass="form-label" Text="Direccion"></asp:Label>
                    <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" placeholder="Calle 123"></asp:TextBox>
                </div>
                <div class="col-4 mb-3">
                    <asp:Label ID="lblCiudad" runat="server" CssClass="form-label" Text="Ciudad"></asp:Label>
                    <asp:TextBox ID="txtCiudad" CssClass="form-control" runat="server" placeholder="Ciudad"></asp:TextBox>
                </div>
                <div class="col-4 mb-3">
                    <asp:Label ID="lblCodigoPostal" runat="server" CssClass="form-label" Text="Codigo Postal"></asp:Label>
                    <asp:TextBox ID="txtCodigoPostal" CssClass="form-control" runat="server" placeholder="XXXX"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3">
                <asp:CheckBox ID="chkboxTerminos" Text="Acepto los terminos y condiciones" runat="server" />
            </div>
            <div class="mb-3">
                <asp:Button ID="btnParticipar" CssClass="btn btn-primary" runat="server" OnClick="btnParticipar_Click" Text="Participar!" />
            </div>
        </div>
    </div>
</asp:Content>
