<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OpenExisting.aspx.cs" Inherits="OpenExisting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin-left:3em;">
    <script>
        function preloader() {
            document.getElementById("divLoading").style.display = "none";
            document.getElementById("divGenericModalPopup").style.display = "block";
        }//preloader
        window.onload = preloader;
    </script>
    <div id="divLoading" runat="server" class="divLoading">
        <img src="SiteAssets/ajax-loader.gif" class="imgLoading" />
    </div>
    <link href="scripts/Site.css" rel="stylesheet" />
    <form id="form1" runat="server">
        <div id="divGenericModalPopup">
            <h2>Vehicle Booking Information</h2>
            <table>
                <tr>
                    <td>ID</td>
                    <td>
                        <asp:Label ID="lblID" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Request By:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Start Time:
                    </td>
                    <td>
                        <asp:Label ID="lblStartTime" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>End Time:
                    </td>
                    <td>
                        <asp:Label ID="lblEndTime" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Places to visit :
                    </td>
                    <td>
                        <asp:Label ID="lbldestination" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Purpose:
                    </td>
                    <td>
                        <asp:Label ID="lblPurpose" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Vehicle:
                    </td>
                    <td>
                        <asp:Label ID="lblRoomName" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Session User:
                    </td>
                    <td>
                        <asp:Label ID="lblSessionUser" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                        <asp:Button ID="btnOK" runat="server" Text="Cancel" OnClick="btnOK_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
