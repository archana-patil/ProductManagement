/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Category Data Access Layer
* Date:28 Jan 2016
* Dependancy: AdminWelcome.aspx
*/

using System;
using ModelController.Prodoucts;
using System.Collections.Generic;
using ProductManagement.ProductServiceReference;

namespace ProductManagement
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        #region -- Variable Declaration --
        
        /// <summary>
        /// Initializes product object
        /// </summary>
        Product objProduct = new Product();
        
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //check page is post back
            if (!IsPostBack)
            {
                //Initializes object for WCF service
                ProductServiceClient productService = new ProductServiceClient();

                //Get product ID by querystring 
                objProduct.ProductID = Request.QueryString["ProductID"];
                
                //Check if product ID not null
                if (objProduct.ProductID != null)
                {
                    //Initalise object for Product List
                    IList<Product> lstProducts = new List<Product>();

                    //Get product details using WCF GetProductListDetails method 
                    lstProducts = productService.GetProductListDetails(objProduct);

                    //Check if product record exist and set control values
                    if (lstProducts.Count > 0)
                    {
                        lblProductName.Text = lstProducts[0].ProductName;
                        lblProductDescription.Text = lstProducts[0].ProductDescription;
                        lblProductPrice.Text = lstProducts[0].ProductPrice.ToString();
                        lblCategory.Text = lstProducts[0].CategoryName;
                        imgProduct.ImageUrl = lstProducts[0].FilePath;
                    }
                    else
                    {
                        lblProductName.Text = "";
                        lblProductDescription.Text = "";
                        lblProductPrice.Text = "";
                        lblCategory.Text = "";
                        imgProduct.ImageUrl = "";
                    }

                    //close the product object
                    productService.Close();
                }
            }
        }
    }
}