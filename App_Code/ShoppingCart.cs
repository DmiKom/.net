using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;


public class ShoppingCart
{
    private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString);
    private ArrayList ProductID = new ArrayList();
    private ArrayList Name = new ArrayList();
    private ArrayList ProductNumber = new ArrayList();
    private ArrayList Description = new ArrayList();
    private ArrayList ListPrice = new ArrayList();
    private ArrayList QuantityPerUnit = new ArrayList();
    public bool addItem(string prodID)
    {
        foreach (string item in ProductID)
        {
            if (item == prodID)
                return false;

        }
        ProductID.Add(prodID);
        QuantityPerUnit.Add(1);
        return true;
    }
    public string showCart()
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString);
        string retValue = "<table width = '100%' cellspacing='2' cellpadding='3' rules='all' border='1' id='productGrid' style='background-color:#DEBA84; border-color:#DEBA84; border-width:1px; border-style:None; font-size:Smaller;'>"; retValue += "<tr style='color:white; background-color:#A55129; font-weight:bold;'><th align='center'> Remove</th> <th align='center'> Product</th><th align='center'> Quanity</th><th align='center'> Price Each</th></tr>";
        double total = 0;
        sqlConnection.Open();
        for (int i = 0; i < ProductID.Count; ++i)
        {
            string sqlString = "SELECT "
            + "  product.ProductID "
            + ", product.Name "
            + ", product.ProductNumber "
            + ", descrip.Description "
            + ", product.ListPrice "
            + " FROM Production.Product product "
            + " left outer join Production.ProductProductPhoto prodphoto "
            + " on product.ProductID = prodphoto.ProductID "
            + " left outer join Production.ProductPhoto photo "
            + " on prodphoto.ProductPhotoID = photo.ProductPhotoID "
            + " left outer join Production.ProductModel model "
            + " on product.Name = model.Name "
            + " left outer join Production.ProductModelProductDescriptionCulture pdc "
            + " on model.ProductModelID = pdc.ProductModelID "
            + " and pdc.CultureID = 'en' "
            + " left outer join Production.ProductDescription descrip "
            + " on pdc.ProductDescriptionID = descrip.ProductDescriptionID "
                + " WHERE Product.ProductID ='"
                + ProductID[i] + "'";
            SqlCommand prodCommand = new SqlCommand(sqlString, sqlConnection);
            SqlDataReader prodRecords = prodCommand.ExecuteReader();
            if (prodRecords.Read())
            {
                retValue += "<tr style='color:#8C4510; background-color:FFF7E7;'>"
                    + "<td align='center'> <a href='product.aspx?operation=removeItem&productID="
                    + ProductID[i] + "'>Remove</a></td>"
                    + "<td>" + prodRecords["Name"]
                    + "</td>"
                    + "<td align='center'>" + QuantityPerUnit[i]
                    + "<br /><a href='Cart.aspx?operation=addOne&ProductID="
                    + ProductID[i] + "'>Add</a>&nbsp; <a href='product.aspx?operation=removeOne&ProductID="
                    + ProductID[i] + "'>Remove</a>" + "<td align='center'>"
                    + String.Format("{0:C}", prodRecords["ListPrice"])
                    + "</td></tr>";
                double Price = Convert.ToDouble(prodRecords["ListPrice"]);
                int quanity = Convert.ToInt16(QuantityPerUnit[i]);
                total += Price * quanity;
            }
            prodRecords.Close();
            sqlConnection.Close();
        }
        retValue += "<td align='center'> <a href='Cart.aspx?operation=emptyCart'>Empty Cart</a></td>";
        retValue += "<td align='center' colspan='2'> <strong> Your shopping cart contains "
            + QuantityPerUnit.Count
            + " product(s).</strong></td>"; retValue += "<td align='center'><strong>Total: "
            + String.Format("{0:C}", total)
            + "</strong></td></tr>"; retValue += "<asp:Button runat='server' Text='Button' /></table>";
        return retValue;
    }
    public void removeItem(string prodID)
    {
        for (int i = 0; i < ProductID.Count; --i)
        {
            if (ProductID[i].ToString() == prodID)
            {
                ProductID.RemoveAt(i);
                QuantityPerUnit.RemoveAt(i);
                break;
            }
        }
    }
    public void emptyCart(string prodID)
    {
        ProductID.Clear();
        QuantityPerUnit.Clear();
    }
    public void addOne(string prodID)
    {
        for (int i = 0; i < ProductID.Count; ++i)
        {
            if (ProductID[i].ToString() == prodID)
            {
                QuantityPerUnit[i] = Convert.ToInt16(QuantityPerUnit[i]) + 1;
                break;
            }
        }
    }
    public void removeOne(string prodID)
    {
        for (int i = 0; i < ProductID.Count; --i)
        {
            if (ProductID[i].ToString() == prodID)
            {
                QuantityPerUnit[i] = Convert.ToInt16(QuantityPerUnit[i]) - 1;
                if (Convert.ToInt16(QuantityPerUnit[i]) == 0)
                {
                    ProductID.RemoveAt(i);
                    QuantityPerUnit.RemoveAt(i);
                }
                break;
            }
        }
    }
    public double getTotal()
    {
        double total = 0;

        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString);

        for (int i = 0; i < ProductID.Count; ++i)
        {
            string sqlString = "SELECT "
         + "  product.ProductID "
         + ", product.Name "
         + ", product.ProductNumber "
         + ", descrip.Description "
         + ", product.ListPrice "
         + " FROM Production.Product product "
         + " left outer join Production.ProductProductPhoto prodphoto "
         + " on product.ProductID = prodphoto.ProductID "
         + " left outer join Production.ProductPhoto photo "
         + " on prodphoto.ProductPhotoID = photo.ProductPhotoID "
         + " left outer join Production.ProductModel model "
         + " on product.Name = model.Name "
         + " left outer join Production.ProductModelProductDescriptionCulture pdc "
         + " on model.ProductModelID = pdc.ProductModelID "
         + " and pdc.CultureID = 'en' "
         + " left outer join Production.ProductDescription descrip "
         + " on pdc.ProductDescriptionID = descrip.ProductDescriptionID "
             + " WHERE Product.ProductID ='"
             + ProductID[i] + "'";
            SqlCommand prodCommand = new SqlCommand(sqlString, sqlConnection);
            sqlConnection.Open();
            SqlDataReader prodRecords = prodCommand.ExecuteReader();
            if (prodRecords.Read())
            {
                

                double price = Convert.ToDouble(prodRecords["ListPrice"]);
                int quantity = Convert.ToInt16(QuantityPerUnit[i]);
                total += price * quantity;
            }
            prodRecords.Close();
            sqlConnection.Close();
        }
        return total;
    }
    public string createOrderDetail()
    {
        int salesOrderID = 0;
        string salesOrderIdQuery = "select max(salesorderid) as salesOrderID from sales.SalesOrderHeader";
        sqlConnection.Open();
        SqlCommand newCommand = new SqlCommand(salesOrderIdQuery, sqlConnection);
        SqlDataReader reader = newCommand.ExecuteReader();

        if (reader.Read())
        {
            salesOrderID = (int)reader["salesOrderID"];
        }
        reader.Close();
        for (int i = 0; i < ProductID.Count; ++i)
        {
            string prodID = "";
            string prodQuantity = "";
            string prodUnitPrice = "";
            string specialOfferID = "";
            

            string sqlString = "SELECT "
            + "  product.ProductID "
            + ", product.Name "
            + ", product.ProductNumber "
            + ", descrip.Description "
            + ", product.ListPrice "
            + " FROM Production.Product product "
            + " left outer join Production.ProductProductPhoto prodphoto "
            + " on product.ProductID = prodphoto.ProductID "
            + " left outer join Production.ProductPhoto photo "
            + " on prodphoto.ProductPhotoID = photo.ProductPhotoID "
            + " left outer join Production.ProductModel model "
            + " on product.Name = model.Name "
            + " left outer join Production.ProductModelProductDescriptionCulture pdc "
            + " on model.ProductModelID = pdc.ProductModelID "
            + " and pdc.CultureID = 'en' "
            + " left outer join Production.ProductDescription descrip "
            + " on pdc.ProductDescriptionID = descrip.ProductDescriptionID "
                + " WHERE Product.ProductID ='"
                + ProductID[i] + "'";
            SqlCommand prodCommand = new SqlCommand(sqlString, sqlConnection);

            SqlDataReader prodRecords = prodCommand.ExecuteReader();
            if (prodRecords.Read())
            {
                prodID = ProductID[i].ToString();
                prodUnitPrice = prodRecords["ListPrice"].ToString();
                prodQuantity = QuantityPerUnit[i].ToString();
            }
            prodRecords.Close();
            sqlConnection.Close();



            string sqlString2 = "select SpecialOfferID from Sales.SpecialOfferProduct where ProductID = '" + prodID + "'";
            sqlConnection.Open();
            SqlCommand prodCommand2 = new SqlCommand(sqlString2, sqlConnection);

            SqlDataReader prodRecords2 = prodCommand2.ExecuteReader();
            if (prodRecords2.Read())
            {
                specialOfferID = prodRecords2["SpecialOfferID"].ToString();
            }
            prodRecords2.Close();
            sqlConnection.Close();

            sqlConnection.Open();

            String script =
"declare @temp as datetime " + 
"set @temp = getdate(); " + 
"execute sp_CreateOrderDetail " + 
"@SalesOrderID = " + salesOrderID +  
", @OrderQty = " + prodQuantity + 
", @ProductID = " + prodID +
", @SpecialOfferID = 1" + 
", @UnitPrice = " + prodUnitPrice + 
", @UnitPriceDiscount = 0.00"
;
            return script;
            SqlCommand sql = new SqlCommand(script, sqlConnection);

            
            sqlConnection.Close();
        }

        return "poooo";
    }

  }


