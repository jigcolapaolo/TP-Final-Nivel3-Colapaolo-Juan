<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.Perfil" %>

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

        .form-control:hover, .form-control:focus, .form-control:active {
            border-color: orange;
            box-shadow: none;
        }

        #homeBtn {
            border: 1px solid #198754;
            color: #198754
        }

            #homeBtn:hover {
                background-image: linear-gradient(to bottom, #198754, #44c767);
                border-color: lightgreen;
                color: white;
            }


        /*Barra de scroll*/
        * {
            scrollbar-width: none; /* Firefox */
            -ms-overflow-style: none; /* IE 10+ */
        }

            *::-webkit-scrollbar {
                display: none; /* WebKit (Safari, Chrome) */
            }
        /*Barra de scroll fin*/
    </style>

    <script>

        function cargarImagenPerfil(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    var imgRegistro = document.getElementById('<%= imgRegistro.ClientID %>');
                    imgRegistro.src = e.target.result;
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
        <ContentTemplate>



            <div class="d-flex justify-content-center align-items-center mt-0 mt-lg-5">

                <div class="bg-success-subtle bg-opacity-75 bg-gradient p-4 rounded-5 text-secondary shadow container mb-3 mb-lg-0">


                    <%--FILA 1--%>
                    <div class="row">

                        <%--Imagen logo--%>
                        <div class="d-flex justify-content-between">
                            <div class="fs-1 fw-bold cursorDefault">Mi Perfil</div>
                            <img src="./Images/Logo.png" alt="login-icon" style="height: 4rem" />
                        </div>
                        <%--Linea--%>
                        <div class="border-bottom border-danger-subtle text-center" style="height: 0.9rem"></div>

                    </div>

                    <%--FILA 2--%>
                    <div class="row mt-4">
                        <%--Columna 1--%>
                        <div class="col-lg-6 col-12">

                            <%--Email--%>
                            <div class="input-group mb-3">
                                <div class="input-group-text bg-warning bg-opacity-75 bg-gradient">
                                    <i class="bi bi-envelope"></i>
                                </div>
                                <asp:TextBox CssClass="form-control bg-light" ID="txtEmail" placeholder="Email" runat="server" />
                            </div>




                            <%--Nombre y Apellido--%>
                            <div class="input-group">
                                <span class="input-group-text bg-warning bg-opacity-75 bg-gradient"><i class="bi bi-person-fill"></i></span>
                                <asp:TextBox CssClass="form-control bg-light" ID="txtNombre" placeholder="Nombre" runat="server" />
                                <asp:TextBox CssClass="form-control bg-light" ID="txtApellido" placeholder="Apellido" runat="server" />
                            </div>

                            <asp:UpdatePanel runat="server" ID="PasswordUpdatePanel" UpdateMode="Conditional">
                                <ContentTemplate>


                                    <%--Password Check--%>
                                    <div class="input-group mt-3 mb-3 d-flex justify-content-center align-items-center">
                                        <asp:CheckBox Text="" CssClass="btn-check rounded-pill" autocomplete="off" ID="passCheck" AutoPostBack="true" OnCheckedChanged="passCheck_CheckedChanged" runat="server" />
                                        <asp:Label Text="¿Cambiar Password?" ID="lblCheck" CssClass="btn btn-sm btn-outline-success rounded-pill" AssociatedControlID="passCheck" runat="server" />
                                    </div>


                                    <%--Password--%>
                                    <div class="input-group mt-3 d-none" id="divPassword" runat="server">
                                        <div class="input-group-text bg-warning bg-opacity-75 bg-gradient">
                                            <i class="bi bi-lock-fill"></i>
                                        </div>
                                        <asp:TextBox CssClass="form-control bg-light" ID="txtPassword" placeholder="Ingresa tu Password Actual" TextMode="Password" runat="server" />
                                    </div>
                                    <%--Nueva Password--%>
                                    <div class="input-group mt-3 mb-3 d-none" id="divNuevaPass" runat="server">
                                        <div class="input-group-text bg-warning bg-opacity-75 bg-gradient">
                                            <i class="bi bi-arrow-right-short"></i>
                                        </div>
                                        <asp:TextBox CssClass="form-control bg-light" ID="txtNuevaPass" placeholder="Ingresa tu nueva Password" TextMode="Password" runat="server" />
                                    </div>


                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="passCheck" EventName="CheckedChanged" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>

                        <%--Columna 2--%>
                        <div class="col-lg-6 col-12">



                            <div class="d-flex justify-content-center">
                                <%--IMAGEN--%>
                                <asp:Image
                                    ImageUrl="~/Images/Perfil.png" onerror="this.onerror=null;this.src='./Images/Perfil.png';"
                                    runat="server" ID="imgRegistro" CssClass="img-fluid rounded-pill mb-3 mt-4 mt-lg-0" Height="200" />
                            </div>

                            <div class="d-flex justify-content-center">
                                <input type="file" onchange="cargarImagenPerfil(this)" class="form-control form-control-sm w-75" id="txtImagen" runat="server" />
                            </div>

                        </div>

                    </div>




                    <%--FILA 3--%>
                    <div class="row">
                        <div class="d-flex justify-content-center mt-4">

                            <%--Boton Guardar--%>
                            <asp:Button Text="Guardar" ID="btnGuardar" CssClass="btn btn-warning bg-gradient text-dark me-4 fw-semibold shadow-sm"
                                UseSubmitBehavior="false" OnClick="btnGuardar_Click" runat="server" />

                            <%--Boton Home--%>
                            <a class="btn rounded-pill shadow" id="homeBtn" aria-current="page" href="Index.aspx"><i class="bi bi-house me-1"></i>Volver a Home
                            </a>
                        </div>

                    </div>

                </div>

            </div>

        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnGuardar" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
