<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register Assembly="DayPilot" Namespace="DayPilot.Web.Ui" TagPrefix="DayPilot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="scripts/daypilot-modal-2.1.js"></script>
    <link href="scripts/Site.css" rel="stylesheet" />

    <script type="text/javascript">
        var _width = '450';
        function ExistingEventClick(e) {
            var modal = new DayPilot.Modal();
            modal.height = '350';
            modal.width = _width ;
            modal.closed = function () {
                __doPostBack('btnRefresh', 'OnClick');
            }
            modal.showUrl("OpenExisting.aspx?data=" + e);
        }

        function eventclick(e) {
            var modal = new DayPilot.Modal();
            modal.closed = function () {
                __doPostBack('btnRefresh', 'OnClick');
            }
            modal.height = '350';
            modal.width = _width;
            modal.showUrl("AddNew.aspx?data=" + e);
        }

        function InsertNew() {
            var modal2 = new DayPilot.Modal();
            modal2.height = '350';
            modal2.width = _width;
            modal2.closed = function () {
                __doPostBack('btnRefresh', 'OnClick');
                // __doPostBack('btnRefresh', 'OnClick');
            }
            modal2.showUrl("InsertNew.aspx");
        }
    </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="divHomeMainWrapper">
        <div id="divHomeHeader">
            <span><b>Vehicle Booking System (VBS)</b></span>
        </div>
        <div style="display: block">
            <div style="float: left; width: 220px; height: 580px; padding-left: 1px;">
                <div style="width: 214px;">
                    <asp:Calendar OnDayRender="calPresentMonth_DayRender" 
                        OnVisibleMonthChanged="calPresentMonth_VisibleMonthChanged" 
                        ShowGridLines="true" ID="calPresentMonth" 
                        FirstDayOfWeek="Sunday" runat="server" 
                        OnSelectionChanged="calPresentMonth_SelectionChanged">
                    </asp:Calendar>
                </div>
                <div>
                    <br />
                </div>
                <div class="divHomeLeftOtherContents">
                    <fieldset>
                        <legend><b>Vehicle Info</b></legend>
                        <table>
                            <tr>
                                <%--ITEM 01--%>
                                <td style="background-color: steelblue;">&nbsp;&nbsp;</td>
                                <td>Toyota Noah</td>

                            </tr>
                            <%--<tr style="visibility:hidden">
                                <td>Fish Bowl 02</td>
                                <td style="background-color: blue;"></td>
                                <td></td>
                                <td>West Conf. Room</td>
                                <td style="background-color: grey"></td>
                            </tr>
                            <tr style="visibility:hidden">
                                <td>Fish Bowl 03</td>
                                <td style="background-color: green;"></td>
                                <td></td>
                                <td>Radio Studio</td>
                                <td style="background-color: blueviolet;"></td>
                            </tr>
                            <tr style="visibility:hidden">
                                <td>Fish Bowl 04</td>
                                <td style="background-color: yellow;"></td>
                            </tr>--%>
                        </table>
                    </fieldset>
                </div>
                <div>
                    <br />
                </div>
                <div>
                    <fieldset>
                        <legend><b>Driver Information</b></legend>
                        <table>
                            <tr>
                                <td>Mr. Saiful Islam - 01818263201</td>
                            </tr>
                        </table>
                    </fieldset>

                </div>
                <div>
                    <br />
                </div>
                <div class="divHomeLeftOtherContents">
                    <fieldset>
                        <legend><b>Tasks</b></legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="btnInsetNewEvent" runat="server" Text="New Request" OnClientClick="InsertNew();return false;" CssClass="HomeButtons" />
                                </td>
                                <td>
                                     <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="HomeButtons" OnClick="btnRefresh_Click" />
                                    <asp:Button ID="btnDeleteEvent" runat="server" Text="Remove Event" Enabled="false" CssClass="HomeButtons" Visible="false" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button ID="btnViewAllEvents" runat="server" Text="View All Event" Enabled="false" CssClass="HomeButtons" />
                                </td>
                                <td>
                                    <asp:Button ID="btnLogoff" runat="server" Text="Log Off" CssClass="HomeButtons" OnClick="btnLogoff_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                   
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div id="divHomeBBCMALogo">
                    <img src="SiteAssets/index_full.png" style="margin-left:1em;" />
                </div>

            </div>
            <div id="dp" style="float: right; width: 81%; height: 100%;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <DayPilot:DayPilotCalendar ID="DayPilotCalendar1"
                            Days="7"
                            ClientIDMode="AutoID"
                            BackColor="LightYellow"
                            NonBusinessBackColor="LightYellow"
                            ShowHours="true"
                            BusinessBeginsHour="8"
                            BusinessEndsHour="22"
                            OnBeforeEventRender="DayPilotCalendar1_BeforeEventRender"
                            TimeRangeSelectedHandling="JavaScript"
                            TimeRangeSelectedJavaScript="eventclick('{0}')"
                            EventClickHandling="JavaScript"
                            EventClickJavaScript="ExistingEventClick('{0}')"
                            EventFontFamily="Tahoma"
                            HeaderDateFormat="ddd dd/MM/yyyy"
                            HourFontFamily="Tahoma"
                            runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div id="divHomeFooter">
            Developed and maintained by ICT Department of Meridian Finance & Investment Limited 
        </div>
    </div>
    <asp:Label runat="server" ID="lblUserName" Visible="false"></asp:Label>
</asp:Content>

