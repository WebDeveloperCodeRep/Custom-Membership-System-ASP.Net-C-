<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="container-box">
                <div class="inside-box forgot-pass-box">

                    <h2>Forgot Password?</h2>

                    <p class="info">Enter the email address you used when register with us and you will receive an email containing a link to reset your password</p>
                  
                    <h3><asp:Label ID="loginError" runat="server" Text=""></asp:Label></h3>
                    
                    <p>Your email
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation-error" ControlToValidate="useremail" ErrorMessage="*"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validation-error" ControlToValidate="useremail" ErrorMessage="*"></asp:RegularExpressionValidator>
                    </p>
                    <asp:TextBox ID="useremail" runat="server" Placeholder="Enter your email" title="email"></asp:TextBox>

                    <asp:Button ID="Send" runat="server" Text="Send" OnClick="Send_Click" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
