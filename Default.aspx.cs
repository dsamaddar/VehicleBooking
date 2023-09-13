using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ":: Login ::";

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Home.aspx", false);

        if (Auth_WithPric(txtUserName.Text, txtPassword.Text) == false)
        {
            lblError.Text = "Unable to login.";
        }
        else
        {
            Session["curUserName"] = txtUserName.Text;
            Session["LastEntry"] = "Initilized";

            try
            {
                Response.Redirect("~/Home.aspx", false);

            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }


        }

        //lblError.Text = Auth_WithPric(txtUserName.Text, txtPassword.Text).ToString();

        //if(AuthUser(txtUserName.Text, txtPassword.Text) == "not found")
        //{
        //   lblError.Text = "Unable to login.";
        //}
        //else
        //{ 
        //    Response.Redirect("~/Home.aspx");

        //}

    }

    public bool Auth_WithPric(string user, string pass)
    {
        bool value; //, IsInAccessGroup = false ;
        //string result = "";
        using (var pc = new PrincipalContext(ContextType.Domain, "MFILBD.COM", "DC=MFILBD,DC=COM"))
        {
            value = pc.ValidateCredentials(user, pass);

            if(value == false)
            {
                return value;
            }

            UserPrincipal userg = UserPrincipal.FindByIdentity(pc, user);

            if (userg != null)
            {
                // get the user's groups
                var groups = userg.GetAuthorizationGroups();

                foreach (GroupPrincipal group in groups)
                {
                    if(group.Name == "WebApp - VehicleBooking - Access")
                    {
                        return true;
                    }
                    // do whatever you need to do with those groups
                }
            }
        }
        return false;
    }

    //public bool AuthUser_Type3(string user, string pass)
    //{

    //    string path = "LDAP://192.168.1.10";
    //    DirectoryEntry dirEntry = new DirectoryEntry(path, user, pass, AuthenticationTypes.Secure);
    //    try
    //    {
    //        DirectorySearcher dirSearcher = new DirectorySearcher(dirEntry);
    //        dirSearcher.FindOne();
    //        return true;
    //        // If it returns the data then the User is validated otherwise it will automatically shift to catch block and return false
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.ToString());
    //        return false;
    //    }
    //}

    /*
    public string AuthUser_Type2(string user, string pass)
    { 
        
        // build UID string
        String uid = "uid=" + user + ",ou=people,dc=bd,dc=bbcmediaaction,dc=org";
        // assign password
        String password = txtPassword.Text;
        // define LDAP connection
        DirectoryEntry root = new DirectoryEntry(
            "LDAP://bd.bbcmediaaction.org", uid, password,
            AuthenticationTypes.Secure);
 
        try {
            // attempt to use LDAP connection
            object connected = root.NativeObject;
            // no exception, login successful
            //Response.Write("<span style=""color:green;"">Login successful.</span>");
            return "ok";
        } catch (Exception ex) {
            // exception thrown, login failed
            Response.Write(ex.ToString());
            return "nope";
        }
 
        
    
 
    }

    public string AuthUser(string user, string pass)
    {
        DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://bd.bbcmediaaction.org",user,pass);
        directoryEntry.AuthenticationType = AuthenticationTypes.Secure;

        DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
        // April 6 - good respone with "(&(objectCategory=person)(objectClass=user))(SAMAccountName={0})" ; nope as it logs on with wrong username and pass
        // (SAMAccountName={0}) ; works
        directorySearcher.Filter = string.Format("(&(&(objectCategory=person)(objectClass=user))(SAMAccountName={0}))", user);
        

        try
        {
            var result = directorySearcher.FindOne();
            var resultDirectoryEntry = result.GetDirectoryEntry();
            Session["curUserName"] = resultDirectoryEntry.Properties["cn"].Value.ToString();
            string str = resultDirectoryEntry.Properties["cn"].Value.ToString();
            directorySearcher.Dispose();
            directoryEntry.Dispose();
            return str;

        }
        catch
        {
            Session["curUserName"] = string.Empty;
            directorySearcher.Dispose();
            directoryEntry.Dispose();
            return "not found";


        }
        
        
    }

    public bool AuthenticateUser(string domain, string username, string password, string LdapPath, out string Errmsg)
    {

        Errmsg = "";
        string domainAndUsername = domain + @"\" + username;
        DirectoryEntry entry = new DirectoryEntry(LdapPath, domainAndUsername, password );
        try
        {

            // Bind to the native AdsObject to force authentication.

            Object obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + username + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            if (null == result)
            {
                return false;
            }

            // Update the new path to the user in the directory
            LdapPath = result.Path;
            string _filterAttribute = (String)result.Properties["cn"][0];

        }

        catch (Exception ex)
        {
            Errmsg = ex.Message;
            return false;
            throw new Exception("Error authenticating user." + ex.Message);
        }

        return true;

    }
    */
}
