using System.Collections.Generic;
using System.ServiceModel;
using ModelController.Login;
using ModelController.Categories;
using ModelController.Prodoucts;
using System.ServiceModel.Web;

namespace ProductWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    
    public interface IProductService
    {
        #region -- Login Method --
        /// <summary>
        /// Get list of login user
        /// </summary>
        /// <param name="objLogin"></param>
        /// <returns></returns>
        [OperationContract]
        List<Logins> GetUserList(Logins objLogin);
        #endregion

        #region -- Category Methods --
        /// <summary>
        /// To get list of categories
        /// </summary>
        /// <returns>category list</returns>
        [OperationContract]
        List<Category> GetCategoryList();

        /// <summary>
        /// Search category information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>List of categories</returns>
        [OperationContract]
        List<Category> SearchCategories(Category objCategory);

        /// <summary>
        /// Insert category information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>0 or 1 to check record inserted properly or not</returns>
        [OperationContract]
        int InsertCategory(Category objCategory);

        /// <summary>
        /// Update category information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>0 or 1 to check record updated properly or not</returns>
        [OperationContract]
        int UpdateCategory(Category objCategory);

        /// <summary>
        /// Delete category information
        /// </summary>
        /// <param name="CategoryID">Category ID</param>
        /// <returns>0 or 1 to check record deleted properly or not</returns>
        [OperationContract]
        int DeleteCategory(Category objCategory);
        #endregion

        #region -- Product Methods --
        
        /// <summary>
        /// Get list of products 
        /// </summary>
        /// <returns>Product List</returns>
        [OperationContract]
        List<Product> GetProducts();

        /// <summary>
        /// Get total number of rows to count total pages on scrolling 
        /// </summary>
        /// <returns>total number of product rows</returns>
        [OperationContract]
        int GetRowCountService();

        /// <summary>
        /// Get product list of data for lazy loading
        /// </summary>
        /// <param name="pageIndex">Page Index e.g. 1</param>
        /// <param name="pageSize">Page Size e.g. 10</param>
        /// <returns>List of products</returns>

        [OperationContract]
        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        List<Product> GetProductData(int pageIndex, int pageSize);

        /// <summary>
        /// Get product list details
        /// </summary>
        /// <param name="objProduct">Value of Product ID</param>
        /// <returns>List of products</returns>
        [OperationContract]
        List<Product> GetProductListDetails(Product objProduct);

        /// <summary>
        /// Search product information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>Product List</returns>
        [OperationContract]
        List<Product> SearchProducts(Product objProduct);

        /// <summary>
        /// Insert product information 
        /// </summary>
        /// <param name="objProduct">Product Object</param>
        /// <returns>0 or 1 to check record inserted properly or not</returns>
        [OperationContract]
        int InsertProduct(Product objProduct);

        /// <summary>
        /// Delete product information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check record deleted properly or not</returns>
        [OperationContract]
        int DeleteProduct(Product objProduct);

        /// <summary>
        /// Update product information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check record updated properly or not</returns>
        [OperationContract]
        int UpdateProduct(Product objProduct);
        #endregion
    }
}
