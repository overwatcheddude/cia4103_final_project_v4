<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizationDetails.aspx.cs" Inherits="OrganizationDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:DataList ID="dlOrgDetails" runat="server">
                <ItemTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Image ID="imgOrganization" runat="server" ImageUrl='<%# "Assets/Images/Organizations/" + Eval("Logo") + ".jpg"%>' />
                            </td>
                            <td><strong>Organization Name: </strong>
                                <asp:Literal ID="litName" runat="server" Text='<%# Eval("Name") %>'></asp:Literal>
                                <br />
                                <strong>Description: </strong>
                                <asp:Literal ID="litDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td><strong>Address: </strong><br />
                                <asp:Literal ID="litAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Literal>
                            </td>
                            <td><strong><em>Contact</em></strong><br /> <strong>Number: </strong>
                                <asp:Literal ID="litNumber" runat="server" Text='<%# Eval("ContactNumber") %>'></asp:Literal>
                                <br />
                                <strong>Email: </strong>
                                <asp:Literal ID="litEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
            <asp:DataList ID="dlOrganizers" runat="server">
                <ItemTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <strong>Name: </strong><asp:Literal ID="litOrganizerName" runat="server" Text='<%# Eval("FirstName") + " " + Eval("MiddleName") + " " + Eval("LastName")%>'></asp:Literal> <br />
                                <strong>Email: </strong><asp:Literal ID="litEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Literal> <br />
                                <strong>Mobile Number: </strong><asp:Literal ID="litMobileNumber" runat="server" Text='<%# Eval("MobileNumber") %>'></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </form>
</body>
</html>
