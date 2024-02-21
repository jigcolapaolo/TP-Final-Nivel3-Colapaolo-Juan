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

    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>



            <%--USER--%>
            <%if (!Helper.Seguridad.isAdmin(Session["user"]))
                {%>
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
                        <%--Categoria y Marca--%>
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
                    </div>
                </div>
            </div>
            <%}
                else
                {%>

            <%if (Convert.ToBoolean(Session["vistaAdmin"]) == true)
                {%>
            <%--ADMIN OCN VISTA ADMIN--%>
            <div class="container rounded p-1 pb-5 pb-lg-1">
                <%--FILA 1--%>
                <div class="row">
                    <%--COLUMNA 1--%>
                    <div class="col-12 col-lg-7">
                        <%--ImagenArticulo--%>
                        <div class="d-flex flex-column justify-content-center align-items-center">
                            <asp:Image ImageUrl="./Images/SinImagen.png" ID="imgArticuloAdmin" CssClass="img-fluid rounded"
                                onerror="this.onerror=null;this.src='./Images/SinImagen.png';" Height="450" runat="server" />
                            <input type="file" class="form-control form-control-sm w-75 my-2 my-lg-0 mt-lg-2" id="txtImagen" runat="server" />
                        </div>
                    </div>
                    <%--COLUMNA 2--%>
                    <div class="col-12 col-lg-5 d-flex flex-column justify-content-around bg-success-subtle bg-opacity-75 bg-gradient rounded pt-3 pb-3 px-5">
                        <%--Vista User--%>
                        <div class="d-flex align-self-end">
                            <asp:LinkButton Text="" CssClass="d-flex justify-content-end link-success" ID="linkVista" OnClick="linkVista_Click" runat="server">
                                <small><i class="bi bi-eye me-1"></i>Vista User</small>
                            </asp:LinkButton>
                        </div>
                        <%--Codigo--%>
                        <div class="d-flex flex-column justify-content-start align-items-start">
                            <asp:Label Text="Código" for="txtCodigo" CssClass="form-label fw-bold text-danger-emphasis" runat="server" />
                            <asp:TextBox Text="" ID="txtCodigo" CssClass="form-control" runat="server" />
                        </div>
                        <%--Nombre--%>
                        <div class="d-flex flex-column justify-content-start align-items-start mt-1">
                            <asp:Label Text="Nombre" for="txtNombre" CssClass="form-label fw-bold text-danger-emphasis" runat="server" />
                            <asp:TextBox Text="" ID="txtNombre" CssClass="form-control" runat="server" />
                        </div>
                        <%--Categoria y Marca--%>
                        <div class="d-flex justify-content-around align-items-center my-2">
                            <div class="d-flex flex-column justify-content-start align-items-start">
                                <asp:Label Text="Categoría" for="ddlCategoria" CssClass="form-label fw-bold text-danger-emphasis" runat="server" />
                                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>
                            <div class="d-flex flex-column justify-content-start align-items-start">
                                <asp:Label Text="Marca" for="ddlMarca" CssClass="form-label fw-bold text-danger-emphasis" runat="server" />
                                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <%--Precio--%>
                        <div class="my-2 d-flex flex-column justify-content-start align-items-start">
                            <asp:Label Text="Precio" for="txtPrecio" CssClass="form-label fw-bold text-danger-emphasis" runat="server" />
                            <asp:TextBox Text="" ID="txtPrecio" Type="Number" CssClass="form-control" runat="server" />
                        </div>
                        <%--Descripcion--%>
                        <div class="d-flex flex-column justify-content-start align-items-start">
                            <asp:Label Text="Descripción" for="txtDescripcion" CssClass="form-label fw-bold text-danger-emphasis" runat="server" />
                            <asp:TextBox Text="" TextMode="MultiLine" CssClass="form-control" ID="txtDescripcion" runat="server" />
                        </div>
                        <%--Botones Agregar, Modificar, Eliminar--%>
                        <div class="d-flex justify-content-around align-items-end mt-4">
                            <asp:LinkButton CssClass="btn btn-success btn-sm rounded-pill" runat="server">
                    <i class="bi bi-plus-circle me-1"></i>Agregar
                            </asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-warning btn-sm rounded-pill" runat="server">
                    <i class="bi bi-pencil-square me-1"></i>Modificar
                            </asp:LinkButton>
                            <asp:LinkButton CssClass="btn btn-danger btn-sm rounded-pill" runat="server">
                    <i class="bi bi-trash3 me-1"></i>Eliminar
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
            <%}
                else
                {%>
            <%--ADMIN CON VISTA USER--%>
            <div class="container rounded p-4">
                <%--FILA 1--%>
                <div class="row">
                    <%--COLUMNA 1--%>
                    <div class="col-12 col-lg-7">
                        <%--ImagenArticulo--%>
                        <div class="d-flex justify-content-center align-items-center">
                            <asp:Image ImageUrl="./Images/SinImagen.png" ID="imgArticuloAdminUser" CssClass="img-fluid rounded"
                                onerror="this.onerror=null;this.src='./Images/SinImagen.png';" Height="450" runat="server" />
                        </div>
                    </div>
                    <%--COLUMNA 2--%>
                    <div class="col-12 col-lg-5 d-flex flex-column justify-content-around pt-0 bg-success-subtle bg-opacity-75 bg-gradient rounded p-3 px-5">
                        <%--Vista Admin--%>
                        <div class="d-flex align-self-end">
                            <asp:LinkButton Text="" CssClass="d-flex justify-content-end link-success" ID="linkVistaAdmin" OnClick="linkVistaAdmin_Click" runat="server">
                                <small><i class="bi bi-eye me-1"></i>Vista Admin</small>
                            </asp:LinkButton>
                        </div>
                        <%--Nombre--%>
                        <div class="d-flex justify-content-start align-items-center">
                            <asp:Label Text="" ID="lblNombreAdmin" CssClass="display-6 text-danger text-break" runat="server" />
                        </div>
                        <%--Categoria y Marca--%>
                        <div class="d-flex justify-content-start align-items-center fs-5">
                            <asp:Label Text="" ID="lblCategoriaAdmin" CssClass="text-secondary" runat="server" />
                            <div class="text-secondary mx-1">/</div>
                            <asp:Label Text="" ID="lblMarcaAdmin" CssClass="text-secondary" runat="server" />
                        </div>
                        <%--Precio--%>
                        <div class="my-2 d-flex justify-content-start align-items-center">
                            <asp:Label Text="" ID="lblPrecioAdmin" CssClass="display-5" runat="server" />
                        </div>
                        <%--Descripcion--%>
                        <div class="d-flex flex-column justify-content-start align-items-start">
                            <asp:Label Text="Descripción" CssClass="mb-3 fs-5 text-secondary" runat="server" />
                            <asp:Label Text="" CssClass="text-break" ID="lblDescripcionAdmin" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <%}%>

            <%} %>

            <%--Flecha Volver--%>
            <a href="Index.aspx" class="arrow-up">
                <div class="btn btn-success btn-sm rounded-pill shadow"><i class="bi bi-arrow-left-circle me-2"></i>Volver</div>
            </a>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
