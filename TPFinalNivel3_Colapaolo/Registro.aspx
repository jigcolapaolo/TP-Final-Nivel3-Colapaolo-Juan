<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Registro</title>
    <%--iconos bootstrap--%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <%--Link Bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
        rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />

    <style>
        body {
            font-family: 'Poppins', sans-serif;
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
                border-color: white;
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

</head>



<body class="bg-success bg-opacity-75 bg-gradient d-flex justify-content-center align-items-center min-vh-100">

    <form id="form1" class="mx-3 my-3" runat="server">
        <div class="bg-white p-4 rounded-5 text-secondary shadow container">


            <%--FILA 1--%>
            <div class="row">

                <%--Imagen logo--%>
                <div class="d-flex justify-content-between">
                    <div class="fs-1 fw-bold cursorDefault">Registro</div>
                    <img src="./Images/Logo.png" alt="login-icon" style="height: 4rem" />
                </div>
                <%--Linea--%>
                <div class="border-bottom text-center" style="height: 0.9rem"></div>

            </div>

            <%--FILA 2--%>
            <div class="row mt-4">
                <%--Columna 1--%>
                <div class="col-lg-6 col-12">

                    <%--Email--%>
                    <div class="input-group">
                        <div class="input-group-text bg-warning bg-opacity-75 bg-gradient">
                            <i class="bi bi-envelope"></i>
                        </div>
                        <asp:TextBox CssClass="form-control bg-light" ID="txtEmail" placeholder="Email" runat="server" />
                        <div class="ms-2"><i class="bi bi-asterisk"></i></div>
                    </div>

                    <%--Password--%>
                    <div class="input-group mt-3">
                        <div class="input-group-text bg-warning bg-opacity-75 bg-gradient">
                            <i class="bi bi-lock-fill"></i>
                        </div>
                        <asp:TextBox CssClass="form-control bg-light" ID="txtPassword" placeholder="Password" TextMode="Password" runat="server" />
                        <div class="ms-2"><i class="bi bi-asterisk"></i></div>
                    </div>
                    <%--Confirmar Password--%>
                    <div class="input-group mt-3 mb-5">
                        <div class="input-group-text bg-warning bg-opacity-75 bg-gradient">
                            <i class="bi bi-arrow-right-short"></i>
                        </div>
                        <asp:TextBox CssClass="form-control bg-light" ID="txtConfirmarPass" placeholder="Confirmar Password" TextMode="Password" runat="server" />
                        <div class="ms-2"><i class="bi bi-asterisk"></i></div>
                    </div>

                    <%--Nombre y Apellido--%>
                    <div class="input-group">
                        <span class="input-group-text bg-warning bg-opacity-75 bg-gradient"><i class="bi bi-person-fill"></i></span>
                        <asp:TextBox CssClass="form-control bg-light" ID="txtNombre" placeholder="Nombre" runat="server" />
                        <asp:TextBox CssClass="form-control bg-light" ID="txtApellido" placeholder="Apellido" runat="server" />
                    </div>

                    <div class="h6 mt-4 d-flex justify-content-center"><i class="bi bi-asterisk me-3"></i>Campo Obligatorio</div>

                </div>

                <%--Columna 2--%>
                <div class="col-lg-6 col-12">

                    <div class="d-flex justify-content-center">
                        <asp:Label Text="Su Imagen de Perfil" CssClass="form-label" ID="lblImagenPerfil" AssociatedControlID="" runat="server" />
                    </div>

                    <div class="d-flex justify-content-center">
                        <%--IMAGEN--%>
                        <asp:Image
                            ImageUrl="~/Images/Perfil.png" onerror="this.onerror=null;this.src='./Images/Perfil.png';"
                            runat="server" ID="imgRegistro" CssClass="img-fluid rounded mb-3" Width="" Height="200" />
                    </div>

                    <div class="d-flex justify-content-center">
                        <input type="file" class="form-control form-control-sm w-75" id="txtImagen" runat="server" />
                    </div>

                </div>

            </div>




            <%--FILA 3--%>
            <div class="row">
                <div class="d-flex justify-content-center mt-4">

                    <%--Boton login--%>
                    <asp:Button Text="Registrarse" ID="btnRegistro" CssClass="btn btn-warning bg-gradient text-dark me-4 fw-semibold shadow-sm"
                        UseSubmitBehavior="false" runat="server" />

                    <%--Boton Home--%>
                    <a class="btn rounded-pill shadow" id="homeBtn" aria-current="page" href="Index.aspx"><i class="bi bi-house me-1"></i>Volver a Home
                    </a>
                </div>

            </div>

        </div>
    </form>

    <%--Link Bootstrap--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
