<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.ListaArticulos" %>

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

        .white-hover:hover {
            color: white;
        }

        .dark-hover:hover {
            color: black;
        }

        .pager-links a {
            color: green;
        }

            .pager-links a:hover {
                color: orange;
            }
    </style>

    <script>

        //Funciones para abrir o cerrar el modal, esta funcion se ejecuta desde el codebehind
        function AbrirModal() {
            var modal = document.getElementById('exampleModal');
            if (modal) {
                modal.classList.add('show');
                modal.style.display = 'block';
                var backdrop = document.createElement('div');
                backdrop.classList.add('modal-backdrop', 'fade', 'show');
                document.body.appendChild(backdrop);
            }
        }

        function CerrarModal() {
            var modal = document.getElementById('exampleModal');
            if (modal) {
                modal.classList.remove('show');
                modal.style.display = 'none';
                var backdrop = document.querySelector('.modal-backdrop');
                if (backdrop) {
                    document.body.removeChild(backdrop);
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat="server" ID="ScriptManager1" />
    <asp:UpdatePanel runat="server">
        <ContentTemplate>




            <div class="container-fluid border-bottom border-success-subtle mb-3">
                <h1 class="display-6">Lista de Artículos</h1>
            </div>

            <div class="d-lg-block d-none container-fluid bg-success-subtle rounded p-4 vh-80">



                <%--GRID CON PAGINATION--%>
                <%--Pantalla grande--%>
                <asp:GridView ID="dgvArticulos" CssClass="table table-dark table-bordered table-striped-columns table-hover"
                    AutoGenerateColumns="false" runat="server" OnRowCommand="dgvArticulos_RowCommand" RowStyle-CssClass="table-light"
                    DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
                    OnPageIndexChanging="dgvArticulos_PageIndexChanging" PagerStyle-CssClass="table-warning pager-links"
                    AllowPaging="True" PageSize="5">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                        <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                        <asp:BoundField HeaderText="Precio" DataField="Precio" />

                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <div class="d-flex justify-content-center align-items-center">
                                    <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>'
                                        CssClass="btn btn-outline-success bi bi-pencil-square dark-hover no-border rounded-pill p-1"
                                        Text=""></asp:LinkButton>
                                    <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'
                                        CssClass="btn btn-outline-danger bi bi-trash3 rounded-pill white-hover no-border p-1 ms-3"
                                        Text=""></asp:LinkButton>

                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>

                <asp:LinkButton Text="" CssClass="btn btn-success rounded" ID="btnAgregarLg" OnClick="btnAgregarLg_Click" runat="server">
                    <i class="bi bi-plus-circle me-1"></i>Nuevo Artículo
                </asp:LinkButton>
            </div>

            <%--Pantalla chica--%>
            <div class="d-lg-none container-fluid bg-success-subtle rounded p-4 max-vh-100 mb-4">

                <asp:GridView ID="dgvArticulosSm" CssClass="table table-dark table-bordered table-striped-columns table-hover"
                    AutoGenerateColumns="false" runat="server" OnRowCommand="dgvArticulos_RowCommand"
                    DataKeyNames="Id" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" RowStyle-CssClass="table-light grid-borde"
                    OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="True" PageSize="5" PagerStyle-CssClass="table-warning pager-links">
                    <Columns>
                        <asp:TemplateField HeaderText="Detalles">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-md-12">
                                        <strong>Nombre: </strong>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label><br />
                                        <strong>Código: </strong>
                                        <asp:Label ID="lblCodigo" runat="server" Text='<%# Eval("Codigo") %>'></asp:Label><br />
                                        <strong>Marca: </strong>
                                        <asp:Label ID="lblMarca" runat="server" Text='<%# Eval("Marca.Descripcion") %>'></asp:Label><br />
                                        <strong>Categoría: </strong>
                                        <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("Categoria.Descripcion") %>'></asp:Label><br />
                                        <strong>Precio: </strong>
                                        <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("Precio") %>'></asp:Label><br />
                                        <div class="d-flex justify-content-center align-items-center">
                                            <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("Id") %>'
                                                CssClass="btn btn-outline-success bi bi-pencil-square dark-hover no-border rounded-pill p-1"
                                                Text=""></asp:LinkButton>
                                            <asp:LinkButton ID="btnEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>'
                                                CssClass="btn btn-outline-danger bi bi-trash3 rounded-pill white-hover no-border p-1 ms-3"
                                                Text=""></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


                <asp:LinkButton Text="" CssClass="btn btn-success rounded" ID="btnAgregarSm" OnClick="btnAgregarSm_Click" runat="server">
                    <i class="bi bi-plus-circle me-1"></i>Nuevo Artículo
                </asp:LinkButton>
            </div>


            <!-- Modal eliminar -->
            <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-sm">
                    <div class="modal-content">
                        <div class="modal-header no-border">
                            <h1 class="modal-title fs-5" id="exampleModalLabel">¿Eliminar Artículo?</h1>
                            <asp:Button Text="" CssClass="btn-close" ID="btnClose" OnClick="btnClose_Click"
                                data-bs-dismiss="modal" aria-label="Close" runat="server" />
                        </div>
                        <div class="modal-footer no-border d-flex justify-content-center align-items-center">
                            <asp:Button Text="Si" CssClass="btn btn-danger" ID="btnModalEliminar" OnClick="btnModalEliminar_Click" runat="server" />
                            <asp:Button Text="No" CssClass="btn btn-secondary" ID="btnModalCerrar" data-bs-dismiss="modal" OnClick="btnModalCerrar_Click" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
