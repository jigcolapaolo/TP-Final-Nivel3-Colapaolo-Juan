<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #sidebar {
            display: none;
            visibility: hidden;
            position: absolute;
            left: -99999px;
        }

        .main {
            margin-left: 0 !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--USER--%>

    <div class="container rounded p-4">
        <%--FILA 1--%>
        <div class="row">
            <%--COLUMNA 1--%>
            <div class="col-12 col-lg-7">
                <%--ImagenArticulo--%>
                <div class="d-flex justify-content-center align-items-center">
                    <asp:Image ImageUrl="./Images/SinImagen.png" ID="imgArticulo" CssClass="img-fluid rounded"
                        onerror="this.onerror=null;this.src='./Images/SinImagen.png';" Height="450" runat="server" />
                </div>
            </div>
            <%--COLUMNA 2--%>
            <div class="col-12 col-lg-5 d-flex flex-column justify-content-around bg-success-subtle bg-opacity-75 bg-gradient rounded p-3 px-5">
                <%--Nombre--%>
                <div class="d-flex justify-content-start align-items-center">
                    <asp:Label Text="" ID="lblNombre" CssClass="display-6 text-danger text-break" runat="server" />
                </div>
                <%--Marca y Categoria--%>
                <div class="d-flex justify-content-start align-items-center fs-5">
                    <asp:Label Text="" ID="lblCategoria" CssClass="text-secondary" runat="server" />
                    <div class="text-secondary mx-1">/</div>
                    <asp:Label Text="" ID="lblMarca" CssClass="text-secondary" runat="server" />
                </div>
                <%--Precio--%>
                <div class="my-2 d-flex justify-content-start align-items-center">
                    <asp:Label Text="" ID="lblPrecio" CssClass="display-5" runat="server" />
                </div>
                <%--Descripcion--%>
                <div class="d-flex flex-column justify-content-start align-items-start">
                    <asp:Label Text="Descripción" CssClass="mb-3 fs-5 text-secondary" runat="server" />
                    <asp:Label Text="" CssClass="text-break" ID="lblDescripcion" runat="server" />
                </div>
                <%--Boton Volver--%>
                <div class="d-flex justify-content-end align-items-end mt-5">
                    <a href="Index.aspx" class="btn btn-outline-success btn-sm rounded-pill"><i class="bi bi-arrow-left-circle me-2"></i>Volver</a>
                </div>
            </div>
        </div>
    </div>



    <%--ADMIN--%>
</asp:Content>
