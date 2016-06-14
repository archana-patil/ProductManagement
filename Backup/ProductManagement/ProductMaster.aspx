<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManagement.Master" AutoEventWireup="true"
    CodeBehind="ProductMaster.aspx.cs" Inherits="ProductManagement.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nav">
        <asp:HyperLink ID="hlkAdminLogin" runat="server" NavigateUrl="~/AdminWelcome.aspx">Category</asp:HyperLink><br />
        <asp:HyperLink ID="hlkProductMaster" runat="server" NavigateUrl="~/ProductMaster.aspx">Products</asp:HyperLink><br />
        <asp:LinkButton ID="lnkLogOut" runat="server" OnClick="lnkLogOut_Click" CausesValidation="false">Sign out</asp:LinkButton>
    </div>
    <div class="section">
        <div id="dvProducts">
            <h3>
                Product List</h3>
            <div class="wrapper">
                <div id="productEntry">
                    <asp:Label ID="lblProductName" runat="server" Text="Product Name: "></asp:Label><br />
                    <asp:TextBox ID="txtProductName" runat="server" MaxLength="50"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ErrorMessage="Product Name can't be left blank"
                        ControlToValidate="txtProductName" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                    <asp:Label ID="lblProductDescription" runat="server" Text="Product Description: "
                        MaxLength="50"></asp:Label><br />
                    <asp:TextBox ID="txtProductDescription" runat="server"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvProductDescription" runat="server" ErrorMessage="Product Description can't be left blank"
                        ControlToValidate="txtProductDescription" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                    <asp:Label ID="lblProductPrice" runat="server" Text="Product Price: "></asp:Label><br />
                    <asp:TextBox ID="txtProductPrice" runat="server" MaxLength="50"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvProductPriceV" runat="server" ErrorMessage="Product Price can't be left blank"
                        ControlToValidate="txtProductPrice" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rfvProductPrice" runat="server" ValidationExpression="((\d+)((\.\d{1,2})?))$"
                        ErrorMessage="Please enter valid integer or decimal number" ControlToValidate="txtProductPrice"
                        Display="Dynamic" ForeColor="Red" SetFocusOnError="True" /><br />
                    <asp:Label ID="lblCategoryList" runat="server" Text="Category: "></asp:Label><br />
                    <asp:DropDownList ID="ddlCategoryList" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                    <br />
                    <br />
                    <asp:FileUpload ID="fileUploadProduct" runat="server" />
                    <br />
                    <br />
                    <asp:Button ID="btnInserProduct" runat="server" Text="Add Product" OnClick="btnInserProduct_Click" /><br />
                    <asp:Label ID="lblProductStatus" runat="server" Text=""></asp:Label>
                </div>
                <div id="productDetails">
                    <asp:Label ID="lblSearchProducts" runat="server" Text="Search Products"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtSearchProducts" runat="server" MaxLength="50"></asp:TextBox>
                    &nbsp;<asp:Button ID="btnSearchProducts" runat="server" Text="Search" OnClick="btnSearchProducts_Click"
                        CausesValidation="false" />
                    <div class="dvgridview">
                        <asp:GridView ID="gvProducts" runat="server" DataKeyNames="ProductID" AutoGenerateColumns="False"
                             CellPadding="4" ForeColor="#333333" GridLines="None"
                            OnRowCancelingEdit="gvProducts_RowCancelingEdit" OnRowDataBound="gvProducts_RowDataBound"
                            OnRowEditing="gvProducts_RowEditing" OnPageIndexChanging="gvProducts_PageIndexChanging"
                            OnRowDeleting="gvProducts_RowDeleting" OnRowUpdating="gvProducts_RowUpdating"
                            AllowSorting="true" OnSorting="gvProducts_Sorting" AllowPaging="True" 
                            PageSize="4">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:TemplateField HeaderText="ProductID ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductID" runat="server" Text='<%#Eval("ProductID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product" SortExpression="ProductName">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtProductNameEdit" runat="server" Text='<%#Eval("ProductName")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductDescription" runat="server" Text='<%#Eval("ProductDescription")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtProductDescriptionEdit" runat="server" Text='<%#Eval("ProductDescription")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price" SortExpression="ProductPrice">
                                    <ItemTemplate>
                                        <asp:Label ID="lblProductPrice" runat="server" Text='<%#Eval("ProductPrice")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtProductPrice" runat="server" Text='<%#Eval("ProductPrice")%>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryID" runat="server" Text='<%#Eval("CategoryID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoryName" runat="server" Text='<%#Eval("CategoryName")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="lblCategoryName1" runat="server" Text='<%#Eval("CategoryName")%>'
                                            Visible="false"></asp:Label>
                                        <asp:DropDownList ID="ddlCategoryList1" runat="server">
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Image">
                                    <ItemTemplate>
                                        <asp:Image ID="imgProduct" runat="server" Height="70px" Width="70px" ImageUrl='<%# Eval("FilePath") %>' />
                                        <br />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Image ID="UpdateImage" runat="server" Height="70px" Width="70px" ImageUrl='<%# Eval("FilePath") %>' />
                                        <br />
                                        <asp:FileUpload ID="FileUploadProd" runat="server" />
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
    </div>
</asp:Content>
