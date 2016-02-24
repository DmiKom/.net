<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="product.aspx.cs" Inherits="product" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="new.css" rel="stylesheet" type="text/css" /> 
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
<asp:literal id ="lo" visible="true" runat="server" ><a href="Log.aspx" >Log In</a></asp:literal>
<asp:literal id ="on" visible="false" Text="" runat="server"></asp:literal>

    <form id="form1" runat="server">


    <div> 
        <asp:SqlDataSource ID="productsDataSource"  Runat="server" 
             
             ConnectionString="<%$ ConnectionStrings:AdventureWorks %>" 
             SelectCommand="SELECT [ProductID]
	                        , ProductName = name
	                        , QuantityPerUnit = 1
	                        , [UnitPrice]=ListPrice
	                        , [UnitsInStock] =1
               FROM Production.[Product]
               Where ListPrice &gt; 0"
         DataSourceMode="DataSet" >
        </asp:SqlDataSource>
        <asp:GridView ID="productGridView" Runat="server" 
          DataSourceID="productsDataSource"
            DataKeyNames="ProductID" AutoGenerateColumns="False" 
            AllowSorting="True" AllowPaging="True"       
             BorderWidth="0px" BackColor="White" 
             CellPadding="3" CellSpacing="2" BorderStyle="None" 
             BorderColor="Black" PageSize="30" 
            onselectedindexchanged="productGridView_SelectedIndexChanged">
            <FooterStyle ForeColor="#8C4510" 
              BackColor="#F7DFB5"></FooterStyle>
            <PagerStyle ForeColor="#000000" 
              HorizontalAlign="Center"></PagerStyle>
            <HeaderStyle ForeColor="White" Font-Bold="True" 
              BackColor="#097054"></HeaderStyle>
            <Columns>
                 <asp:BoundField ReadOnly="True" HeaderText="ID" 
                  InsertVisible="False" DataField="ProductID"
                    SortExpression="ProductID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:HyperLinkField HeaderText="ProductIDLink" DataTextField="ProductName" 
                        DataTextFormatString="{0}" SortExpression="ProductID" 
                        DataNavigateUrlFields="ProductID" 
                        DataNavigateUrlFormatString="./details.aspx?ProductID={0}" />
               <asp:BoundField HeaderText="Qty/Unit" 
                 DataField="QuantityPerUnit" 
                 SortExpression="QuantityPerUnit"></asp:BoundField>
                <asp:BoundField HeaderText="Price/Unit" 
                DataField="UnitPrice" SortExpression="UnitPrice" 
                DataFormatString="{0:c}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="Units In Stock" 
                  DataField="UnitsInStock" 
                  SortExpression="UnitsInStock" 
                   DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                    
                </asp:BoundField>
           
          

                 <asp:CommandField ButtonType="Button" HeaderText="Buy Now" ShowHeader="True" 
                     ShowSelectButton="True" SelectText="Add" ShowCancelButton="True"  />
          

            </Columns>
            <SelectedRowStyle ForeColor="White" Font-Bold="True" 
             BackColor="#ffffff"></SelectedRowStyle>
            <RowStyle ForeColor="#000000" 
               BackColor="#ffffff"></RowStyle>
        </asp:GridView>

    </div>
    </form>
    </div>
</body>
</html>
