<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo_1b.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">

        <div class="col-6">
            <hr />
            <div class="mb-3 text-center">
                <label for="txtVoucher" class="form-label">Ingresa el codigo de tu voucher!</label>
                <asp:TextBox ID="TxtCodigoVoucher" runat="server" CssClass="form-control text-center" PlaceHolder="XXXXXXXXXXXXXXX"></asp:TextBox>
            </div>
            
            <!-- Mensaje de error -->
            <div class="mb-3 text-center">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
            </div>
            
            <div class="mb-3 text-center">
                <asp:Button ID="btnSiguiente" CssClass="btn btn-primary" OnClick="btnSiguiente_Click" runat="server" Text="Siguiente" />
                <asp:Button ID="btnInicio" CssClass="btn btn-secondary ms-2" OnClick="btnInicio_Click" runat="server" Text="Ir al Inicio" Visible="false" />
            </div>
            <hr />
        </div>

    </div>
</asp:Content>
