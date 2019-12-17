<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="container-box">

                <div class="inside-box">

                    <img src="Images/avatar.png" class="avatar" alt="login logo" />

                    <h2>Register Here</h2>
                    <h3><asp:Label ID="confirm" runat="server" Text=""></asp:Label></h3>
                   
                    <p>Your email
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="validation-error" ControlToValidate="useremail" ErrorMessage="*"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validation-error" ControlToValidate="useremail" ErrorMessage="*"></asp:RegularExpressionValidator>
                    </p>
                    <asp:TextBox ID="useremail" runat="server" Placeholder="Enter your email" title="email"></asp:TextBox>

                    <p>Your name
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="validation-error" ControlToValidate="username" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </p>
                    <asp:TextBox ID="username" runat="server" Placeholder="Enter your name" title="email"></asp:TextBox>

                    <p>Password
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="validation-error" ControlToValidate="password" ErrorMessage="*"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="password" CssClass="validation-error" Display="Dynamic" ErrorMessage="Password must contain: Minimum 8 characters at least 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"/>
                    </p>
                    <asp:TextBox ID="password" runat="server" Placeholder="Enter password" TextMode="Password" title="password"></asp:TextBox>

                    <p>Confirm Password
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="validation-error" ControlToValidate="password2" ErrorMessage="*"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="password2" Display="Dynamic" CssClass="validation-error" ErrorMessage="Password doesn't match" ControlToCompare="password"></asp:CompareValidator>
                    </p>
                    <asp:TextBox ID="password2" runat="server" Placeholder="Confirm password" TextMode="Password" title="password"></asp:TextBox>

                    <div class="terms">
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                        <asp:Label ID="lbl_checkbox1" runat="server" AssociatedControlID="CheckBox1">I agree to the <a href="#">Terms and Conditions.</a></asp:Label>
                        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="*" ClientValidationFunction="ValidateCheckBox" Display="Dynamic" CssClass="validation-error"></asp:CustomValidator>
                    </div>

                    <asp:Button ID="Register_btn" runat="server" Text="Sign Up" OnClick="Register_btn_Click" />

                    <div class="page-links">
                        <a href="Login.aspx">Already have an account? Login Here</a>
                    </div>
                </div>

            </div>

        </div>
    </form>

    <!-- check box term and conditions required custom validation -->
    <script>
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=CheckBox1.ClientID %>").checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</body>
</html>
