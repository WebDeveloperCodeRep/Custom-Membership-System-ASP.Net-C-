<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <div>
            <div class="container-box">

                <div class="inside-box">

                    <img src="Images/avatar.png" class="avatar" alt="login logo" />

                    <h2>Login Here</h2>
                  
                    <h3><asp:Label ID="loginError" runat="server" Text=""></asp:Label></h3>
                   
                    <p>Your email
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation-error" ControlToValidate="useremail" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </p>
                    <asp:TextBox ID="useremail" runat="server" Placeholder="Enter your email" title="email"></asp:TextBox>

                    <p>Password
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="validation-error" ControlToValidate="password" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </p>
                    <asp:TextBox ID="password" runat="server" Placeholder="Enter password" TextMode="Password" title="password"></asp:TextBox>

                    <asp:Button ID="Login" runat="server" Text="Login" OnClick="Login_Click" />

                    <div class="page-links">
                        <a href="ForgotPassword.aspx">Lost your password?</a>
                        <a href="Register.aspx">Don't have an account? Register Here</a>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
