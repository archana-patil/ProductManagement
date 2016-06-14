/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:User Interface Layer
* Date:27 Jan 2016
* Dependancy: ProductDAL.cs, ProductBAL.cs, Product.cs
*/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ModelController.Prodoucts;
using System.Collections.Generic;
using ModelController.Categories;
using System.IO;
using System.Reflection;
using System.Linq;
using ProductManagement.ProductServiceReference;

namespace ProductManagement
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        #region -- Variable Declaration --

        /// <summary>
        /// Initializes product object
        /// </summary>
        Product objProduct = new Product();

        #endregion
        
        #region -- Events --

        /// <summary>
        /// Clear all controls on this page, get list of categories and bind to dropdownlist
        /// Get list of products and bind to grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //check page is post back
            if (!Page.IsPostBack)
            {
                
                //For authentication check session have value 
                if (Session["UserLogin"] != null)
                {
                    //Call a method to clear all control on this page
                    ClearControls();

                    //Call a method to bind records of category list to category dropdownlist
                    BindCategoryDropDownList();

                    //Call a method to bind records of product list to gridview 
                    BindProductsGridView();
                }
                else 
                {
                    //Clear all sessions
                    Session.Clear();
                    
                    //User will redirect to the login page
                    Response.Redirect("AdminLogin.aspx");
                }
            }
        }
        
        /// <summary>
        /// Insert Product Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInserProduct_Click(object sender, EventArgs e)
        {
            //Set products object values 
            objProduct.ProductName = txtProductName.Text;
            objProduct.ProductDescription = txtProductDescription.Text;
            objProduct.ProductPrice = Convert.ToDecimal(txtProductPrice.Text);
            objProduct.CategoryID = ddlCategoryList.SelectedValue;

            //Check if file upload control have a file 
            if (fileUploadProduct.HasFile)
            {
                //Get file name 
                string fileName = Path.GetFileName(fileUploadProduct.PostedFile.FileName);

                //Save file on related path
                fileUploadProduct.PostedFile.SaveAs(Server.MapPath("~/Contents/Images/Products/") + fileName.Trim());
                
                //Set file path value to product object
                objProduct.FilePath = "~/Contents/Images/Products/" + fileName.Trim();
            }
            
            //check if there is null values for handelling exceptions
            if (objProduct.ProductName != null &&
                objProduct.ProductDescription != null &&
                objProduct.ProductPrice >= 0 &&
                objProduct.CategoryID != null)
            {
                //Initializes object for WCF service
                ProductServiceClient productService = new ProductServiceClient();

                //call InsertProduct method from WCF service and get the return value  
                int retVal = productService.InsertProduct(objProduct);
                
                //if return value is equal to "0" means record inserted successfully
                if (retVal == 0)
                {
                    //Call a method to clear all control on this page
                    ClearControls();

                    //Call a method to bind records of product list to gridview 
                    BindProductsGridView();

                    //Set label text value and color
                    lblProductStatus.Text = "Product inserted successfully";
                    lblProductStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    //Set label text value and color
                    lblProductStatus.Text = "Product couldn't be inserted";
                    lblProductStatus.ForeColor = System.Drawing.Color.Red;
                }

                //close the product object
                productService.Close();
            }
        }

        /// <summary>
        /// Bound Data to DropDownList of Category for Selected Product 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //Initializes object for WCF service
                    ProductServiceClient productService = new ProductServiceClient();

                    //Get control values from grid view control
                    Label lblCategory = (Label)e.Row.FindControl("lblCategoryName1");
                    DropDownList ddlCategory = (DropDownList)e.Row.FindControl("ddlCategoryList1");
                    
                    //Initializes object for category list 
                    IList<Category> lstCategory = new List<Category>();

                    //Get category list using WCF mathod
                    lstCategory = productService.GetCategoryList();

                    //Check if category list object exist a records
                    if (lstCategory.Count > 0)
                    {
                        //Set list value to category dropdownlist data source 
                        ddlCategory.DataSource = lstCategory;

                        //Set category dropdownlist data value field
                        ddlCategory.DataValueField = "CategoryID";

                        //Set category dropdownlist data text field
                        ddlCategory.DataTextField = "CategoryName";

                        //Bind category dropdownlist control to display category list
                        ddlCategory.DataBind();
                    }
                    else
                    {
                        //if category list not exist then set grid view data source set to null
                        ddlCategory.DataSource = null;

                        //Bind category dropdownlist control to display null list of category
                        ddlCategory.DataBind();
                    }

                    //Set selected value for category dropdownlist control 
                    ddlCategory.Items.FindByText(lblCategory.Text).Selected = true;

                    //close the product object
                    productService.Close();
                }
            }
        }

        /// <summary>
        /// Edit Product Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set edit index of grid view while user will cancel the edit record
            gvProducts.EditIndex = e.NewEditIndex;

            //Call to bind method to display product list
            BindProductsGridView();
        }

        /// <summary>
        /// Update Product Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //set values for product object 
            objProduct.ProductID = (gvProducts.Rows[e.RowIndex].FindControl("lblProductID") as Label).Text;
            objProduct.ProductName = ((TextBox)(gvProducts.Rows[e.RowIndex].FindControl("txtProductNameEdit"))).Text.Trim();
            objProduct.ProductDescription = ((TextBox)(gvProducts.Rows[e.RowIndex].FindControl("txtProductDescriptionEdit"))).Text.Trim();
            objProduct.ProductPrice = Convert.ToDecimal(((TextBox)(gvProducts.Rows[e.RowIndex].FindControl("txtProductPrice"))).Text.Trim());
            objProduct.CategoryID = ((DropDownList)(gvProducts.Rows[e.RowIndex].FindControl("ddlCategoryList1"))).Text.Trim();
            
            //Set image value to file upload control
            FileUpload UploadImage = (FileUpload)gvProducts.Rows[e.RowIndex].FindControl("FileUploadProd");

            //Check if file upload control have a value
            if (UploadImage.HasFile)
            {
                //Get file name
                string fileName = Path.GetFileName(UploadImage.PostedFile.FileName);
                
                //Save file on related path
                UploadImage.PostedFile.SaveAs(Server.MapPath("~/Contents/Images/Products/") + fileName.Trim());
                
                //Set new file path value to product object
                objProduct.FilePath = "~/Contents/Images/Products/" + fileName.Trim();
            }
            else
            {
                //Get value from product grid view control
                Image displayimage = (Image)gvProducts.Rows[e.RowIndex].FindControl("UpdateImage");

                //Set ImageUrl value ro path variable
                string path = displayimage.ImageUrl;
                
                //Set existing file path value to product object
                objProduct.FilePath = path;
            }
            
            //Check records before call update method if null
            if (objProduct.ProductID != null &&
                objProduct.ProductName != null &&
                objProduct.ProductDescription != null &&
                objProduct.ProductPrice >= 0 &&
                objProduct.CategoryID != null)
            {
                //Initializes object for WCF service
                ProductServiceClient productService = new ProductServiceClient();

                //Update product record using wcf service method
                int retVal = productService.UpdateProduct(objProduct);
                
                //Check return value to display proper message after successful update of product 
                if (retVal == 0)
                {
                    //Call a method to clear all control on this page
                    ClearControls();
                    
                    //Set product grid view edit index to -1
                    gvProducts.EditIndex = -1;

                    //Call a method to bind product list to gridview 
                    BindProductsGridView();

                    //Set label text value and color
                    lblProductStatus.Text = "Product information updated successfully";
                    lblProductStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    //Set label text value and color
                    lblProductStatus.Text = "Product couldn't be updated";
                    lblProductStatus.ForeColor = System.Drawing.Color.Red;
                }

                //close the product object
                productService.Close();
            }
        }

        /// <summary>
        /// Cancel Editing Product Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Set edit index of grid view while user will cancel the edit record
            gvProducts.EditIndex = -1;
            
            //Call to bind method to display product list
            BindProductsGridView();
        }

        /// <summary>
        /// Paging in GridView 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Set page index of grid view while user will click on page numbers
            gvProducts.PageIndex = e.NewPageIndex;

            //Call bind method to display product list on next, previous and selected page
            BindProductsGridView();
        }

        /// <summary>
        /// Delete Product Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //set values for category object 
            objProduct.ProductID = (gvProducts.Rows[e.RowIndex].FindControl("lblProductID") as Label).Text;

            //Check if product Id is not null
            if (objProduct.ProductID != null)
            {
                //Initializes object for WCF service
                ProductServiceClient productService = new ProductServiceClient();

                //Delete product record using wcf service method
                int retVal = productService.DeleteProduct(objProduct);

                //Check return value to display proper message after successfully deleted product
                if (retVal == 0)
                {
                    //Call a method to clear all control on this page
                    ClearControls();

                    //Call a method to bind records of category list to gridview 
                    BindProductsGridView();

                    //Set label text value and color
                    lblProductStatus.Text = "Product deleted successfully";
                    lblProductStatus.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    //Set label text value and color
                    lblProductStatus.Text = "Product couldn't be deleted";
                    lblProductStatus.ForeColor = System.Drawing.Color.Red;
                }

                //close the product object
                productService.Close();
            }
        }

        /// <summary>
        /// Search Product Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchProducts_Click(object sender, EventArgs e)
        {
            //set values for category object
            objProduct.ProductName = txtSearchProducts.Text;
            
            //Check value of product name if is not null
            if (objProduct.ProductName != null)
            {
                //Initializes object for WCF service
                ProductServiceClient productService = new ProductServiceClient();
                
                //Initialises product list object 
                IList<Product> lstProducts = new List<Product>();

                //Get Data from search method of wcf service 
                lstProducts = productService.SearchProducts(objProduct);

                //Check if product records exist
                if (lstProducts.Count > 0)
                {
                    //Set product list value to grid view data source 
                    gvProducts.DataSource = lstProducts;

                    //Bind grid view control to display category list
                    gvProducts.DataBind();
                }
                else
                {
                    //if product record not exist then set grid view data source to null
                    gvProducts.DataSource = null;

                    //Bind grid view control to display null list of products
                    gvProducts.DataBind();
                }

                //Call a method to clear all control on this page
                ClearControls();

                //close the product object
                productService.Close();
            }
        }

        /// <summary>
        /// Call Login page after sign out 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            //Clear all sessions 
            Session.Clear();

            //Redirect to login page
            Response.Redirect("AdminLogin.aspx");
        }

        protected void gvProducts_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Initializes object for WCF service
            ProductServiceClient productService = new ProductServiceClient();

            //Initialises product list object 
            IList<Product> lstProduct = new List<Product>();

            //Get product list using wcf service method
            lstProduct = productService.GetProducts();

            string Sortdir = GetSortingOrder(e.SortExpression);
            string SortExp = e.SortExpression;

            //if (Sortdir == "ASC")
            //{
            //    lstProduct = Sort<Product>(lstProduct, SortExp, SortDirection.Ascending);
            //}
            //else
            //{
            //    lstProduct = Sort<Product>(lstProduct, SortExp, SortDirection.Descending);
            //}
            gvProducts.DataSource = lstProduct;
            gvProducts.DataBind();

            //close the product object
            productService.Close();
        }

       

        #endregion

        #region -- Functions --
        
        /// <summary>
        /// Bind Data to GridView for Products 
        /// </summary>
        private void BindProductsGridView()
        {
            //Initializes object for WCF service
            ProductServiceClient productService = new ProductServiceClient();

            //Initializes object for List products
            IList<Product> lstProduct = new List<Product>();

            //Get Data from GetProducts method using WCF service
            lstProduct = productService.GetProducts();

            //Check if product record exist
            if (lstProduct.Count > 0)
            {
                //Set list value to grid view data source 
                gvProducts.DataSource = lstProduct;

                //Bind grid view control to display product list
                gvProducts.DataBind();
            }
            else
            {
                //if product record not exist then set grid view data source set to null
                gvProducts.DataSource = null;

                //Bind grid view control to display null list of category
                gvProducts.DataBind();
            }

            //close the product object
            productService.Close();
        }

        /// <summary>
        /// Bind Data to DropDownList of Category 
        /// </summary>
        private void BindCategoryDropDownList()
        {
            //Initializes object for WCF service
            ProductServiceClient productService = new ProductServiceClient();

            //Initializes object for List Category
            IList<Category> dsCategory = new List<Category>();

            //Get Data from GetCategory methoed
            dsCategory = productService.GetCategoryList();

            //Check if category record exist
            if (dsCategory.Count > 0)
            {
                //Set list value to category dropdownlist data source 
                ddlCategoryList.DataSource = dsCategory;
                
                //Set category dropdownlist data value field
                ddlCategoryList.DataValueField = "CategoryID";
                
                //Set category dropdownlist data text field
                ddlCategoryList.DataTextField = "CategoryName";
                
                //Bind category dropdownlist control to display category list
                ddlCategoryList.DataBind();
            }
            else
            {
                //if category list not exist then set grid view data source set to null
                ddlCategoryList.DataSource = null;
                
                //Bind category dropdownlist control to display null list of category
                ddlCategoryList.DataBind();
            }

            //close the product object
            productService.Close();
        }

        /// <summary>
        /// Clear/Reset controls 
        /// </summary>
        private void ClearControls()
        {
            //Set control values to emplty
            lblProductStatus.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductDescription.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtSearchProducts.Text = string.Empty;
        }

        /// <summary>
        /// get sorting order
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        private string GetSortingOrder(string column)
        {
            string sortDirection = "DESC";
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;

                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                    else
                    { sortDirection = "ASC"; }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;
            return sortDirection;
        }

        /// <summary>
        /// sort a list
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="list"></param>
        /// <param name="sortBy"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        /// 
        private IList<Product> Sort<T1>(IList<Product> lstProduct, string SortExp, SortDirection sortDirection)
        {
            PropertyInfo property = lstProduct.GetType().GetGenericArguments()[0].GetProperty(SortExp);
            if (sortDirection == SortDirection.Ascending)
            {
                return lstProduct.OrderBy(e => property.GetValue(e, null)).ToList<Product>();
            }
            else
            {
                return lstProduct.OrderByDescending(e => property.GetValue(e, null)).ToList<Product>();
            }
        }
        //public IList<Product> Sort<TKey>(List<Product> lstCategory, string sortBy, SortDirection direction)
        //{
        //    PropertyInfo property = lstCategory.GetType().GetGenericArguments()[0].GetProperty(sortBy);
        //    if (direction == SortDirection.Ascending)
        //    {
        //        return lstCategory.OrderBy(e => property.GetValue(e, null)).ToList<Product>();
        //    }
        //    else
        //    {
        //        return lstCategory.OrderByDescending(e => property.GetValue(e, null)).ToList<Product>();
        //    }
        //}



        #endregion

    }
}