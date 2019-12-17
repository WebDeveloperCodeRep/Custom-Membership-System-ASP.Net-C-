using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ResetPassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    public static bool IsGuid1(string guidString)
    {
        bool isValid = false;
        if (!string.IsNullOrEmpty(guidString))
        {
            Regex isGuid =
                new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$"
                    , RegexOptions.Compiled);

            if (isGuid.IsMatch(guidString))
            {
                isValid = true;
            }
        }
        return isValid;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["uid"];

        if (IsGuid1(id))
        {   
            con.Open();
            SqlCommand com = new SqlCommand("Select Count(*) from ResetLink where Id='" + id + "'", con);
            int exist = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if (exist == 1)
            {

            }
            else
            {
                loginError.Text = "Password Reset link has expired or is invalid";
                loginError.ForeColor = Color.Red;
            }
        }
        else
        {
            loginError.Text = "Password Reset link has expired or is invalid";
            loginError.ForeColor = Color.Red;
        }
    }

    protected void Reset_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["uid"];

        if (IsGuid1(id))
        {

            con.Open();
            SqlCommand com = new SqlCommand("Select Count(*) from ResetLink where Id='" + id + "'", con);
            int exist = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if (exist == 1)
            {
                //if link is valid change password

                con.Open();
                SqlCommand com2 = new SqlCommand("Select User_Id from ResetLink where Id='" + id + "'", con);
                int User_Id = Convert.ToInt32(com2.ExecuteScalar().ToString());
                con.Close();

                //update pass
                con.Open();
                string sql = "Update User_Tbl Set Password=@Pass Where User_Id=" + User_Id;
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {

                    //encript pass

                    string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1");

                    cmd.Parameters.AddWithValue("@Pass", pass);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();

                // delete record from tbl resetpass 
                con.Open();
                string sql2 = "Delete from ResetLink where User_Id=" + User_Id;
                using (SqlCommand cmd4 = new SqlCommand(sql2, con))
                {

                    cmd4.CommandType = CommandType.Text;
                    cmd4.ExecuteNonQuery();
                }
                con.Close();

                loginError.Text = "Password Changed";
                loginError.ForeColor = Color.Green;
                password.Text = "";
                password2.Text = "";

            }
            else
            {
                loginError.Text = "Password Reset link has expired or is invalid";
                loginError.ForeColor = Color.Red;
            }
        }
        else
        {
            loginError.Text = "Password Reset link has expired or is invalid";
            loginError.ForeColor = Color.Red;
        }
    }
}