<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="ElegirPremio.aspx.cs" Inherits="TP_Web_Equipo_1b.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4 aligin-items-strech">
        <%
            foreach (dominio.articulos articulo in listaArticulos)
            {%>
            <div class="card h-100">
                <img src="<%:articulo.imagenUrl%>" class="card-img-top" alt="..." style="height:200px; object-fit:contain;">
                <div class="card-body">
                    <h5 class="card-title"><%:articulo.nombre %></h5>
                    <p class="card-text"><%:articulo.descripcion %></p>
                    <asp:Button ID="btnSelecconar" CssClass="btn btn-primary" OnClick="btnSelecconar_Click" runat="server" Text="Seleccionar" />
                </div>
            </div>
            <%}%>
    </div>
            
</asp:Content>
