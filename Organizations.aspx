<%@ Page Title="Organizations - HCT Volunteers" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Organizations.aspx.cs" Inherits="Organizations" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <h4 class="mb-4">Partnered Organizations</h4>

    <div class="input-group mt-1 mb-3">
        <asp:TextBox CssClass="form-control" ID="txtSearch" placeholder="Search by name..." runat="server"></asp:TextBox>
        <div class="input-group-append">
            <button runat="server" id="btnSearch" onserverclick="btnSearch_Click" class="btn btn-secondary" type="button"><i class="fas fa-search"></i> Search</button>
        </div>
    </div>

    <div class="alert alert-info" id="alertEmpty" role="alert" visible="false" runat="server">
        No organizations matching your search input found. Please change the input and try again.
    </div>

    <asp:Repeater ID="rptrOrganizations" runat="server">
        <ItemTemplate>
            <div class="card col col-12 px-0 mx-auto mt-4">
                <div class="card-body d-flex flex-column">
                    <div class="row">
                        <div class="col-md-2 col-sm-12 text-center">
                            <asp:Image CssClass="img-fluid org-img" runat="server" ImageUrl='<%# "Assets/Images/Organizations/" + Eval("Logo") + ".jpg"%>' />
                        </div>
                            
                        <div class="col-md-10 col-sm-12 align-self-center mt-3">
                            <div class="row">
                                <div class="col-lg-10 col-md-9 col-sm-12">
                                    <h5><%# Eval("Name") %></h5>
                                    <p><%# Eval("Description").ToString().Substring(0, Math.Min(Eval("Description").ToString().Length, 250)) %>...</p>
                                </div>
                                    
                                <div class="col-lg-2 col-md-3 col-sm-12 align-self-center">
                                    <asp:Hyperlink NavigateUrl=<%# string.Format("OrganizationDetails.aspx?id={0}", Eval("OrganizationID")) %> CssClass="btn btn-primary btn-block" Text="View Details" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>