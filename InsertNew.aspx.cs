using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

public partial class InsertNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUserName.Text = Session["curUserName"].ToString();

        CalendarExtender1.SelectedDate = DateTime.Now.Date;
        txtDate.Attributes.Add("readonly", "readonly");

        ddlRoomName.DataSource = ItemsForList._availableItems;
        ddlRoomName.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime dtStartTime, dtEndTime = new DateTime();
        TextBox txtFind  = (TextBox) this.FindControl("txtDate");
        string test = "", new_message = "";
        string str = txtFind.Text;
        string startvalue = str + " " +hfDDLStart.Value;
        string endvalue = str + " " + hfDDLEnd.Value;
        dtStartTime = Convert.ToDateTime(startvalue);
        dtEndTime = Convert.ToDateTime(endvalue);
        //dtStartTime = DateTime.ParseExact(startvalue, "yyyy/MM/dd HH:mm", null);
         // dtEndTime = DateTime.ParseExact(endvalue  , "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        //int i = DataLayer.runUpDelIns(@"INSERT INTO tblEvents ([Name],[Start],[End],[room],[roomuser],purpose) VALUES
        //('" + txtUserName.Text + "', '" + dtStartTime.ToString() + "', '" + dtEndTime.ToString() + "', '" + ddlRoomName.Text + "', '" + txtUserName.Text + "', '" + txtPurpose.Text + "')");

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBCITDB"].ToString()))
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_user_name", SqlDbType.NVarChar).Value = txtUserName.Text;
            cmd.Parameters.AddWithValue("@_room_name", SqlDbType.NVarChar).Value = ddlRoomName.Text;
            cmd.Parameters.AddWithValue("@_start_time", SqlDbType.NVarChar).Value = dtStartTime.ToString();
            cmd.Parameters.AddWithValue("@_end_time", SqlDbType.NVarChar).Value = dtEndTime.ToString();
            cmd.Parameters.AddWithValue("@_destination", SqlDbType.NVarChar).Value = txtDestination.Text;
            cmd.Parameters.AddWithValue("@_purpose", SqlDbType.NVarChar).Value = txtPurpose.Text;

            cmd.CommandText = "spAddEvent";
            conn.Open();
            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            conn.Close();

            //Session["LastEntry"] = Convert.ToString(ds.Tables[0].Rows[0][0].ToString());
            test = Convert.ToString(ds.Tables[0].Rows[0][0].ToString());
            //mPopupExt.Show();
            //lblTotalBalance.Text = Convert.ToString(ds.Tables[1].Rows[0][0].ToString());
        }

        if (test == "Success")
        {
            new_message = "<script language='javascript'>alert('Your booking was sucessful');</script>";
        }
        else if (test == "NotEmpty")
        {
            new_message = "<script language='javascript'>alert('Sorry your room is already booked');</script>";
        }
        if (!ClientScript.IsClientScriptBlockRegistered(GetType(), "myScript"))
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "alermsg", new_message);
        }
        Util.Modal.Close(this);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Util.Modal.Close(this);
    }
}