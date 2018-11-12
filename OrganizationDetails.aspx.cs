using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class OrganizationDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Student.IsAuthenticated(Session, Request))
        {
            Response.Redirect("Login.aspx");
        }

        //If orgainzation id exists, then get organization by ID, else redirect user to another page.
        if (Request.QueryString["id"] != null)
        {
            int organizationID = int.Parse(Request.QueryString["id"]);

            DataTable dtOrganizationDetails = Organization.GetOrgByID(organizationID);
            dlOrgDetails.DataSource = dtOrganizationDetails;
            dlOrgDetails.DataBind();

            DataTable dtOrganizers = Organizer.GetOrganizersByOrganizationID(organizationID);
            dlOrganizers.DataSource = dtOrganizers;
            dlOrganizers.DataBind();
        }
        else
        {
            Response.Redirect("Organizations.aspx");
        }
    }
}