using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Opportunities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Student.IsAuthenticated(Session, Request))
        {
            Response.Redirect("Login.aspx");
        }
        else if (!Page.IsPostBack)
        {
            DataTable opportunities = Opportunity.GetAllUpcoming();

            ListOpportunities(opportunities);

            // populate filter ddls
            DataTable emirates = Opportunity.GetAllEmirates();
            ddlEmirates.DataSource = emirates;
            ddlEmirates.DataTextField = "Emirate";
            ddlEmirates.DataValueField = "Emirate";
            ddlEmirates.DataBind();

            DataTable organizations = Organization.GetNames();
            ddlOrganizations.DataSource = organizations;
            ddlOrganizations.DataTextField = "Name";
            ddlOrganizations.DataValueField = "OrganizationID";
            ddlOrganizations.DataBind();
        }
    }

    private void ListOpportunities(DataTable opportunities)
    {
        if (opportunities.Rows.Count == 0)
        {
            alertEmpty.Visible = true;
            rptrOpportunities.DataSource = null;
            rptrOpportunities.DataBind();
        }
        else
        {
            alertEmpty.Visible = false;
            rptrOpportunities.DataSource = opportunities;
            rptrOpportunities.DataBind();
        }
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        string emirate = ddlEmirates.SelectedValue;
        int? organizationId = null;
        DateTime? dateFrom = null;
        DateTime? dateTo = null;

        if (int.TryParse(ddlOrganizations.SelectedValue, out int parsedOrgId))
            organizationId = parsedOrgId;

        if (DateTime.TryParse(txtDateFrom.Text, out DateTime parsedDateFrom))
            dateFrom = parsedDateFrom;

        if (DateTime.TryParse(txtDateTo.Text, out DateTime parsedDateTo))
            dateTo = parsedDateTo;

        DataTable opportunities = Opportunity.GetAllFiltered(emirate, organizationId, dateFrom, dateTo);

        ListOpportunities(opportunities);
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ddlEmirates.SelectedIndex = 0;
        ddlOrganizations.SelectedIndex = 0;
        txtDateFrom.Text = "";
        txtDateTo.Text = "";

        DataTable opportunities = Opportunity.GetAllUpcoming();

        ListOpportunities(opportunities);
    }
}