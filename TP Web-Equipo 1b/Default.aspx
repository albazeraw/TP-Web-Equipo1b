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
            <div class="mb-3 text-center">
                <asp:Button ID="btnSiguiente" CssClass="btn btn-primary" OnClick="btnSiguiente_Click" runat="server" Text="Siguiente" />
            </div>
            <hr />
        </div>

    </div>
</asp:Content>
