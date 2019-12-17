<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account</title>
    <link href="https://fonts.googleapis.com/css?family=Montserrat&display=swap" rel="stylesheet">
    <link href="StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-account">
                
                <div class="left-child">
                    <img src="Images/avatar.png" alt="login logo" class="account-avatar" />

                    <p><asp:Label ID="email" runat="server" Text="Label"></asp:Label></p>

                    <asp:Button ID="Btn_logout" runat="server" Text="Log Out" OnClick="Btn_logout_Click" />
                </div>

                <div class="right-child">
                    <h2>Change Password</h2>
                   
                    <asp:Label ID="confirm" runat="server" Text=""></asp:Label>
                    
                    <p>Old Password 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="oldpass" ValidationGroup="pass"></asp:RequiredFieldValidator>
                    </p>
                    <asp:TextBox ID="oldpass" runat="server" TextMode="Password"></asp:TextBox>
                   
                    <p>New Password
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="password" ValidationGroup="pass"></asp:RequiredFieldValidator>
                      <asp:RegularExpressionValidator ID="rev1" runat="server" ControlToValidate="password" CssClass="validation-error" Display="Dynamic" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"/>
                    </p>
                    <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
                    
                    <p>Confirm Password
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="password2" ValidationGroup="pass"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToValidate="password2" ForeColor="Red" ValidationGroup="pass" Display="Dynamic" ControlToCompare="password"></asp:CompareValidator>
                    </p>
                    <asp:TextBox ID="password2" runat="server" TextMode="Password"></asp:TextBox>
                   
                    <asp:Button ID="Update_pass" runat="server" Text="Save" ValidationGroup="pass" OnClick="Update_pass_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
