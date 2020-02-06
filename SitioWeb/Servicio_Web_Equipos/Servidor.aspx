<!--
// ******************************************************************************************
// Arroyo Auz Christian Xavier.                                                             *
// 22/07/2016.                                                                              *
// ******************************************************************************************
-->


<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Servidor.aspx.cs" Inherits="Servidor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Agregamos el titulo de la pagina-->
    <title>Servidor </title>
    <!-- Definimos el fondo de la pagina así como el tamaño del fondo-->
    <style type="text/css">
        .auto-style1 {
            background-image: url('Recursos/Fondo.png');
            height: 661px;
            width: 1047px;
        }
    </style>
</head>
<body>
    <!-- Agregamos el fondo a la pagina web-->
    <form id="ServidorWeb" runat="server" class="auto-style1">
        <asp:Panel ID="panelServidor" runat="server" BackColor="Transparent" GroupingText="Servidor Escuchando:" Height="78px" Width="421px">
            &nbsp;&nbsp;&nbsp;
            <!-- Agregamos la etiqueta para la presentacion de los datos -->
            <asp:Label ID="etiquetaIniciando" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
        </asp:Panel>
    </form>
</body>
</html>