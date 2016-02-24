using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class details : System.Web.UI.Page
{
    //Dmitriy komarov & joseph Brown
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString);
        try
        {
            sqlConnection.Open();
            string command = "SELECT Product.Name, Product.ProductNumber, descrip.Description, photo.LargePhotoFileName, Product.ListPrice, product.productID "
                + "FROM Production.Product product "
                + "left outer join Production.ProductProductPhoto prodphoto "
                + "on product.ProductID = prodphoto.ProductID "
                + "left outer join Production.ProductPhoto photo "
                + "on prodphoto.ProductPhotoID = photo.ProductPhotoID "
                + "left outer join Production.ProductModel model "
                + "on product.Name = model.Name "
                + "left outer join Production.ProductModelProductDescriptionCulture pdc "
                + "on model.ProductModelID = pdc.ProductModelID "
                + "and pdc.CultureID = 'en' "
                + "left outer join Production.ProductDescription descrip "
                + "on pdc.ProductDescriptionID = descrip.ProductDescriptionID "
                + "WHERE product.ProductID = "
                + Request.QueryString["productID"];
            SqlCommand com = new SqlCommand(command, sqlConnection);
            SqlDataReader prodInfo = com.ExecuteReader();
            if (prodInfo.Read())
            {
                Name.Text = prodInfo["Name"].ToString();
                Number.Text = prodInfo["ProductNumber"].ToString();
                des.Text = prodInfo["Description"].ToString();
                photo.ImageUrl = prodInfo["LargePhotoFileName"].ToString();
                photo.AlternateText = prodInfo["Name"].ToString();
                price.Text = "$" + prodInfo["ListPrice"].ToString();
                ProID.Text = prodInfo["productID"].ToString();

                if (photo.ImageUrl == "no_image_available_large.gif")
                {
                    photo.ImageUrl = "lowRiderFormat.jpg";
                }
                else
                {
                    photo.ImageUrl = "lowRiderFormat.jpg";
                }
            }
            prodInfo.Close();
        }
        catch (SqlException exception)
        {
            Response.Write("<p>Error code in query 1 " + exception.Number + ": " + exception.Message +" "+ exception.LineNumber + "</p>");
        }
        finally
        {
            sqlConnection.Close();
        }
    }
    protected void product_SelectedIndexChanged(object sender, EventArgs e)
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
        bool addResult = curCart.addItem(ProID.ToString());

        Session["savedCart"] = curCart;
        Response.Redirect("Cart.aspx");
    }
  
}
