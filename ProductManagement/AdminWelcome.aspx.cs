/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:User Interface Layer of Category
* Date:25 Jan 2016
* Dependancy: CategoryDAL.cs, CategoryBAL.cs, Category.cs
*/

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using ModelController.Categories;
using System.Reflection;
using System.Linq;
using ProductManagement.ProductServiceReference;

namespace ProductManagement
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        #region -- Variable Declaration --
        
        /// <summary>
        /// Initializes category object
        /// </summary>
        Category objCategory = new Category();
        
        #endregion

        #region -- Events --
        /// <summary>
        /// call page load method to bind category list to grid view control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //check page is post back
            if (!Page.IsPostBack)
            {
                //For authentication check session have value 
                if (Session["UserLogin"]!=null)
                {
                    //Call a method to clear all control on this page
                    ClearControls();

                    //Call a method to bind records of category list to gridview 
                    BindCategoryRecordsGridView();
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
        /// Insert Category Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInsertCategory_Click(object sender, EventArgs e)
        {
            //set category object values
            objCategory.CategoryName = txtCategory.Text;

            //Initializes object for WCF service
            ProductServiceClient categoryService = new ProductServiceClient();

            //Insert category record using wcf service method
            int retVal = categoryService.InsertCategory(objCategory);
            
            //Check return value to display proper message after successful insert
            if (retVal==0)
            {
                //Call a method to clear all control on this page
                ClearControls();

                //Call a method to bind records of category list to gridview 
                BindCategoryRecordsGridView();

                //Set label text value and color
                lblStatus.Text = "Category inserted successfully";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                //Set label text value and color
                lblStatus.Text = "Category couldn't be inserted";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            
            //close the product object
            categoryService.Close();
        }
        
        /// <summary>
        /// Delete Category Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //set values for category object 
            objCategory.CategoryID = (gvCategory.Rows[e.RowIndex].FindControl("lblCategoryID") as Label).Text;

            //Initializes object for WCF service
            ProductServiceClient categoryService = new ProductServiceClient();
            
            //Delete category record using wcf service method
            int retVal = categoryService.DeleteCategory(objCategory);

            //Check return value to display proper message after successfully deleted 
            if (retVal == 0)
            {
                //Call a method to clear all control on this page
                ClearControls();

                //Call a method to bind records of category list to gridview 
                BindCategoryRecordsGridView();

                //Set label text value and color
                lblStatus.Text = "Category deleted successfully";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else if (retVal == 1)
            {
                //Call a method to clear all control on this page
                ClearControls();

                //Call a method to bind records of category list to gridview 
                BindCategoryRecordsGridView();

                //Set label text value and color
                lblStatus.Text = "Category couldn't be deleted, this category exist in products";
                lblStatus.ForeColor = System.Drawing.Color.Orange;
            }
            else
            {
                //Set label text value and color
                lblStatus.Text = "Category couldn't be deleted";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            //close the product object
            categoryService.Close();
        }

        /// <summary>
        /// Edit Category Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Set edit index of selected row on edit option
            gvCategory.EditIndex = e.NewEditIndex;

            //Call to bind record of category to display in edited mode
            BindCategoryRecordsGridView();
        }

        /// <summary>
        /// Update Category Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //set values for category object 
            objCategory.CategoryID = (gvCategory.Rows[e.RowIndex].FindControl("lblCategoryID") as Label).Text;
            objCategory.CategoryName = ((TextBox)(gvCategory.Rows[e.RowIndex].FindControl("txtCategoryNameEdit"))).Text.Trim();

            //Initializes object for WCF service
            ProductServiceClient categoryService = new ProductServiceClient();

            //Update category record using wcf service method
            int retVal = categoryService.UpdateCategory(objCategory);

            //Check return value to display proper message after successfully deleted 
            if (retVal == 0)
            {
                //Call a method to clear all control on this page
                ClearControls();

                //Set edit index to -1
                gvCategory.EditIndex = -1;

                //Call a method to bind category list to gridview 
                BindCategoryRecordsGridView();

                //Set label text value and color
                lblStatus.Text = "Category information updated successfully";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                //Set label text value and color
                lblStatus.Text = "Category couldn't be updated";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }

            //close the product object
            categoryService.Close();
        }

        /// <summary>
        /// Cancel Edit Category Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Set edit index of grid view while user will cancel the edit record
            gvCategory.EditIndex = -1;

            //Call to bind method to display category list
            BindCategoryRecordsGridView();
        }

        /// <summary>
        /// Paging in GridView 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Set page index of grid view while user will click on page numbers
            gvCategory.PageIndex = e.NewPageIndex;

            //Call bind method to display category list on next, previous and selected page
            BindCategoryRecordsGridView();
        }

        /// <summary>
        /// Search Category Information 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearchCategory_Click(object sender, EventArgs e)
        {
            //set values for category object
            objCategory.CategoryName = txtSearchCategory.Text;

            //Initializes object for WCF service
            ProductServiceClient categoryService = new ProductServiceClient();

            //Initialises category list object 
            IList<Category> lstCategory = new List<Category>();

            //Get Data from search method of wcf service 
            lstCategory = categoryService.SearchCategories(objCategory);

            //Check if category record exist
            if (lstCategory.Count > 0)
            {
                //Set category list value to grid view data source 
                gvCategory.DataSource = lstCategory;

                //Bind grid view control to display category list
                gvCategory.DataBind();
            }
            else
            {
                //if category record not exist then set grid view data source to null
                gvCategory.DataSource = null;

                //Bind grid view control to display null list of category
                gvCategory.DataBind();
            }
            
            //Call a method to clear all control on this page
            ClearControls();

            //close the product object
            categoryService.Close();
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
        
        /// <summary>
        /// grid view sorting 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Initializes object for WCF service
            ProductServiceClient categoryService = new ProductServiceClient();

            //Initialises category list object 
            IList<Category> lstCategory = new List<Category>();

            //Get category list using wcf service method
            lstCategory = categoryService.GetCategoryList();

            string Sortdir = GetSortingOrder(e.SortExpression);
            string SortExp = e.SortExpression;
            
            //if (Sortdir == "ASC")
            //{
            //    lstCategory = Sort<Category>(lstCategory, SortExp, SortDirection.Ascending);
            //}
            //else
            //{
            //    lstCategory = Sort<Category>(lstCategory, SortExp, SortDirection.Descending);
            //}
            gvCategory.DataSource = lstCategory;
            gvCategory.DataBind();

            //close the product object
            categoryService.Close();
        }

        #endregion

        #region -- Functions --

        /// <summary>
        /// Clear/Reset controls 
        /// </summary>
        private void ClearControls()
        {
            //Set control values to emplty
            txtCategory.Text = string.Empty;
            lblStatus.Text = string.Empty;
            txtCategory.Focus();
            txtSearchCategory.Text = string.Empty;
        }

        /// <summary>
        /// Bind Data to GridView for Category
        /// </summary>
        private void BindCategoryRecordsGridView()
        {
            //Initializes object for WCF service
            ProductServiceClient categoryService = new ProductServiceClient();
            
            //Initializes object for List Category
            IList<Category> lstCategory = new List<Category>();

            //Get Data from GetCategory method using WCF service
            lstCategory = categoryService.GetCategoryList();

            //Check if category record exist
            if (lstCategory.Count > 0)
            {
                //Set list value to grid view data source 
                gvCategory.DataSource = lstCategory;

                //Bind grid view control to display category list
                gvCategory.DataBind();
            }
            else
            {
                //if category record not exist then set grid view data source set to null
                gvCategory.DataSource = null;

                //Bind grid view control to display null list of category
                gvCategory.DataBind();
            }

            //close the product object
            categoryService.Close();
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
        public List<Category> Sort<TKey>(List<Category> lstCategory, string sortBy, SortDirection direction)
        {
            PropertyInfo property = lstCategory.GetType().GetGenericArguments()[0].GetProperty(sortBy);
            if (direction == SortDirection.Ascending)
            {
                return lstCategory.OrderBy(e => property.GetValue(e, null)).ToList<Category>();
            }
            else
            {
                return lstCategory.OrderByDescending(e => property.GetValue(e, null)).ToList<Category>();
            }
        }

        #endregion
    }
}