<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="scripts_AddNew" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="scripts/Site.css" rel="stylesheet" />
</head>
<body style="margin-left: 3em;">

    <script type="text/javascript">
        function preloader() {
            document.getElementById("divLoading").style.display = "none";
            document.getElementById("divGenericModalPopup").style.display = "block";
            var name = document.getElementById('txtUserName').value;
            console.log(name);
            //alert(name);
            if (name == 'rezaur') {
                //alert('common');
                document.getElementById('#txtUserName').disabled = true;
            }
        }
        window.onload = preloader;
    </script>

    <div id="divLoading" runat="server" class="divLoading">
        <img src="SiteAssets/ajax-loader.gif" alt="" class="imgLoading" />
    </div>
    <form id="form1" runat="server">
    <div id="divGenericModalPopup">
        <h2>
            Request for Booking Vehicle</h2>
        <table>
            <tr>
                <td>
                    Request By:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtUserName" ReadOnly="true" MaxLength="190"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Selected Date:
                </td>
                <td>
                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Selected Time:
                </td>
                <td>
                    <asp:Label ID="lblTime" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    End Time:
                </td>
                <td>
                    <asp:DropDownList ID="ddl" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Vehicle:
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoom" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Places to Visit
                </td>
                <td>
                    <asp:TextBox ID="txtDestination" runat="server" MaxLength="199" TextMode="MultiLine"
                        ValidationGroup="Save"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFldDestination" runat="server" ErrorMessage="*"
                        ControlToValidate="txtDestination" ValidationGroup="Save"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Purpose:
                </td>
                <td>
                    <asp:TextBox ID="txtPurpose" runat="server" MaxLength="199" TextMode="MultiLine"
                        ValidationGroup="Save"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqFldPurpose" runat="server" ErrorMessage="*" ControlToValidate="txtPurpose"
                        ValidationGroup="Save"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button runat="server" ID="btnSaveInformation" OnClick="btnSaveInformation_Click"
                        Text="Save" ValidationGroup="Save" />
                    <asp:Button runat="server" ID="btnCancel" OnClick="btnCancel_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
