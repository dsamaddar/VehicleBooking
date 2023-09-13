using System;
using System.Data;

public partial class OpenExisting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = Request.QueryString["data"].ToString();
        string sessionUser = Session["curUserName"].ToString();
        DataSet ds = DataLayer.runQueryDataset("SELECT * FROM tblEvents WHERE id=" + str);
        txtUserName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
        lblEndTime.Text = ds.Tables[0].Rows[0]["End"].ToString();
        lblID.Text = ds.Tables[0].Rows[0]["id"].ToString();
        lblRoomName.Text = ds.Tables[0].Rows[0]["room"].ToString();
        lblStartTime.Text = ds.Tables[0].Rows[0]["start"].ToString();
        lbldestination.Text = ds.Tables[0].Rows[0]["Destination"].ToString();
        lblPurpose.Text = ds.Tables[0].Rows[0]["purpose"].ToString();
        if(sessionUser==txtUserName.Text)
        {
            btnDelete.Enabled = true;
        }
        else
        {
            btnDelete.Enabled = false;
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int i = DataLayer.runUpDelIns("DELETE FROM tblEvents WHERE id=" + lblID.Text);
        Util.Modal.Close(this);
        
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        Util.Modal.Close(this);
    }
}