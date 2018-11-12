<%@ Page Title="Opportunities - HCT Volunteers" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Opportunities.aspx.cs" Inherits="Opportunities" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <h4 class="mb-4">Upcoming Opportunities</h4>

    <div class="card col-12 px-0 mx-auto my-3">
        <div class="card-body row">
            <div class="form-group col-lg-3 col-md-6 col-sm-12">
                <label for="ddlEmirates">Emirate</label>
                <asp:DropDownList ID="ddlEmirates" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="">Select Emirate</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div class="form-group col-lg-3 col-md-6 col-sm-12">
                <label for="ddlOrganizations">Organization</label>
                <asp:DropDownList ID="ddlOrganizations" CssClass="form-control" runat="server" AppendDataBoundItems="True">
                    <asp:ListItem Value="">Select Organization</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div class="form-group col-lg-3 col-md-6 col-sm-12">
                <label for="dtpDateFrom">Date From</label>
                <asp:TextBox type="date" CssClass="form-control" ID="txtDateFrom" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-group col-lg-3 col-md-6 col-sm-12">
                <label for="dtpDateTo">Date To</label>
                <asp:TextBox type="date" CssClass="form-control" ID="txtDateTo" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="card-footer text-muted">
            <asp:Button ID="btnFilter" CssClass="btn btn-success btn-card-header float-right ml-2" Text="Apply Filters" runat="server" OnClick="btnFilter_Click" />
            <asp:Button ID="btnClear" CssClass="btn btn-secondary btn-card-header float-right ml-2" Text="Clear Filters" runat="server" OnClick="btnClear_Click" />
        </div>
    </div>

    <div class="alert alert-info" id="alertEmpty" role="alert" visible="false" runat="server">
        No opportunities available. Please wait until new opportunities are added or change your filter options.
    </div>

    <div class="row">
        <asp:Repeater ID="rptrOpportunities" runat="server">
            <ItemTemplate>
                <div class="col-sm-12 col-md-6 col-lg-4">
                    <div class="card mx-auto mt-2">
                        <div class="card-header">
                            <%#Eval("Name") %>
                        </div>
                        <div class="card-body text-grey">
                            <asp:Image ID="orgLogo" ImageUrl=<%# string.Format("Assets/Images/Organizations/{0}.jpg", Eval("Logo")) %> ToolTip=<%# Eval("OrganizationName") %> AlternateText=<%# Eval("OrganizationName") %> ImageAlign="Right" Width="75" runat="server" />
                            <i class="fas fa-map-marker-alt"></i> <%# Eval("Emirate") %><br />
                            <i class="fas fa-calendar-alt"></i> <%# DateTime.Parse(Eval("StartDate").ToString()).ToString("dd/MM/yyyy") %> - <%# DateTime.Parse(Eval("EndDate").ToString()).ToString("dd/MM/yyyy") %><br /> 
                            <asp:Hyperlink NavigateUrl=<%# string.Format("OpportunityDetails.aspx?id={0}", Eval("OpportunityID")) %> CssClass="btn btn-primary btn-card-header mt-2" runat="server" Text="View Details" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>