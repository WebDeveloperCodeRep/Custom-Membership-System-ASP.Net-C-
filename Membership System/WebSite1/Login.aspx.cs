using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        loginError.Text = "";

        if (Session["User"] != null)
        {
            Response.Redirect("Acount.aspx");
        }

        if (Session["active"] != null)
        {
            if (Session["active"].ToString() == "Yes")
            {
                loginError.Text = "Your account has been activated";
                loginError.ForeColor = Color.White;
            }
            else if (Session["active"].ToString() == "no")
            {
                loginError.Text = "You must active your account";
                loginError.ForeColor = Color.Red;
            }
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        SqlCommand com = new SqlCommand();
        SqlCommand com2 = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataAdapter sda = new SqlDataAdapter();
        DataSet ds = new DataSet();

        if (Session["User"] != null)
        {
            loginError.Text = "You are already login";
            loginError.ForeColor = Color.Red;
        }

        else
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            con.Open();


            SqlCommand comValid = new SqlCommand();
            comValid.CommandText = "Select IsValid from User_Tbl where User_Email = @email";
            comValid.Parameters.AddWithValue("@email", useremail.Text);
            comValid.Connection = con;
            object isValid = (object)comValid.ExecuteScalar();

            con.Close();

            if (isValid.ToString() == "Yes")
            {
                con.Open();

                com.CommandText = "select * from User_Tbl where User_Email= @email and Password= @password";

                com.Parameters.AddWithValue("@email", useremail.Text);


                string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1");



                com.Parameters.AddWithValue("@password", pass);

                com.Connection = con;
                sda.SelectCommand = com;
                sda.Fill(ds, "UserTable");
                sda.Dispose(); // force close the sql data adapter to avoid connection leakage
                con.Close();


                if (ds.Tables[0].Rows.Count > 0)
                {
                    con.Open();
                    Session["User"] = useremail.Text;
                    Session["active"] = null;
                    Response.Redirect("Account.aspx");
                }
                else
                {
                    loginError.Text = "Wrong email or password";
                    loginError.ForeColor = Color.Red;
                }
            }
            else
            {
                loginError.Text = "You must verify your account";
                loginError.ForeColor = Color.Red;
            }
        }
    }
}