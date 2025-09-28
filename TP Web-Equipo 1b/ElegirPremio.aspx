<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="ElegirPremio.aspx.cs" Inherits="TP_Web_Equipo_1b.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row  justify-content-center">
        <hr />
        <div class="col-3">
            <div class="card" style="width: 18rem;">
                <asp:Image ID="ImgMochila" CssClass="card-img-top" ImageUrl="https://images.bidcom.com.ar/resize?src=https://www.bidcom.com.ar/publicacionesML/productos/MOCH250X/1000x1000-MOCH250N.jpg&h=400&q=100" AlternateText="Mochila notebook"  style="height:300px; object-fit:contain;" runat="server" />
                <div class="card-body">
                    <h5 class="card-title">Mochila Notebook</h5>
                    <p class="card-text">La mejor mochila que vas a tener.</p>
                    <asp:Button ID="BtnMocila" CssClass="btn btn-primary" runat="server" OnClick="btnMouse_Click" Text="Quiero esta!" />
                </div>
            </div>
        </div>
        <div class="col-3">
            <div class="card" style="width: 18rem;">
                <asp:Image ID="ImgAuriculares" CssClass="card-img-top" ImageUrl="https://repuestosmusicales.com.ar/wp-content/uploads/2020/12/AURICULAR-G9000.jpg" AlternateText="Auriculares gamer"  style="height:300px; object-fit:contain;" runat="server" />
                <div class="card-body">
                    <h5 class="card-title">Auriculares gamer</h5>
                    <p class="card-text">Escucha los pasos del enemigo</p>
                    <asp:Button ID="BtnAuriculares" CssClass="btn btn-primary" runat="server" OnClick="btnMouse_Click" Text="No,este!" />
                </div>
            </div>
        </div>
        <div class="col-3">
            <div class="card" style="width: 18rem;">
                <asp:Image ID="imgMouse" CssClass="card-img-top" ImageUrl="https://http2.mlstatic.com/D_NQ_NP_626531-MLU75736905771_042024-O.webp" AlternateText="Mouse gamer"  style="height:300px; object-fit:contain;" runat="server" />
                <div class="card-body">
                    <h5 class="card-title">Mouse gamer</h5>
                    <p class="card-text">Precision es mi segundo nombre</p>
                    <asp:Button ID="btnMouse"  CssClass="btn btn-primary" runat="server" OnClick="btnMouse_Click" Text="Mejor este!" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
