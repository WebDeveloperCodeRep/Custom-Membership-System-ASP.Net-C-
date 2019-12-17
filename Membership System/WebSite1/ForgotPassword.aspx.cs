using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Send_Click(object sender, EventArgs e)
    {
        
        con.Open();
        SqlCommand com = new SqlCommand("Select Count(*) from User_Tbl where User_Email='" + useremail.Text + "'", con);
        int exist = Convert.ToInt32(com.ExecuteScalar().ToString());

        if (exist == 1)
        {
            SqlCommand com1 = new SqlCommand("Select User_Id from User_Tbl where User_Email='" + useremail.Text + "'", con);
            int iduser = Convert.ToInt32(com1.ExecuteScalar().ToString());



            SqlCommand com2 = new SqlCommand("Select User_Name from User_Tbl where User_Email='" + useremail.Text + "'", con);
            string UserName = com2.ExecuteScalar().ToString();


            con.Close();

            Guid UniqueId = Guid.NewGuid();


            con.Open();
            string sql = "INSERT INTO ResetLink (Id, User_Id, ResetDate ) " +
                                             "VALUES(@Id, @User_Id, @date)";
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@Id", UniqueId);
                cmd.Parameters.AddWithValue("@User_Id", iduser);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            con.Close();

            try
            {
                MailMessage mailMessage = new MailMessage("yourEmail@gmail.com", useremail.Text);



                StringBuilder sbEmailBody = new StringBuilder();

                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("Dear " + UserName + ",<br/><br/>");
                sbEmailBody.Append("Please click on the following link to reset your password");
                sbEmailBody.Append("<br/>");
                sbEmailBody.Append("<a href='http://localhost:49966/ResetPassword.aspx?uid=" + UniqueId + "'>");
                sbEmailBody.Append("Reset Password </a>");
                sbEmailBody.Append("<br/><br/>");
                sbEmailBody.Append("<br/><br/><br/>");
                sbEmailBody.Append("Sincerely, <br/>");
                sbEmailBody.Append("<b>Web Developer Code</b>");


                // convert the html tag
                mailMessage.IsBodyHtml = true;

                mailMessage.Body = sbEmailBody.ToString();
                mailMessage.Subject = "Reset Password";


                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("yourEmail@gmail.com", "yourPassword");
                    smtp.EnableSsl = true;
                    smtp.Send(mailMessage);
                }


                loginError.Text = "One email with your reset password link was sent to your email address";
                loginError.ForeColor = Color.Green;
                useremail.Text = "";
            }
            catch (Exception)
            {
                loginError.Text = "Error, please try again";
            }
        }

        else
        {
            loginError.Text = "This email adress is not on our records";
            loginError.ForeColor = Color.Red;
        }
    }
}