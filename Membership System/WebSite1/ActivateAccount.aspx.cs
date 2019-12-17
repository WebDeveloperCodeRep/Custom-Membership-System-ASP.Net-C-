using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActivateAccount : System.Web.UI.Page
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
            SqlCommand com = new SqlCommand("Select Count(*) from User_Tbl where ValidLink='" + id + "'", con);
            int exist = Convert.ToInt32(com.ExecuteScalar().ToString());
            con.Close();

            if (exist == 1)
            {

                con.Open();
                string sqlupdate = "Update User_Tbl Set IsValid = @valid Where ValidLink =@validGuid";
                using (SqlCommand cmd4 = new SqlCommand(sqlupdate, con))
                {
                    cmd4.Parameters.AddWithValue("@validGuid", id);
                    cmd4.Parameters.AddWithValue("@valid", "Yes");
                    cmd4.CommandType = CommandType.Text;
                    cmd4.ExecuteNonQuery();
                }
                con.Close();
                Session["active"] = "Yes";
                Response.Redirect("Login.aspx");

            }
            else
            {
                Session["active"] = "no";
                Response.Redirect("Login.aspx");
            }
        }
        else
        {
            Session["active"] = "no";
            Response.Redirect("Login.aspx");
        }
    }
}