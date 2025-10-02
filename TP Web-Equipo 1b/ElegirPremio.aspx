<%@ Page Title="" Language="C#" MasterPageFile="~/miMaster.Master" AutoEventWireup="true" CodeBehind="ElegirPremio.aspx.cs" Inherits="TP_Web_Equipo_1b.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-12 text-center mb-3">
            <h3>¡Código de voucher válido!</h3>
            <p class="text-success">
                <asp:Label ID="lblCodigoVoucher" runat="server" CssClass="fw-bold"></asp:Label>
            </p>
            <p>Selecciona tu premio:</p>
        </div>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4 align-items-strech">
        <%
            int index = 0;//contador para ids unico de los carruseles
            foreach (dominio.articulos articulo in listaArticulos)
            {
                string carouselId = "CarouselIdArticulo" + index;

        %>
        <div class="col">
            <div class="card h-100">
                <div id="<%=carouselId%>" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <% 
                            servicios.gestionImagenes serImg = new servicios.gestionImagenes();
                            var imagenes = serImg.listarPorArticulo(articulo.idArticulo);
                            bool primera = true;
                            foreach (dominio.imagen img in imagenes)
                            {
                        %>
                        <div class="carousel-item <%= primera ? "active" : "" %>">
                            <img src="<%=img.Url%>" class="card-img-top mx-auto d-block" style="height: 350px; max-width: 100%; object-fit: contain;" alt="imagen del articulo" onerror="this.onerror=null; this.src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTVLDP5s2j9u1x86fOb7kNKXanJeMn8zZ30ZQ&s';"/>
                        </div>
                        <%
                                primera = false;
                            } %>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#<%=carouselId%>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon bg-dark" aria-hidden="true"></span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#<%=carouselId%>" data-bs-slide="next">
                        <span class="carousel-control-next-icon bg-dark" aria-hidden="true"></span>
                    </button>
                </div>

                <div class="card-body">
                    <h5 class="card-title"><%:articulo.nombre %></h5>
                    <p class="card-text"><%:articulo.descripcion %></p>
                    <asp:Button ID="btnSelecconar" CssClass="btn btn-primary" OnClick="btnSelecconar_Click" runat="server" Text="Seleccionar" />

                </div>
            </div>
        </div>
        <%
                index++; //incrementa el id para el proximo carrusel
            }%>
    </div>




</asp:Content>
