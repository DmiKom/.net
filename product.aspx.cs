using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class product : System.Web.UI.Page
{
    
    protected void ProductGrid_onButtonClick(object sender, EventArgs e)
    {
        ShoppingCart curCart;
        if (Session["savedCart"] == null)
        {
            curCart = new ShoppingCart();
        }
        else
        {
            curCart = (ShoppingCart)Session["savedCart"];
        }
        bool addResult = curCart.addItem(productGridView.SelectedValue.ToString());
        
            Session["savedCart"] = curCart;
            Response.Redirect("Cart.aspx");
    }
    protected void productGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShoppingCart curCart;
        if (Session["savedCart"] == null)
        {
            curCart = new ShoppingCart();
        }
        else
        {
            curCart = (ShoppingCart)Session["savedCart"];
        }
        bool addResult = curCart.addItem(productGridView.SelectedValue.ToString());

        Session["savedCart"] = curCart;
        Response.Redirect("Cart.aspx");

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["BusinessEntityID"] == null)
        {
            Response.Redirect("Log.aspx");
        }
        else
        {
           on.Text=("You are logged in");
            lo.Visible = false;
            on.Visible =true;
            
        }
    }

}

