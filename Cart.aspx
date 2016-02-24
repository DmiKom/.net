<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="Cart" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <title style="text-align:center">Adventure Works</title>
    
<link rel="stylesheet" type="text/css" href="new.css">
    <meta charset="UTF-8" />
</head>
<body>
<div id="wrapper">
<header style="text-align:center">About Us</header>
<h1 class="nav">
    <a href="index.aspx">Home</a>
    <a href="aboutUs.aspx">About</a>
    <a href="contact.aspx">Contact</a>
    <a href="product.aspx">Products</a>
    <a href="Cart.aspx">Cart</a>
</h1>
<asp:literal id ="on" visible="false"  runat="server"></asp:literal>
       <tr>
        <td align="left" valign="top" bgcolor="FFFDED">
            <table width="559" height="100%" border="0" cellpadding="0" cellspacing="0" class="text">
                <tr>
                    <td align="center" valign="top" bgcolor="FFFDED">
                        <table width="530" border="0" cellpadding="0" cellspacing="0" class="text">
                            <tr>
                                <td>&nbsp; </td>
                            </tr>
                            <tr valign="top">
                                <td align="left">
                                    <form id="form1" runat="server">
                                    <div>
                                        <p>
                                            <p><asp:Literal ID="CartBody" runat="server"></asp:Literal></p>
                                                    <asp:Label ID="Name" runat="server"></asp:Label>
                                                     <asp:Button ID="Buy" runat="server" Text="Buy Now" 
                                                        onclick="Buy_onClick"/>
                                                     <asp:Label ID="tmp1" Text="poo" Visible="false" runat="server"></asp:Label>
                                    </div>
                                    </form>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
   

        </div>
</body>
</html>


