using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        confirm.Text = "";
        useremail.Text = "";
        username.Text = "";
        password.Text = "";
        password2.Text = "";
    }

    protected void Register_btn_Click(object sender, EventArgs e)
    {

        string checkuser = "select count(*) from User_Tbl where User_Email= @email";

        SqlCommand com = new SqlCommand(checkuser, con);
        com.Parameters.AddWithValue("@email", useremail.Text.Trim());

        con.Open();
        int check = Convert.ToInt32(com.ExecuteScalar().ToString());
        con.Close();


        if (check == 1)
        {
            confirm.Text = "Email already registered.";
        }
        else
        {
            Guid Uid = Guid.NewGuid();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                connection.Open();
                string sql = "INSERT INTO User_Tbl (User_Email, User_Name, Password, ValidLink ) " +
                                                  "VALUES(@User_Email, @User_Name, @Password, @valid )";
                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {

                    string pass = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password.Text, "SHA1");

                    cmd.Parameters.AddWithValue("@User_Email", useremail.Text.Trim());
                    cmd.Parameters.AddWithValue("@User_Name", username.Text);
                    cmd.Parameters.AddWithValue("@Password", pass);
                    cmd.Parameters.AddWithValue("@valid", Uid);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            

            try
            {

                MailMessage mailMessage = new MailMessage("yourEmail@gmail.com", useremail.Text);



                StringBuilder sbEmailBody = new StringBuilder();

                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("Dear " + username.Text + ",<br/><br/>");
                sbEmailBody.Append("Please click on the following link to activate your account");
                sbEmailBody.Append("<br/>");
                sbEmailBody.Append("<a href='http://localhost:49966/ActivateAccount.aspx?uid=" + Uid + "'>");
                sbEmailBody.Append("Verify email </a>");
                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("<br/><br/><br/>");
                sbEmailBody.Append("Sincerely, <br/>");
                sbEmailBody.Append("<b>Web Developer Code</b>");


                // convert the html tag
                mailMessage.IsBodyHtml = true;

                mailMessage.Body = sbEmailBody.ToString();
                mailMessage.Subject = "Account verification";

                // SmtpClient client = new SmtpClient()

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("yourEmail@gmail.com", "yourPassword");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }
                //client.Send(mailMessage);


                useremail.Text = "";
                username.Text = "";
                password.Text = "";
                password2.Text = "";
                confirm.Text = "Check your email for activation link";
            }
            catch(Exception)
            {
                confirm.Text = "Error, please try again";
            }

        }
    }
}