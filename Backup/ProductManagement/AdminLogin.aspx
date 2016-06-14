<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManagement.Master" AutoEventWireup="true"
    CodeBehind="AdminLogin.aspx.cs" Inherits="ProductManagement.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nav">
        <asp:HyperLink ID="hlkHome" runat="server" NavigateUrl="~/index.aspx">Home</asp:HyperLink><br />
    </div>
    <div class="section">
        <div id="login" class="center">
            <fieldset class="login">
                <legend>Admin Login</legend>
                <div>
                    <asp:Label ID="lblUserName" runat="server" Text="User Name:" />
                    <br />
                    <asp:TextBox ID="txtUserName" runat="server" />
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName"
                        CssClass="ValidationSummary" ErrorMessage="Please Enter User Name" SetFocusOnError="True">*</asp:RequiredFieldValidator><br />
                </div>
                <div>
                    <asp:Label ID="lblPassword" runat="server" Text="Password:" />
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
                    <asp:RequiredFieldValidator ID="rvPassword" runat="server" ControlToValidate="txtPassword"
                        CssClass="ValidationSummary" ErrorMessage="Please Enter Password" SetFocusOnError="True">*</asp:RequiredFieldValidator><br />
                </div>
                <div>
                    <p>
                        <asp:Button ID="btnLogIn" runat="server" Text="Sign In" OnClick="btnLogIn_Click" /></p>
                </div>
                <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="ValidationSummary" />
                <br />
                <asp:Label ID="lblMsg" runat="server" Text="" />
            </fieldset>
        </div>
    </div>
</asp:Content>
