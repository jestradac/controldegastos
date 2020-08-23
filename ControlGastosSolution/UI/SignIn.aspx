<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="UI.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CONTROL DE GASTOS</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    
	<%--<script type="application/x-javascript"> 
        addEventListener("load", function() { setTimeout(hideURLbar, 1); }, true); function hideURLbar(){ window.scrollTo(0,1); } </script>--%>
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
        <div id="wrapper">
            <div id="login" class="animate form">
                <%--                    <form  action="#" method="post" autocomplete="on"> --%>
                <h2>Registro </h2>
                <p>
                    <label for="usernamesignup" class="uname" data-icon=" "><span>Nombre Completo</span></label>
                    <asp:TextBox ID="txtNombreCompleto" placeholder="Nombre Completo" MaxLength="50" runat="server"></asp:TextBox>
                </p>
                <p>
                    <label for="emailsignup" class="youmail" data-icon=" "><span>Correo Electrónico</span></label>
                    <asp:TextBox ID="txtEmailSigIn" placeholder="ejemplo@xxxxxxx" MaxLength="50" runat="server"></asp:TextBox>
                </p>
                <p>
                    <label for="passwordsignup" class="youpasswd" data-icon=" "><span>Contraseña</span></label>
                    <asp:TextBox ID="txtPasswordSignIn" TextMode="Password" MaxLength="30" placeholder="Ingresa tu contraseña" runat="server"></asp:TextBox>
                </p>
                <p>
                    <label for="passwordsignup_confirm" class="youpasswd" data-icon=" "><span>Confirmar Contraseña</span></label>
                    <asp:TextBox ID="txtCPassword" TextMode="Password" MaxLength="30" placeholder="Confirma tu contraseña" runat="server"></asp:TextBox>
                </p>
                <p class="signin button">
                    <asp:Button ID="btnSignIn" runat="server" Text="Registrar" OnClick="btnSignIn_Click" />
                </p>
                <p class="change_link">
                    <span>¿Ya tienes cuenta?</span>
                    <a href="LogIn.aspx" class="to_register">Ingresa</a>
                </p>
                <%--                    </form>--%>
            </div>
        </div>
    </form>
</body>
</html>
