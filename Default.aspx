<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #logo {
            position: absolute;
            right: 0px;
            bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <link rel="shortcut icon" type="image/x-icon" href="~/favicon.ico" />
        <link href="scripts/Site.css" rel="stylesheet" />
        <div id="divLoginPage">
            <div>
                <table>
                    <tr>
                        <td colspan="2" style="text-align: center; font-size: larger">Vehicle Booking System
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px; text-align: right;">User Name:
                        </td>
                        <td style="width: 200px;">
                            <asp:TextBox runat="server" ID="txtUserName" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Password:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblError" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" CssClass="globalButtons" />
                        </td>
                    </tr>
                    <tr>
                        <td>

                        </td>
                        <td>
                            <span style="font-size:smaller">Version 1.0</span>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:TextBox ID="hidden01" runat="server" Visible="false"></asp:TextBox>
    </form>
    <img src="SiteAssets/LOGO-1.png" id="logo" />

</body>
</html>
