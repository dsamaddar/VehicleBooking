using System;
using System.Web.UI;
using System.Globalization;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class scripts_AddNew : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string str = Request.QueryString["data"].ToString();
        DateTime dt = Convert.ToDateTime(str);
        string[] str2 = str.Split('T');
        lblDate.Text = str2[0];
        lblTime.Text = str2[1];
        
        TimeSpan tspan = DateTime.Parse(str2[1]) - DateTime.Parse("9:00 PM");
        
        while (dt.Hour < 21 )
        {
            dt = dt.AddMinutes(30);
            ddl.Items.Add(dt.ToString("hh:mm tt"));
        }
        txtUserName.Text = Session["curUserName"].ToString();

        if(txtUserName.Text == "goutam")
        {
            btnSaveInformation.Enabled = false;
        }


        ddlRoom.DataSource = ItemsForList._availableItems;
        ddlRoom.DataBind();
    }

    protected void btnSaveInformation_Click(object sender, EventArgs e)
    {
        DateTime dtStartTime, dtEndTime = new DateTime();
        string str = lblDate.Text;
        string new_message = null; ;
        string test;
        str = str.Replace('-', '/');
        dtStartTime = DateTime.ParseExact(str +" " + lblTime.Text, "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
        dtEndTime = DateTime.ParseExact(str + " " + Convert.ToDateTime( ddl.Text).ToString("HH:mm:ss"), "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBCITDB"].ToString()))
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@_user_name", SqlDbType.NVarChar).Value = txtUserName.Text;
            cmd.Parameters.AddWithValue("@_room_name", SqlDbType.NVarChar).Value = ddlRoom.Text;
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
        }
        
        if(test=="Success")
        {
            new_message = "<script language='javascript'>alert('Your booking was sucessful');</script>";

            SendEmail.send(ddlRoom.Text.Split('-')[0], ddlRoom.Text.Split('-')[1], txtUserName.Text, null, txtPurpose.Text, dtStartTime.ToString(), dtEndTime.ToString());
        }
        else if(test == "NotEmpty")
        {
            new_message = "<script language='javascript'>alert('Sorry your room is already booked');</script>";
        }
        if (!ClientScript.IsClientScriptBlockRegistered(GetType(),"myScript") )
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), "alermsg", new_message);
        }
        
        Util.Modal.Close(this, test);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Session["LastEntry"] = "NoResponse";
        Util.Modal.Close(this);
    }
}
