/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:WCF Cervice to communicate between Model and Controller
* Date:03 Feb 2016
* Dependancy: CategoryDAL.cs, CategoryBAL.cs, Category.cs
*/

using System.Collections.Generic;
using ModelController.Login;
using Controller.Login;
using ModelController.Categories;
using Controller.Categories;
using ModelController.Prodoucts;
using Controller.Products;
using System.ServiceModel.Activation;

namespace ProductWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]  
    public class ProductService : IProductService
    {
        #region -- Variable Declaration --

        /// <summary>
        /// Initialises login object
        /// </summary>
        LoginBal objLoginBal = new LoginBal();

        /// <summary>
        /// Initialises category object
        /// </summary>
        CategoryBal objCategoryBal = new CategoryBal();

        /// <summary>
        /// Initialises product object
        /// </summary>
        ProductBal objProductBal = new ProductBal();
        
        #endregion

        #region -- Login Method --
        /// <summary>
        /// To get login user information for authentication
        /// </summary>
        /// <param name="objLogin"></param>
        /// <returns>List of login</returns>
        public List<Logins> GetUserList(Logins objLogin)
        {
            //Initialize object for Login list
            List<Logins> lstLogins = new List<Logins>();

            //Get the result from login business access lauer(LoginBal.cs)
            lstLogins = objLoginBal.GetUserList(objLogin);

            //Objects set to null value 
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
        public List<Category> GetCategoryList()
        {
            //Initialise category list object
            List<Category> lstCategory = new List<Category>();

            //Get list of category using category business access layer(CategoryBal.cs)
            lstCategory = objCategoryBal.GetCategoryDetail();

            //category object set to null
            objCategoryBal = null;

            //return list of categories
            return lstCategory;
        }

        /// <summary>
        /// Search category information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>List of categories</returns>
        public List<Category> SearchCategories(Category objCategory)
        {
            //Initialise category list object
            List<Category> lstCategory = new List<Category>();

            //Search and get list of category using category business access layer(CategoryBal.cs)
            lstCategory = objCategoryBal.SearchCategoryDetails(objCategory);

            //category object set to null
            objCategoryBal = null;

            //return list of categories
            return lstCategory;
        }

        /// <summary>
        /// Insert category information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>0 or 1 to check record inserted properly or not</returns>
        public int InsertCategory(Category objCategory)
        {
            //Insert category record using category business access layer and get return value(CategoryBal.cs)
            int retVal = objCategoryBal.InsertCategoryDetails(objCategory);

            //category object set to null
            objCategoryBal = null;

            //return value to verify inserted record
            return retVal;
        }

        /// <summary>
        /// Update category information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>0 or 1 to check record updated properly or not</returns>
        public int UpdateCategory(Category objCategory)
        {
            //Update category record using category business access layer and get return value(CategoryBal.cs)
            int retVal = objCategoryBal.UpdateCategoryDetails(objCategory);

            //category object set to null
            objCategoryBal = null;

            //return value to verify updated record
            return retVal;
        }

        /// <summary>
        /// Delete category information
        /// </summary>
        /// <param name="CategoryID">Category ID</param>
        /// <returns>0 or 1 to check record deleted properly or not</returns>
        public int DeleteCategory(Category objCategory)
        {
            //Delete category record using category business access layer and get return value(CategoryBal.cs)
            int retVal = objCategoryBal.DeleteCategoryDetails(objCategory);

            //category object set to null
            objCategoryBal = null;

            //return value to verify deleted record
            return retVal;
        }

        #endregion

        #region -- Product Methods --

        /// <summary>
        /// Get list of products 
        /// </summary>
        /// <returns>Product List</returns>
        public List<Product> GetProducts()
        {
            //Initialises product list object
            List<Product> lstProduct = new List<Product>();

            //Get list of products using product business access layer(productBal.cs)
            lstProduct = objProductBal.GetProductDetails();
            
            //Product list object set to null
            objProductBal = null;

            //return list of products
            return lstProduct;
        }

        /// <summary>
        /// Get total number of rows to count total pages on scrolling 
        /// </summary>
        /// <returns>total number of product rows</returns>
        public int GetRowCountService()
        {
            //Get list number of product rows count using product business access layer(productBal.cs)
            int rowCounter = objProductBal.GetProductRowCount();

            //Product list object set to null
            objProductBal = null;

            //return count row numbers
            return rowCounter;
        }

        /// <summary>
        /// Get product list of data for lazy loading
        /// </summary>
        /// <param name="pageIndex">Page Index e.g. 1</param>
        /// <param name="pageSize">Page Size e.g. 10</param>
        /// <returns>List of products</returns>
        
        public List<Product> GetProductData(int pageIndex, int pageSize)
        {
            //Initialises product list object
            List<Product> lstCategory = new List<Product>();

            //Get list of products using product business access layer(productBal.cs)
            lstCategory = objProductBal.GetProductData(pageIndex, pageSize);

            //Product list object set to null
            objProductBal = null;

            //return list of products
            return lstCategory;
        }

        /// <summary>
        /// Get product list details
        /// </summary>
        /// <param name="objProduct">Value of Product ID</param>
        /// <returns>List of products</returns>
        public List<Product> GetProductListDetails(Product objProduct)
        {
            //Initialises product list object
            List<Product> lstCategory = new List<Product>();

            //Get list of products using product business access layer(productBal.cs)
            lstCategory = objProductBal.GetProductListDetails(objProduct);

            //Product list object set to null
            objProductBal = null;

            //return list of products
            return lstCategory;
        }

        /// <summary>
        /// Search product information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>Product List</returns>
        public List<Product> SearchProducts(Product objProduct)
        {
            //Initialises product list object
            List<Product> lstProducts = new List<Product>();

            //Search and get list of matching products using product business access layer(productBal.cs)
            lstProducts = objProductBal.SearchProductDetails(objProduct);

            //Product list object set to null
            objProductBal = null;

            //return list of products
            return lstProducts;
        }

        /// <summary>
        /// Insert product information 
        /// </summary>
        /// <param name="objProduct">Product Object</param>
        /// <returns>0 or 1 to check record inserted properly or not</returns>
        public int InsertProduct(Product objProduct)
        {
            //Insert product record using product business access layer and get return value(ProductBal.cs)
            int retVal = objProductBal.InsertProductDetails(objProduct);
            
            //Product list object set to null
            objProductBal = null;
            
            //return value to verify inserted record
            return retVal;
        }

        /// <summary>
        /// Delete product information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check record deleted properly or not</returns>
        public int DeleteProduct(Product objProduct)
        {
            //Delete product record using product business access layer and get return value(ProductBal.cs)
            int retVal = objProductBal.DeleteProductDetails(objProduct);

            //Product list object set to null
            objProductBal = null;

            //return value to verify deleted record
            return retVal;
        }

        /// <summary>
        /// Update product information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check record updated properly or not</returns>
        public int UpdateProduct(Product objProduct)
        {
            //Update product record using product business access layer and get return value(ProductBal.cs)
            int retVal = objProductBal.UpdateProductDetails(objProduct);

            //Product list object set to null
            objProductBal = null;

            //return value to verify updated record
            return retVal;
        }

        #endregion
    }
}
