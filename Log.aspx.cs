using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Log : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString);
            try
            {
                sqlConnection.Open();
                String som = "select pers.BusinessEntityID, pass.PasswordSalt from Person.Password pass "
                        + " join Person.Person pers "
                        + " on pass.BusinessEntityID = pers.BusinessEntityID"
                        + " where pers.BusinessEntityID =" + Convert.ToInt32(LoginID.Text)
                        + " AND pass.PasswordSalt = '" + Convert.ToString(password.Text)
                        + "='";
                //Response.Write (som);
                SqlCommand sqlCommand = new SqlCommand(som, sqlConnection);

                //businessEntityID =1 and password is bE3XiWw
                SqlDataReader curUser = sqlCommand.ExecuteReader();
                if (curUser.Read())
                {
                    HttpCookie LoginIDObject = new HttpCookie("BusinessEntityID");
                    Response.Write(LoginIDObject);
                    LoginIDObject.Value = curUser["BusinessEntityID"].ToString();
                    Response.Cookies.Add(LoginIDObject);
                    Response.Redirect("product.aspx");
                }
                else
                {
                    badLogin.Text = "<p style='color:red' ><strong>Incorrect ID or password.<strong></p>";
                }
            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code"
                    + exception.Number + ": "
                    + exception.Message + "</p>");
            }
            sqlConnection.Close();
        }
    }
}

