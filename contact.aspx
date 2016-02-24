
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="_contact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Adventure Works</title>
   
    <link href="new.css" rel="Stylesheet" type="text/css" />
</head>
<header style="text-align:center; width: 960px; text-align:center; margin-left:auto; margin-right:auto; margin-bottom:5px; margin-top:7px; padding:0;">Contact US</header>
<body >
<div id="wrapper">

<h1 class="nav">
    <a href="index.aspx">Home</a>
    <a href="aboutUs.aspx">About</a>
    <a href="contact.aspx">Contact</a>
    <a href="product.aspx">Products</a>
    <a href="Cart.aspx">Cart</a>
</h1>


<p  style="text-align:center">If you have any questions about anything please feel free to E-mail us using the email form below : </p>


    <form id="mailForm" runat="server">
    <div>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" align="center">
            
            
            <tr>
                <td align="center" valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="text">
                        <tr>
                            
                                
                            <td align="center" valign="top">
                               
                                    <tr>
                                        <td width="5" rowspan="4" align="center">&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    
                                            <table border="0" cellpadding="0" cellspacing="0" class="text">
                                                <tr>
                                                    <td width="68" align="center">
                                                        <asp:ImageButton ID="submitImage" runat="server" ImageUrl="b1.gif" align="center" />
                                                    </td> 
                                                    <td width="85" align="center">
                                                        <img src="b2.gif" alt="num2" width="85" height="27"></td>
                                                    <td width="56" align="center">
                                                        <img src="b3.gif" alt="num3" width="56" height="27"></td>
                                                    <td align="left" align="center">
                                                        <img src="b4.gif" alt="num4" width="56" height="27"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top">
                                            <asp:Panel ID="emailForm" runat="server">
                                                <table width="500" border="0" cellpadding="2" cellspacing="0" class="text">
                                                    <tr>
                                                        <td width="64" align="right">
                                                            <asp:RequiredFieldValidator ID="nameValidator" runat="server" ErrorMessage="**" ControlToValidate="senderName">**</asp:RequiredFieldValidator>From:
                                                        </td>
                                                        <td width="294">
                                                            <asp:TextBox ID="senderName" runat="server" Width="255px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="64" align="right">
                                                            <asp:RequiredFieldValidator ID="fromValidator" runat="server" ErrorMessage="RequiredFieldValidator"
                                                                ControlToValidate="senderEmail">**</asp:RequiredFieldValidator>E-mail:</td>
                                                        <td width="294">
                                                            <asp:TextBox ID="senderEmail" runat="server" Width="255px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:RequiredFieldValidator ID="toValidator" runat="server" ErrorMessage="RequiredFieldValidator"
                                                                ControlToValidate="to">**</asp:RequiredFieldValidator>To:</td>
                                                        <td>
                                                            <asp:TextBox ID="to" runat="server" Width="255px" Height="30px" TextMode="MultiLine" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">Cc:</td>
                                                        <td>
                                                            <asp:TextBox ID="cc" runat="server" Width="255px" Height="30px" TextMode="MultiLine" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">Bcc:<br>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="bcc" runat="server" Width="255px" Height="30px" TextMode="MultiLine" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:RequiredFieldValidator ID="subjectValidator" runat="server" ErrorMessage="RequiredFieldValidator"
                                                                ControlToValidate="subject">**</asp:RequiredFieldValidator>Subject:</td>
                                                        <td>
                                                            <asp:TextBox ID="subject" runat="server" Width="255px" />
                                                        </td>
                                                    </tr>
                                                    <td align="right" valign="top">
                                                        <asp:RequiredFieldValidator ID="messageValidator" runat="server" ErrorMessage="RequiredFieldValidator"
                                                            ControlToValidate="message">**</asp:RequiredFieldValidator>Message:</td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="message" runat="server" Width="255px" TextMode="MultiLine" Height="80px" />
                                                    </td>
                                                </table>
                                            </asp:Panel>
                                            <asp:Literal ID="sentEmail" runat="server" Visible="False">
                                            </asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
              
        
        <div>
        <p  style="text-align:center">
        Copyright 2014 AdventureWorksBikeShop
        </p>
        </div>
    
    </div>
    </form>
 </div>
</body>
</html>
