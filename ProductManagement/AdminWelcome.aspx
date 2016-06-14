<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManagement.Master" AutoEventWireup="true"
    CodeBehind="AdminWelcome.aspx.cs" Inherits="ProductManagement.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nav">
        <asp:HyperLink ID="hlkAdminLogin" runat="server" NavigateUrl="~/AdminWelcome.aspx">Category</asp:HyperLink><br />
        <asp:HyperLink ID="hlkProductMaster" runat="server" NavigateUrl="~/ProductMaster.aspx">Products</asp:HyperLink><br />
        <asp:LinkButton ID="lnkLogOut" runat="server" CausesValidation="false" OnClick="lnkLogOut_Click">Sign out</asp:LinkButton>
    </div>
    <div class="section">
        <div id="dvCategory">
            <h3>
                Category List</h3>
            <div class="wrapper">
                <div id="categoryEntry">
                    <asp:Label ID="lblCategory" runat="server" Text="Enter Category: "></asp:Label><br />
                    <asp:TextBox ID="txtCategory" runat="server" MaxLength="50"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ErrorMessage="Category Name can't be left blank"
                        ControlToValidate="txtCategory" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                    <asp:Button ID="btnInsertCategory" runat="server" Text="Add Category" OnClick="btnInsertCategory_Click" /><br />
                    <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                </div>
                <div id="categoryDetails">
                    <asp:Label ID="lblSearchCategory" runat="server" Text="Search Category"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtSearchCategory" runat="server" MaxLength="50"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnSearchCategory" runat="server" Text="Search" CausesValidation="false"
                        OnClick="btnSearchCategory_Click" />
                    <br />
                    <asp:GridView ID="gvCategory" runat="server" DataKeyNames="CategoryID" AutoGenerateColumns="False"
                        OnRowDeleting="gvCategory_RowDeleting" OnRowCancelingEdit="gvCategory_RowCancelingEdit"
                        OnRowEditing="gvCategory_RowEditing" OnRowUpdating="gvCategory_RowUpdating" AllowPaging="true"
                        PageSize="10" CellPadding="4" ForeColor="#333333" GridLines="None" OnPageIndexChanging="gvCategory_PageIndexChanging"
                        Width="50%" AllowSorting="true" OnSorting="gvCategory_Sorting">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField HeaderText="Category ID" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoryID" runat="server" Text='<%#Eval("CategoryID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Category" SortExpression="CategoryName">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoryName" runat="server" Text='<%#Eval("CategoryName")%>'></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCategoryNameEdit" runat="server" Text='<%#Eval("CategoryName")%>'></asp:TextBox>
                                </EditItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditcategory" runat="server" ImageUrl="~/Contents/Images/edit.png"
                                        CommandName="Edit" CausesValidation="false" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:LinkButton ID="lnkUpdatecategory" runat="server" Text="Update" CommandName="Update"
                                        CausesValidation="false"></asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancelCategory" runat="server" Text="Cancel" CommandName="Cancel"
                                        CausesValidation="false"></asp:LinkButton>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDeleteCategory" runat="server" ImageUrl="~/Contents/Images/delete.png"
                                        CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure you want to delete?')" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                </EditItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
