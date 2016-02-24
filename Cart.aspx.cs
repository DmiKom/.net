using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Cart: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString);

        if (Request.Cookies["BusinessEntityID"] == null)
        {
            Response.Redirect("Log.aspx");
        }
        else
        {
            on.Text = ("You are logged in");
            on.Visible = true;

        }
        //if (Request.Cookies["fluerID"] == null)

        //    Response.Redirect("Login.aspx");

        //else
        //{
        //    SqlConnection dbConnection = new SqlConnection("Data source=.\\SQLEXPRESS; AttachDbFilename= C:\\Users\\komdmi\\Desktop\\Dima\\Business Applications\\Chapter.09\\Chapter\\SkywardAviation\\App_Data\\SkywardAviation.mdf; Integrated Security=true user Instance=true");
        //    dbConnection.Open();
        //    try
        //    {
        //        SqlCommand sqlCommand = new SqlCommand("SELECT flyerID, first, last FROM FrequentFlyers WHERE flyerID = "
        //            + Request.Cookies["flyerID"].Value, dbConnection);
        //        SqlDataReader userInfo = sqlCommand.ExecuteReader();
        //        if (userInfo.Read())
        //        {
        //            flyerIDValue.Text = userInfo["flyerID"].ToString();
        //            firstName.Text = userInfo["first"].ToString();
        //            lastName.Text = userInfo["last"].ToString();
        //        }
        //        userInfo.Close();
        //    }
        //    catch (SqlException exception)
        //    {
        //        Response.Write("<p>Error code "
        //            + exception.Number + ": "
        //            + exception.Message + "</p>");
        //    }
        //    dbConnection.Close();
        //}
        ShoppingCart curCart;

        if (Session["savedCart"] != null)
        {
            curCart = (ShoppingCart)Session["savedCart"];
            if (Request.QueryString["operation"] == "removeItem")
            {
                curCart.removeItem(Request.QueryString["ProductID"]);
                Response.Redirect("Cart.aspx");
            }
            else if (Request.QueryString["operation"] == "emptyCart")
            {
                curCart.emptyCart(Request.QueryString["productID"]);
                Response.Redirect("Cart.aspx");
            }
            else if (Request.QueryString["operation"] == "addOne")
            {
                curCart.addOne(Request.QueryString["ProductID"]);
                Response.Redirect("Cart.aspx");
            }
            else if (Request.QueryString["operation"] == "removeOne")
            {
                curCart.removeOne(Request.QueryString["ProductID"]);
                Response.Redirect("Cart.aspx");
            }
            else
            {
                string retString = curCart.showCart();
                CartBody.Text = retString;
            }
        }
        else
        {
            CartBody.Text = "<p>Your shopping cart is empty.</p>";
        }
    }


    protected void Buy_onClick(object sender, EventArgs e)
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString);
        sqlConnection.Open();
        ShoppingCart curCart;
   

        if (Session["savedCart"] != null)
        {
            curCart = (ShoppingCart)Session["savedCart"];
            if (Request.QueryString["operation"] == "removeItem")
            {
                curCart.removeItem(Request.QueryString["ProductID"]);
                Response.Redirect("Cart.aspx");
            }
            else if (Request.QueryString["operation"] == "emptyCart")
            {
                curCart.emptyCart(Request.QueryString["productID"]);
                Response.Redirect("Cart.aspx");
            }
            else if (Request.QueryString["operation"] == "addOne")
            {
                curCart.addOne(Request.QueryString["ProductID"]);
                Response.Redirect("Cart.aspx");
            }
            else if (Request.QueryString["operation"] == "removeOne")
            {
                curCart.removeOne(Request.QueryString["ProductID"]);
                Response.Redirect("Cart.aspx");
            }
            else
            {
                string retString = curCart.showCart();
                CartBody.Text = retString;
            }
            double total = curCart.getTotal();
            double tax = total * 0.07;
            double freight = 5.00;


            String script =
                "declare @Date as datetime " +
                "set @Date = getdate(); " +
                "declare @Date1 as datetime " +
                "set @Date1 = getdate()+12; " +
                "execute sp_CreateOrderHeader " +

                " @OrderDate = @Date" +
                ", @DueDate = @Date1" +
                ", @CustomerID = 1 " +
                ", @BillToAddressID = 1" +
                ", @ShipToAddressID = 1" +
                ", @ShipMethodID = 5" +
                ", @SubTotal = " + total +
                ", @TaxAmt = " + tax +
                ", @Freight = " + freight;
           
            SqlCommand sql = new SqlCommand(script, sqlConnection);

            sql.ExecuteNonQuery();
            //tmp1.Text = ("ppppooooooooo");
            //tmp1.Visible = true;
            Response.Write(curCart.createOrderDetail());
            sqlConnection.Close();
        }

        else
        {
            CartBody.Text = "<p>Your shopping cart is empty.</p>";

        }
        }

}

