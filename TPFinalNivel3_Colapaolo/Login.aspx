<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title></title>
    <%--iconos bootstrap--%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <%--Link Bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
        rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous">

    <style>
        body {
            font-family: 'Poppins', sans-serif;
        }

        a:hover {
            color: orange;
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
    </style>

</head>


<body class="bg-success bg-opacity-75 bg-gradient d-flex justify-content-center align-items-center vh-100">

    <form id="form2" runat="server">


        <div class="bg-white p-4 rounded-5 text-secondary shadow" style="width: 25rem">
            <%--Imagen logo--%>
            <div class="d-flex justify-content-center">
                <img src="./Images/Logo.png" alt="login-icon" style="height: 7rem" />
            </div>
            <%--Linea--%>
            <div class="border-bottom text-center" style="height: 0.9rem"></div>

            <%--User--%>
            <div class="input-group mt-4">
                <div class="input-group-text bg-warning bg-opacity-75 bg-gradient">
                    <i class="bi bi-person-fill"></i>
                </div>
                <input class="form-control bg-light" type="text" placeholder="User" />
            </div>
            <%--Password--%>
            <div class="input-group mt-1">
                <div class="input-group-text bg-warning bg-opacity-75 bg-gradient">
                    <i class="bi bi-lock-fill"></i>
                </div>
                <input class="form-control bg-light" type="password" placeholder="Password" />
            </div>

            <%--Boton login--%>
            <div class="btn btn-warning bg-gradient text-white-emphasis w-100 mt-4 fw-semibold shadow-sm">
                Ingresar
            </div>
            <%--Registro--%>
            <div class="d-flex gap-1 justify-content-center mt-1">
                <div>¿No tenés una cuenta?</div>
                <a href="#" class="link-danger text-decoration-none fw-semibold">Registrate</a>
            </div>

            <%--Boton Home--%>
            <div class="d-flex justify-content-center mt-4">
                <a class="btn rounded-pill" id="homeBtn" aria-current="page" href="Index.aspx"><i class="bi bi-house me-1"></i>Volver a Home
                </a>
            </div>
        </div>


    </form>

    <%--Link Bootstrap--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
