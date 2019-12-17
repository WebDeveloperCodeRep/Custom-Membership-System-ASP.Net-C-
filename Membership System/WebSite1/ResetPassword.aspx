<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reset Password</title>
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-box">
                <div class="inside-box forgot-pass-box">

                    <h2>Reset Password</h2>
                    <h3><asp:Label ID="loginError" runat="server" Text=""></asp:Label></h3>
                   
                    <p> Password
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="validation-error" ControlToValidate="password" ErrorMessage="*"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="password" CssClass="validation-error" Display="Dynamic" ErrorMessage="Password must contain: Minimum 8 characters at least 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"/>
                        </p>
                    <asp:TextBox ID="password" runat="server" Placeholder="Enter password" TextMode="Password" title="password"></asp:TextBox>

                    <p>Confirm Password
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="validation-error" ControlToValidate="password2" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="password2" Display="Dynamic" CssClass="register-validation" ErrorMessage="Password doesn't match" ControlToCompare="password"></asp:CompareValidator>
                    </p>
                    <asp:TextBox ID="password2" runat="server" Placeholder="Confirm password" TextMode="Password" title="password"></asp:TextBox>

                    <asp:Button ID="Reset" runat="server" Text="Reset Password" OnClick="Reset_Click" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>
