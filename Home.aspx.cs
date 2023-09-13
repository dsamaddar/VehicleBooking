using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["curUserName"].ToString() != String.Empty)
        {
            try
            {
                lblUserName.Text = Session["curUserName"].ToString();
            }
            catch
            {
                Response.Redirect("Default.aspx");
            }
        }
        else
        {
            ///// User is not authenticated only readonly view

        }
        this.Title = "Vehicle booking System";
        DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstWorkingDayOfWeek(calPresentMonth.SelectedDate);

        DataSet ds = DataLayer.runQueryDataset(@"SELECT [id],[Name] ,[Start],[End],[room] FROM [dbo].[tblEvents]");
        DayPilotCalendar1.DataSource = ds;
        DayPilotCalendar1.StartDate = Convert.ToDateTime(DayPilot.Utils.Week.FirstWorkingDayOfWeek(calPresentMonth.SelectedDate));
        DayPilotCalendar1.DataStartField = "start";
        DayPilotCalendar1.DataEndField = "end";
        DayPilotCalendar1.DataTextField = "name";
        DayPilotCalendar1.DataValueField = "id";
        DayPilotCalendar1.DataBind();
        if(lblUserName.Text == "goutam")
        {
            DayPilotCalendar1.Enabled = false;
            btnInsetNewEvent.Enabled = false;

        }
        if (!IsPostBack)
        {
            calPresentMonth.SelectedDate = DateTime.Today;
            calPresentMonth_SelectionChanged(null, null);
        }
        calPresentMonth_SelectionChanged(null, null);
    }

    protected void DayPilotCalendar1_BeforeEventRender(object sender, DayPilot.Web.Ui.Events.Calendar.BeforeEventRenderEventArgs e)
    {
        calPresentMonth.Enabled = false;

        if (e.DataItem["room"] != null || e.DataItem["room"] != DBNull.Value || e.DataItem["room"].ToString() == "")
        {

            string roomname = (string)e.DataItem["room"];
            if (roomname == ItemsForList._availableItems[0])  // "type" field must be available in the DataSource
            {
                e.DurationBarColor = "steelblue";

            }
            else if (roomname == "Fish Bowl 02")
            {
                e.DurationBarColor = "blue";
            }
            else if (roomname == "Fish Bowl 03")
            {
                e.DurationBarColor = "green";
            }
            else if (roomname == "Fish Bowl 04")
            {
                e.DurationBarColor = "yellow";
            }
            else if (roomname == "East Conf. Room")
            {
                e.DurationBarColor = "orange";
            }
            else if (roomname == "West Conf. Room")
            {
                e.DurationBarColor = "grey";
            }
            else if (roomname == "Radio Studio")
            {
                e.DurationBarColor = "blueviolet";
            }
            else
            {
                e.DurationBarColor = "white";
            }
        }
        calPresentMonth.Enabled = true;
    }

    public void calPresentMonth_SelectionChanged(object sender, EventArgs e)
    {
        Session["CalDateTime"] = calPresentMonth.SelectedDate.ToString();
        DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(calPresentMonth.SelectedDate);
        for (int i = 0; i < 7; i++)
        {
            DateTime selected = DayPilotCalendar1.StartDate.AddDays(i);
            calPresentMonth.SelectedDates.Add(selected);
        }
        UpdatePanel1.Update();
    }


    protected void calPresentMonth_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.IsOtherMonth)
        {
            e.Cell.ForeColor = Color.LightGray; ;
        }

    }
    protected void calPresentMonth_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        calPresentMonth.SelectedDate = e.NewDate.Date;
        DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(calPresentMonth.SelectedDate);
        for (int i = 0; i < 7; i++)
        {
            DateTime selected = DayPilotCalendar1.StartDate.AddDays(i);
            calPresentMonth.SelectedDates.Add(selected);
        }
        DateTime maxDate = DateTime.Now;
        maxDate = maxDate.AddMonths(2);
        if (e.NewDate.Year == DateTime.Now.Year && e.NewDate.Month == maxDate.Month)
        {
            calPresentMonth.NextMonthText = "";
        }
        else
        {
            calPresentMonth.NextMonthText = ">";
        }


        UpdatePanel1.Update();
    }
    protected void btnLogoff_Click(object sender, EventArgs e)
    {
        Session["curUserName"] = null;
        Response.Redirect("default.aspx");
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        calPresentMonth.SelectedDate = Convert.ToDateTime(Session["CalDateTime"]);  /// Need to put a variable which will only store date which was changed by canlander movement.
        DataSet ds = DataLayer.runQueryDataset(@"SELECT [id],[Name] ,[Start],[End],[room] FROM [dbo].[tblEvents]");
        DayPilotCalendar1.DataSource = ds;
        DayPilotCalendar1.StartDate = DayPilot.Utils.Week.FirstDayOfWeek(calPresentMonth.SelectedDate);
        for (int i = 0; i < 7; i++)
        {
            DateTime selected = DayPilotCalendar1.StartDate.AddDays(i);
            calPresentMonth.SelectedDates.Add(selected);
        }
        UpdatePanel1.Update();
    }


    protected void btnSendTestEmail_Click(object sender, EventArgs e)
    {
        //SendEmail.send( VehicleName, string DriverName, string BookedBy, string Designation, string Destination);
    }
}