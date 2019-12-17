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

public partial class Account : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User"] == null)
        {
            Response.Redirect("Login.aspx");
        }

        else
        {
            email.Text = Session["User"].ToString();
        }
    }

    protected void Btn_logout_Click(object sender, EventArgs e)
    {
        Session["User"] = null;
        Response.Redirect("Login.aspx");
    }

    protected void Update_pass_Click(object sender, EventArgs e)
    {
        if (Session["User"] != null)
        {
            
            string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1");


            string sqlselect = "Select Password from User_Tbl  Where User_Email=@email";
            using (SqlCommand cmd = new SqlCommand(sqlselect, con))
            {
                con.Open();
                //encript pass

                string oldpass_input = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldpass.Text, "SHA1");

                cmd.Parameters.AddWithValue("@email", Session["User"].ToString().Trim());
                cmd.CommandType = CommandType.Text;
                string oldpass_saved = (string)cmd.ExecuteScalar();
                con.Close();

                if (oldpass_input == oldpass_saved && oldpass_saved != pass)
                {

                    con.Open();
                    string sql = "Update User_Tbl Set Password=@Pass Where User_Email=@email";
                    using (SqlCommand cmd_update = new SqlCommand(sql, con))
                    {

                        //encript pass

                        cmd_update.Parameters.AddWithValue("@email", Session["User"].ToString().Trim());
                        cmd_update.Parameters.AddWithValue("@Pass", pass);
                        cmd_update.CommandType = CommandType.Text;
                        cmd_update.ExecuteNonQuery();
                    }
                    con.Close();
                    confirm.Text = "Password Changed";
                    oldpass.Text = "";
                    password.Text = "";
                    password2.Text = "";
                }
                else if (oldpass_saved == pass)
                {
                    confirm.Text = "You entered the old password";
                }
                else
                {
                    confirm.Text = "You must confirm your current password";
                    confirm.ForeColor = Color.Red;
                }

            }

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}