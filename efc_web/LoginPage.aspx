<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="efc_web.LoginPage" %>
<!DOCTYPE html>
<html>
    <head runat="server">
        <meta charset="utf-8" />
        <title>EFC - Login</title>
    </head>
    <body>
        <h3>Energy Flow Control</h3>
        <form id="messageform" runat="server">
            <div>
                Password: <span><asp:TextBox ID="passwdbox" TextMode="Password" runat="server"></asp:TextBox></span>
                <span><asp:Button ID="loginbtn" runat="server" Text="Login" OnClick="login_click" /></span>
            </div>
            <% if (can_guests_enter()) { %>
                <div>
                    <asp:Button ID="guestbtn" runat="server" Text="Enter as Guest" OnClick="guest_click" />
                </div>
            <% } %>
            <div>
                <asp:Label ID="outputbox" runat="server"></asp:Label>
            </div>
        </form>
    </body>
</html>
