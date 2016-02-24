<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Log.aspx.cs" Inherits="Log" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <link rel="stylesheet" type="text/css" href="new.css">
</head>
<body>
<div id="wrapper">
<header style="text-align:center">Log In</header>
<h1 class="nav">
    <a href="index.aspx">Home</a>
    <a href="aboutUs.aspx">About</a>
    <a href="contact.aspx">Contact</a>
    <a href="product.aspx">Products</a>
    <a href="Cart.aspx">Cart</a>
</h1>
    <form id="form1" runat="server">
        <div id="loginForm">
            <p>
            LoginID is 1<br />
            <asp:TextBox ID="LoginID" runat="server" Width="200px"></asp:TextBox></p>
            <p>
            Password is bE3XiWw<br />
            <asp:TextBox ID="password" runat="server" Width="200px" TextMode="Password"></asp:TextBox></p>
            <asp:Literal ID="badLogin" runat="server"></asp:Literal>
            <p>
            <asp:Button ID="Login" runat="server" Text="Login" />
            </p>
        </div>
    </form>
    </div>
</body>
</html>
