using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Organizations : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Student.IsAuthenticated(Session, Request))
        {
            Response.Redirect("Login.aspx");
        }
        else if (!Page.IsPostBack)
        {
            DataTable organizations = Organization.GetAll();
            ListOrganizations(organizations);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string input = txtSearch.Text;

        DataTable organizations = Organization.GetAllLikeName(input);
        ListOrganizations(organizations);
    }

    private void ListOrganizations(DataTable organizations)
    {
        // Gets all organizations and bind it to the repeater control.
        if (organizations.Rows.Count == 0)
        {
            alertEmpty.Visible = true;
            rptrOrganizations.DataSource = null;
            rptrOrganizations.DataBind();
        }
        else
        {
            alertEmpty.Visible = false;
            rptrOrganizations.DataSource = organizations;
            rptrOrganizations.DataBind();
        }
    }
}