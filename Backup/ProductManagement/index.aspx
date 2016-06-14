<%@ Page Title="" Language="C#" MasterPageFile="~/ProductManagement.Master" AutoEventWireup="true"
    CodeBehind="index.aspx.cs" Inherits="ProductManagement.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        var pageIndex = 1;
        var pageCount;

        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                GetRecords();
            }
        });

        function GetRecords() {
            pageIndex++;

            var rowCounts = document.getElementById("<%= hdfProductRowCount.ClientID %>").value;
            var pageSize = document.getElementById("<%=  hdfProductPageSize.ClientID %>").value;

            pageCount = Math.ceil(rowCounts / pageSize);
            
            if (pageIndex == 2 || pageIndex <= pageCount) {
                $("#loader").show();
                $.ajax({
                    type:"POST",
                    url: "ProductWebService.asmx/GetProductData",
                    //url: "ProductService.svc/GetProductData",
                    data: '{"pageIndex": ' + pageIndex + ', "pageSize": ' + pageSize + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    //crossDomain: true,
                    //processdata:true,
                    success: OnSuccess,
                    failure: function (response) {
                        alert(response.d);
                    },
                    error: function (response) {
                        alert('Service call failed: ' + response.status + '' + response.statusText);
                    }
                });
            }
        }
        
        function OnSuccess(response) {
            var productList = response.d;

            for (var i = 0; i < productList.length; i++) {
                $("#dvProducts").append(GetProductHTMLString(productList[i]));
            }

            $("#loader").hide();
        }

        function GetProductHTMLString(objProduct) {
            var str = objProduct.FilePath;
            var imagePath = str.replace("~/", "");
            return '<div class="dataRow" onclick=CallProductDetailsPage(\"' + objProduct.PageCount + '\");><img height="70px" width="70px" src="' + imagePath + '" />' +
                   '<asp:Label ID="lblProductID" runat="server" Text="' + objProduct.ProductID + '" Visible="false"></asp:Label>' +
                   '<h3><asp:Label ID="lblProductName" runat="server" Text="' + objProduct.ProductName + '"></asp:Label></h3>';
        }
        function CallProductDetailsPage(productID) {
            var pID = productID;
            var url = "ProductDetails.aspx?ProductID=" + pID;
            window.open(url, '_blank');
        }
    </script>
    <asp:HiddenField ID="hdfProductRowCount" runat="server" />
    <asp:HiddenField ID="hdfProductPageSize" runat="server" Value="24" />
    <div class="nav">
        <asp:HyperLink ID="hlkAdminLogin" runat="server" NavigateUrl="~/AdminLogin.aspx"
            ToolTip="Click here for Login">Admin Login</asp:HyperLink>
    </div>
    <div class="section">
        <h1>
            Product List</h1>
        <div id="dvProducts">
            <asp:Repeater ID="rptProducts" runat="server">
                <ItemTemplate>
                    <div class="dataRow" onclick="CallProductDetailsPage('<%# Eval("ProductID") %>');"
                        title="Click here for product more details">
                        <asp:Image ID="imgProduct" runat="server" ImageUrl='<%# Eval("FilePath") %>' />
                        <asp:Label ID="lblProductID" runat="server" Text='<%# Eval("ProductID") %>' Visible="false">
                        </asp:Label>
                        <h3>
                            <asp:Label ID="lblProductName" runat="server" Text='<%#Eval("ProductName")%>'></asp:Label>
                        </h3>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <img id="loader" alt="" src="Contents/Images/loading.gif" style="display: none" />
    </div>
</asp:Content>
