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

    <script>

        //Funciones para abrir o cerrar el modal, esta funcion se ejecuta desde el codebehind
        function AbrirModal() {
            var modal = document.getElementById('modalEliminarArt');
            if (modal) {
                modal.classList.add('show');
                modal.style.display = 'block';
                var backdrop = document.createElement('div');
                backdrop.classList.add('modal-backdrop', 'fade', 'show');
                document.body.appendChild(backdrop);
            }
        }

        function CerrarModal() {
            var modal = document.getElementById('modalEliminarArt');
            if (modal) {
                modal.classList.remove('show');
                modal.style.display = 'none';
                var backdrop = document.querySelector('.modal-backdrop');
                if (backdrop) {
                    document.body.removeChild(backdrop);
                }
            }
        }

        function cargarImagen(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    var imgArticuloAdmin = document.getElementById('<%= imgArticuloAdmin.ClientID %>');
                    imgArticuloAdmin.src = e.target.result;
                }

                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>




            <%--USER--%>
            <%if (!Helper.Seguridad.isAdmin(Session["user"]))
                {

            %>
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
                        <%if (Helper.Seguridad.sesionActiva(Session["user"]))
                            {%>
                        <div class="position-relative pb-5">
                            <div class="text-warning h2 position-absolute bottom-0 end-0">
                                <asp:CheckBox ID="chkFavoritoUser" runat="server" OnCheckedChanged="chkFavoritoUser_CheckedChanged" CssClass="btn-check" AutoPostBack="true" />
                                <asp:Label Text="" CssClass="form-check-label bi bi-star" AssociatedControlID="chkFavoritoUser" ID="lblStarUser" runat="server" />
                            </div>
                        </div>
                        <%} %>

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
            <%--ADMIN CON VISTA ADMIN--%>
            <div class="container rounded p-1 pb-5 pb-lg-1">
                <%--FILA 1--%>
                <div class="row">
                    <%--COLUMNA 1--%>
                    <div class="col-12 col-lg-7">
                        <%--ImagenArticulo--%>
                        <div class="d-flex flex-column justify-content-center align-items-center">
                            <asp:Image ImageUrl="./Images/SinImagen.png" ID="imgArticuloAdmin" CssClass="img-fluid rounded"
                                onerror="this.onerror=null;this.src='./Images/SinImagen.png';" Height="450" runat="server" />
                            <input type="file" onchange="cargarImagen(this)" class="form-control form-control-sm w-75 my-2 my-lg-0 mt-lg-2" id="txtImagen" runat="server" />
                        </div>
                    </div>
                    <%--COLUMNA 2--%>
                    <div class="col-12 col-lg-5 d-flex flex-column justify-content-around bg-success-subtle bg-opacity-75 bg-gradient rounded pt-3 pb-3 px-5">

                        <%--Oculto el cambio de vista si no hay un articulo--%>
                        <%if (articulo != null)
                            {%>
                        <%--Vista User--%>
                        <div class="d-flex align-self-end">
                            <asp:LinkButton Text="" CssClass="d-flex justify-content-end link-success" ID="linkVista" OnClick="linkVista_Click" runat="server">
                                <small><i class="bi bi-eye me-1"></i>Vista User</small>
                            </asp:LinkButton>
                        </div>
                        <%} %>



                        <%--Codigo--%>
                        <div class="d-flex flex-column justify-content-start align-items-start">
                            <asp:Label Text="" for="txtCodigo" CssClass="form-label fw-bold text-danger-emphasis" runat="server">
                                <small><i class="bi bi-asterisk"></i></small>Código
                            </asp:Label>
                            <asp:TextBox Text="" ID="txtCodigo" CssClass="form-control" runat="server" />
                        </div>
                        <%--Nombre--%>
                        <div class="d-flex flex-column justify-content-start align-items-start mt-1">
                            <asp:Label Text="" for="txtNombre" CssClass="form-label fw-bold text-danger-emphasis" runat="server">
                                <small><i class="bi bi-asterisk"></i></small>Nombre
                            </asp:Label>
                            <asp:TextBox Text="" ID="txtNombre" CssClass="form-control" runat="server" />
                        </div>
                        <%--Categoria y Marca--%>
                        <div class="d-flex justify-content-around align-items-center my-2">
                            <div class="d-flex flex-column justify-content-start align-items-start">
                                <asp:Label Text="" for="ddlCategoria" CssClass="form-label fw-bold text-danger-emphasis" runat="server">
                                    <small><i class="bi bi-asterisk"></i></small>Categoría
                                </asp:Label>
                                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>
                            <div class="d-flex flex-column justify-content-start align-items-start">
                                <asp:Label Text="Marca" for="ddlMarca" CssClass="form-label fw-bold text-danger-emphasis" runat="server">
                                    <small><i class="bi bi-asterisk"></i></small>Marca
                                </asp:Label>
                                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <%--Precio--%>
                        <div class="my-2 d-flex flex-column justify-content-start align-items-start">
                            <asp:Label Text="" for="txtPrecio" CssClass="form-label fw-bold text-danger-emphasis" runat="server">
                                <small><i class="bi bi-asterisk"></i></small>Precio
                            </asp:Label>
                            <asp:TextBox Text="" ID="txtPrecio" Type="Number" step="0.1" CssClass="form-control" runat="server" />
                        </div>
                        <%--Descripcion--%>
                        <div class="d-flex flex-column justify-content-start align-items-start">
                            <asp:Label Text="Descripción" for="txtDescripcion" CssClass="form-label fw-bold text-danger-emphasis" runat="server" />
                            <asp:TextBox Text="" TextMode="MultiLine" CssClass="form-control" ID="txtDescripcion" runat="server" />
                        </div>
                        <%--Campo Obligatorio--%>
                        <div class="mt-2 d-flex justify-content-center"><i class="bi bi-asterisk"></i>Campo Obligatorio</div>
                        <%--Botones Agregar, Modificar, Eliminar--%>
                        <div class="d-flex justify-content-around align-items-end mt-4">


                            <%if (articulo == null)
                                {%>
                            <%--Agregar--%>
                            <asp:LinkButton ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-success btn-sm rounded-pill" runat="server">
                                <i class="bi bi-plus-circle me-1"></i>Agregar
                            </asp:LinkButton>
                            <% }
                                else
                                {%>
                            <%--Modificar--%>
                            <asp:LinkButton CssClass="btn btn-warning btn-sm rounded-pill" ID="btnModificar" OnClick="btnModificar_Click" runat="server">
                                <i class="bi bi-pencil-square me-1"></i>Modificar
                            </asp:LinkButton>
                            <%--Eliminar--%>
                            <asp:LinkButton ID="btnEliminar" data-bs-toggle="modal" data-bs-target="#modalEliminarArt"
                                CssClass="btn btn-danger btn-sm rounded-pill" runat="server">
                                <i class="bi bi-trash3 me-1"></i>Eliminar
                            </asp:LinkButton>
                            <% } %>
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
                    <div class="col-12 col-lg-5 d-flex flex-column justify-content-around pt-lg-0 bg-success-subtle bg-opacity-75 bg-gradient rounded p-3 px-5">
                        <div class="position-relative pb-5">
                            <%--Icono favorito--%>
                            <div class="text-warning h2 position-absolute bottom-0 start-0">
                                <asp:CheckBox ID="chkFavoritoAdmin" CssClass="" OnCheckedChanged="chkFavoritoAdmin_CheckedChanged" AutoPostBack="true" runat="server" />
                                <asp:Label Text="" CssClass="form-check-label bi bi-star" AssociatedControlID="chkFavoritoAdmin" ID="lblStarAdmin" runat="server" />
                            </div>

                            <%--Oculto el cambio de vista si no hay un articulo--%>

                            <%if (articulo != null)
                                {%>
                            <div class="d-flex align-self-end">
                                <asp:LinkButton Text="" CssClass="link-success position-absolute top-0 end-0" ID="linkVistaAdmin" OnClick="linkVistaAdmin_Click" runat="server">
                                <small><i class="bi bi-eye me-1"></i>Vista Admin</small>
                                </asp:LinkButton>
                            </div>
                            <% } %>
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
            <asp:LinkButton Text="" ID="btnVolver" OnClick="btnVolver_Click" CssClass="btn btn-success btn-sm rounded-pill shadow arrow-up" runat="server"><i class="bi bi-arrow-left-circle me-2"></i>Volver</asp:LinkButton>

            <!-- Modal Eliminar -->
            <div class="modal fade" id="modalEliminarArt" tabindex="-1" aria-labelledby="modalEliminarArtLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header no-border">
                            <h1 class="modal-title fs-5" id="modalEliminarArtLabel">¿Eliminar Artículo?</h1>
                            <asp:Button Text="" CssClass="btn-close" ID="btnClose" data-bs-dismiss="modal" aria-label="Close" runat="server" />
                        </div>
                        <div class="modal-footer no-border d-flex justify-content-center align-items-center">
                            <asp:Button Text="Si" CssClass="btn btn-danger" ID="btnModalEliminarArt" UseSubmitBehavior="false" OnClick="btnModalEliminarArt_Click" runat="server" />
                            <asp:Button Text="No" CssClass="btn btn-secondary" ID="btnModalCerrar" data-bs-dismiss="modal" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAgregar" />
            <asp:PostBackTrigger ControlID="btnModificar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
