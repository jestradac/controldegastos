<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="UI.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CONTROL DE GASTOS</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
	<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- font files -->
	<link href='//fonts.googleapis.com/css?family=Muli:400,300,300italic,400italic' rel='stylesheet' type='text/css'/>
	<link href='//fonts.googleapis.com/css?family=Comfortaa:400,300,700' rel='stylesheet' type='text/css'/>
	<!-- /font files -->
	<!-- css files -->
    <link href="css/login/animate-custom.css" rel="stylesheet" type="text/css" media="all" />
    <link href="css/login/style.css" rel="stylesheet" type="text/css" media="all" />
	<!-- /css files -->
</head>
<body>
    <form id="form1" runat="server">
        <div id="container_demo" >
            <div id="wrapper">
                <div id="login" class="animate form">
                    <h2>Autenticación</h2>
                    <p>
                        <label for="username" class="uname" data-icon="u"><span>Correo Electrónico</span></label>
                        <asp:TextBox ID="txtEmail" placeholder="tucorreoelectrónico@xxxxxxx" MaxLength="50" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <label for="password" class="youpasswd" data-icon="p"><span>Contraseña</span></label>
                        <asp:TextBox ID="txtPassword" TextMode="Password" MaxLength="30" placeholder="Ingresa tu contraseña" runat="server"></asp:TextBox>
                    </p>
                    <p class="login button">
                        <asp:Button ID="btnLogIn" runat="server" Text="Ingresar" OnClick="btnLogIn_Click" />
                    </p>
                    <p class="change_link">
                        <span>¿No tienes cuenta?</span>
                        <a href="SignIn.aspx" class="to_register">Registrate</a>
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
