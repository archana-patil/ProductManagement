/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Category Data Access Layer
* Date:28 Jan 2016
* Dependancy: ProductBal.cs, Product.cs
*/

using System;
using System.Web.UI;
using ModelController.Prodoucts;
using System.Collections.Generic;
using ProductManagement.ProductServiceReference;
using System.Web.Services;

namespace ProductManagement
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region -- Variable Declaration --

        /// <summary>
        /// Initializes product object
        /// </summary>
        Product objProduct = new Product();

        #endregion

        /// <summary>
        /// Get product list and bind to repeater control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //check page is post back
            if (!Page.IsPostBack)
            {
                //Call a method to bind records of category list to gridview 
                BindProductSummaryGridView();

                //Call a method to get total count of product rows
                GetRowCount();
            }
        }

        /// <summary>
        /// Get Products Row Count
        /// </summary>
        private void GetRowCount()
        {
            //Initializes object for WCF service
            ProductServiceClient productService = new ProductServiceClient();

            //Get total number of rows count for products
            hdfProductRowCount.Value = productService.GetRowCountService().ToString();

            //close the product object
            productService.Close();
        }
        
        /// <summary>
        /// Bind Data to GridView for Products Summary
        /// </summary>
        private void BindProductSummaryGridView()
        {
            //Initializes object for WCF service
            ProductServiceClient productService = new ProductServiceClient();

            //Initializes object for product list
            IList<Product> lstProduct = new List<Product>();

            //Get data from GetProductData method and set to the product object list
            lstProduct = productService.GetProductData(1, Convert.ToInt16(hdfProductPageSize.Value));

            //Check if category record exist
            if (lstProduct.Count > 0)
            {
                //Set list value to repeater data source 
                rptProducts.DataSource = lstProduct;

                //Bind grid view control to display product list
                rptProducts.DataBind();
            }
            else
            {
                //if product record not exist then set repater data source set to null
                rptProducts.DataSource = null;

                //Bind grid view control to display null list of product
                rptProducts.DataBind();
            }

            //close the product object
            productService.Close();
        }
    }
}