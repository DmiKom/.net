<!--Dmitriy komarov & joseph Brown -->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
       <title style="text-align:center">Adventure Works</title>
       <link rel="stylesheet" type="text/css" href="new.css">
       
</head>
<body>
<form id="form1" runat="server">
<header style="text-align:center; width: 960px; text-align:center; margin-left:auto; margin-right:auto; margin-bottom:5px; margin-top:7px; padding:0;">Details</header>
<body >
<div id="wrapper">

<h1 class="nav">
    <a href="index.aspx">Home</a>
    <a href="aboutUs.aspx">About</a>
    <a href="contact.aspx">Contact</a>
    <a href="product.aspx">Products</a>
    <a href="Cart.aspx">Cart</a>
</h1>
<div id="details" style="color: Black">
    <asp:Image ID="photo" runat="server" />
    <asp:Label ID="Name" runat="server"></asp:Label>
    <asp:Label ID="Number" runat="server"></asp:Label>
    <asp:Label ID="price" runat="server"></asp:Label>
    <asp:Label ID="des" runat="server"></asp:Label>
    <asp:Literal ID="ProID" runat="server" Visible ="false" ></asp:Literal>
    
    <asp:Button ID="Button1" runat="server" Text="Add" />
    
    <div>
        
    </div>
</div>
</div>
</form>

</body>
</html>
