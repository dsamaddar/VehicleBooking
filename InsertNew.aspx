<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InsertNew.aspx.cs" Inherits="InsertNew"
    EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin-left: 3em;">
    <link href="scripts/Site.css" rel="stylesheet" />

    <script type="text/javascript">
        function preloader() {
            document.getElementById("divLoading").style.display = "none";
            document.getElementById("divGenericModalPopup").style.display = "block";
            load();
        }//preloader
        window.onload = preloader;
        function load() {
            populateDropDownlist("ddlStartTime");
            changeCursor();
            ddlStartFillHidden();
        }

        function populateDropDownlist(_objName) {
            var quit = false;
            var count = 1;
            var hour = 7;
            var min = 30;
            var _text = '00';
            if (_objName == 'ddlEndTime') {
                _text = '30';
                min = 30;
            }
            while (quit != true) {
                var select = document.getElementById(_objName);
                var option = document.createElement("option");
                min = min + 30;
                if (min == 60) {
                    hour++;
                    min = 0;
                }
                option.value = count;
                if (min == 0)
                { _text = '00'; }
                else
                { _text = '30'; }
                option.innerHTML = hour + ':' + _text;
                select.appendChild(option);

                if (hour == 21 && min == 0) {
                    quit = true;
                }
                count++;
            }

        }
        function changeCursor() {
            var select = document.getElementById('ddlStartTime');
            var _startTime = select.options[select.selectedIndex].text;
            var aftersplit = _startTime.split(':');
            var count = 1;
            var hour = parseInt(aftersplit[0]);
            var min = parseInt(aftersplit[1]);
            var _text = '00';
            document.getElementById('ddlEndTime').options.length = 0;
            var quit = false;
            while (quit != true) {
                var select = document.getElementById('ddlEndTime');
                var option = document.createElement("option");
                min = min + 30;
                if (min == 60) {
                    hour++;
                    min = 0;
                }
                option.value = count;
                if (min == 0)
                { _text = '00'; }
                else
                { _text = '30'; }
                option.innerHTML = hour + ':' + _text;
                select.appendChild(option);

                if (hour == 21 && min == 0) {
                    quit = true;
                }
                count++;
                //alert(hour + ':' + min);
            }

        }
        function ddlStartFillHidden() {

            var dll = document.getElementById('ddlStartTime');
            var selected = dll.options[dll.selectedIndex].text;
            document.getElementById('hfDDLStart').value = selected;
            dll = document.getElementById('ddlEndTime');
            selected = dll.options[dll.selectedIndex].text;
            document.getElementById('hfDDLEnd').value = selected;
        }
    </script>

    <form id="form1" runat="server">
    <div id="divLoading" runat="server" class="divLoading">
        <img src="SiteAssets/ajax-loader.gif" class="imgLoading" />
    </div>
    <div id="divGenericModalPopup">
        <h2>
            Request for Booking Vehicle</h2>
        <table>
            <tr>
                <td>
                    Request By
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Date
                </td>
                <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ScriptManager>
                <td>
                    <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>
                    Start Time
                </td>
                <td>
                    <asp:DropDownList ID="ddlStartTime" runat="server" onchange="changeCursor();ddlStartFillHidden()">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    End Time
                </td>
                <td>
                    <asp:DropDownList ID="ddlEndTime" runat="server" onchange="ddlStartFillHidden()">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Room
                </td>
                <td>
                    <asp:DropDownList ID="ddlRoomName" runat="server">
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
                    Purpose
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
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="Save" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfDDLStart" runat="server" />
        <asp:HiddenField ID="hfDDLEnd" runat="server" />
    </div>
    </form>
</body>
</html>
