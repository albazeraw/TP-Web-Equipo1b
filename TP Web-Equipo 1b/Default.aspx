<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web_Equipo_1b.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="col-6">
            <hr />
            <div class="mb-3 text-center">
                <h2 class="display-6 fw-bold mb-4">¡Bienvenido al Portal de Vouchers!</h2>
                <p class="mb-4">Canjea tu voucher y obtén increíbles premios</p>
            </div>
            
            <div class="mb-3 text-center">
                <asp:Button ID="btnCanjearVoucher" CssClass="btn btn-primary" runat="server" 
                    OnClick="btnCanjearVoucher_Click" Text="Canjear Voucher" />
            </div>
            <hr />
        </div>
    </div>
</asp:Content>
