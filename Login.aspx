<%@ Page Title="Login - HCT Volunteers" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
    <div class="card card-login col col-lg-6 px-0 mx-auto">
        <div class="card-header">Student Login</div>
        <div class="card-body">
            <div class="alert alert-danger" role="alert" id="authAlert" visible="false" runat="server">
                Invalid account credentials.
            </div>

            <div class="alert alert-success" role="alert" id="logoutAlert" visible="false" runat="server">
                You have successfully logged out.<br />
                Enter your credentials below to login again.
            </div>

            <asp:ValidationSummary CssClass="alert alert-danger" ID="validationSummary" runat="server" DisplayMode="List" />

            <div class="form-group">
                <label for="txtId">Student ID</label>
                <asp:TextBox CssClass="form-control" ID="txtId" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtId" ErrorMessage="Please enter your student ID." Display="None"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter your password." Display="None"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group float-left">
                <asp:CheckBox ID="cbRemember" runat="server" Text="&nbsp;Remember me on this computer?" />
            </div>

            <asp:Button ID="btnLogin" CssClass="btn btn-primary float-right" runat="server" OnClick="btnLogin_Click" Text="Login" />
        </div>
    </div>
</asp:Content>
