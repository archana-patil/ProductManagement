<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManagement.Master" AutoEventWireup="true"
    CodeBehind="ProductDetails.aspx.cs" Inherits="ProductManagement.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="stack">
            <div class="row">
                <div class="col">
                    <asp:Image ID="imgProduct" runat="server" ImageUrl="" />
                </div>
                <div class="col">
                    <asp:Label ID="lblProductID" runat="server" Text="" Visible="false">
                    </asp:Label>
                    <h3>
                        Name:
                        <asp:Label ID="lblProductName" runat="server"></asp:Label>
                    </h3>
                    <br />
                    Description:
                    <asp:Label ID="lblProductDescription" runat="server"></asp:Label>
                    <br />
                    <br />
                    Price:
                    <asp:Label ID="lblProductPrice" runat="server"></asp:Label>
                    <br />
                    <br />
                    Category:
                    <asp:Label ID="lblCategory" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
