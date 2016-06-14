/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Create a webservice for product management to interact between UI and controller
* Date:29 Jan 2016
* Dependancy: Logins.cs, LoginBal.cs, Category.cs, CategoryBal.cs, Product.cs, ProductBal.cs
*/

using System.Collections.Generic;
using System.Web.Services;
using Controller.Login;
using ModelController.Login;
using ModelController.Categories;
using Controller.Categories;
using ModelController.Prodoucts;
using Controller.Products;

namespace ProductManagement
{
    /// <summary>
    /// Summary description for ProductWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProductWebService : System.Web.Services.WebService
    {
        #region -- Variable Declaration --
        LoginBal objLoginBal = new LoginBal();
        Logins objLogin = new Logins();
        
        Category objCategory = new Category();
        CategoryBal objCategoryBal = new CategoryBal();

        Product objProduct = new Product();
        ProductBal objProductBal = new ProductBal();
        #endregion

        #region -- Login Method --
        /// <summary>
        /// To get login user information for authentication
        /// </summary>
        /// <param name="UserName">User Name</param>
        /// <param name="Password">User Password</param>
        /// <returns>List of login</returns>
        [WebMethod]
        public List<Logins> GetUserList(Logins objLogin)
        {
            //Initialize object for Login list
            List<Logins> lstLogins = new List<Logins>();

            //Get the result from login business access lauer
            lstLogins = objLoginBal.GetUserList(objLogin);

            //Objects set to null value 
            objLogin = null;
            objLoginBal = null;
            
            //return login users list
            return lstLogins;
        }
        #endregion

        #region -- Category Methods --
        
        /// <summary>
        /// To get list of categories
        /// </summary>
        /// <returns>category list</returns>
        [WebMethod]
        public List<Category> GetCategoryList()
        {
            List<Category> lstCategory = new List<Category>();

            lstCategory = objCategoryBal.GetCategoryDetail();

            objLogin = null;

            return lstCategory;
        }

        /// <summary>
        /// Insert category information
        /// </summary>
        /// <param name="CategoryName">Category Name</param>
        /// <returns>0 or 1 to check record inserted properly or not</returns>
        [WebMethod]
        public int InsertCategory(string CategoryName)
        {
            objCategory.CategoryName = CategoryName;
            
            int retVal = objCategoryBal.InsertCategoryDetails(objCategory);
            
            objCategory = null;
            objCategoryBal = null; 
            
            return retVal;
        }

        /// <summary>
        /// Delete category information
        /// </summary>
        /// <param name="CategoryID">Category ID</param>
        /// <returns>0 or 1 to check record deleted properly or not</returns>
        [WebMethod]
        public int DeleteCategory(string CategoryID)
        {
            objCategory.CategoryID = CategoryID;
            
            int retVal = objCategoryBal.DeleteCategoryDetails(objCategory);
            
            objCategory = null;
            objCategoryBal = null; 
            
            return retVal;
        }

        /// <summary>
        /// Update category information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>0 or 1 to check record updated properly or not</returns>
        [WebMethod]
        public int UpdateCategory(Category objCategory)
        {
            
            int retVal = objCategoryBal.UpdateCategoryDetails(objCategory);
            
            objCategory = null;
            objCategoryBal = null; 
            
            return retVal;
        }

        /// <summary>
        /// Search category information
        /// </summary>
        /// <param name="CategoryName">Category Name</param>
        /// <returns>List of categories</returns>
        [WebMethod]
        public List<Category> SearchCategories(string CategoryName)
        {
            List<Category> lstCategory = new List<Category>();
            
            objCategory.CategoryName = CategoryName;

            lstCategory = objCategoryBal.SearchCategoryDetails(objCategory);
            
            objCategory = null;
            objCategoryBal = null;

            return lstCategory;
        }
        #endregion

        #region -- Product Methods --
        
        /// <summary>
        /// Get list of products 
        /// </summary>
        /// <returns>Product List</returns>
        [WebMethod]
        public List<Product> GetProducts()
        {
            List<Product> lstProduct = new List<Product>();

            lstProduct = objProductBal.GetProductDetails();

            objProductBal = null;

            return lstProduct;
        }

        /// <summary>
        /// Insert product information 
        /// </summary>
        /// <param name="objProduct">Product Object</param>
        /// <returns>0 or 1 to check record inserted properly or not</returns>
        [WebMethod]
        public int InsertProduct(Product objProduct)
        {
            int retVal = objProductBal.InsertProductDetails(objProduct);

            objProduct = null;
            objProduct = null;

            return retVal;
        }

        /// <summary>
        /// Delete product information
        /// </summary>
        /// <param name="ProductID"></param>
        /// <returns>0 or 1 to check record deleted properly or not</returns>
        [WebMethod]
        public int DeleteProduct(string ProductID)
        {
            objProduct.ProductID = ProductID;

            int retVal = objProductBal.DeleteProductDetails(objProduct);

            objProduct = null;
            objProductBal = null;

            return retVal;
        }

        /// <summary>
        /// Update product information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check record updated properly or not</returns>
        [WebMethod]
        public int UpdateProduct(Product objProduct)
        {

            int retVal = objProductBal.UpdateProductDetails(objProduct);

            objProduct = null;
            objProductBal = null;

            return retVal;
        }

        /// <summary>
        /// Search product information
        /// </summary>
        /// <param name="ProductName">Product Name</param>
        /// <returns>Product List</returns>
        [WebMethod]
        public List<Product> SearchProducts(string ProductName)
        {
            List<Product> lstProducts = new List<Product>();

            objProduct.ProductName = ProductName;

            lstProducts = objProductBal.SearchProductDetails(objProduct);

            objProduct = null;
            objProductBal = null;

            return lstProducts;
        }

        /// <summary>
        /// Get product list details
        /// </summary>
        /// <param name="objProduct">Value of Product ID</param>
        /// <returns>List of products</returns>
        [WebMethod]
        public List<Product> GetProductListDetails(Product objProduct)
        {
            List<Product> lstCategory = new List<Product>();

            lstCategory = objProductBal.GetProductListDetails(objProduct);

            objLogin = null;

            return lstCategory;
        }

        /// <summary>
        /// Get product list of data for lazy loading
        /// </summary>
        /// <param name="pageIndex">Page Index e.g. 1</param>
        /// <param name="pageSize">Page Size e.g. 10</param>
        /// <returns>List of products</returns>
        [WebMethod]
        public List<Product> GetProductData(int pageIndex, int pageSize)
        {
            List<Product> lstCategory = new List<Product>();

            lstCategory = objProductBal.GetProductData(pageIndex, pageSize);
            objLogin = null;

            return lstCategory;
        }

        /// <summary>
        /// Get total number of rows to count total pages on scrolling 
        /// </summary>
        /// <returns>total number of product rows</returns>
        [WebMethod]
        public int GetRowCountService() 
        {
            int rowCounter = objProductBal.GetProductRowCount();

            return rowCounter;
        }

        #endregion
    }
}
