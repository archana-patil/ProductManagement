/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Category get set variables
* Date:28 Jan 2016
* Dependancy: ProductDal.cs, ProductMaster.aspx
*/
using System;
using System.Data;
using ModelController.Prodoucts;
using System.Collections.Generic;

namespace Controller.Products
{
    public class ProductBal
    {
        
        /// <summary>
        /// Insert Product Information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check product record inserted properly or not</returns>
        public Int32 InsertProductDetails(Product objProduct)
        {
            //Initializes object for product data access layer
            ProductDAL objProductDal = new ProductDAL();

            //return result after insert record of product
            return objProductDal.InsertProducts(objProduct);
        }

        /// <summary>
        /// Get Product Information
        /// </summary>
        /// <returns>Get total product list</returns>
        public List<Product> GetProductDetails()
        {
            //Initializes object for product data access layer
            ProductDAL objProductDal = new ProductDAL();

            //Initializes product list objext
            List<Product> lstProduct = new List<Product>();

            //Initializes dataset to get list of category from product data access layer
            DataSet dsProduct = objProductDal.GetProductDetails();

            //Check if dataset have records, if records exist in dataset then add these records into product list
            for (int index = 0; index < dsProduct.Tables[0].Rows.Count; index++)
            {
                lstProduct.Add(new Product
                {
                    ProductID = dsProduct.Tables[0].Rows[index]["ProductID"].ToString(),
                    ProductName = dsProduct.Tables[0].Rows[index]["ProductName"].ToString(),
                    ProductDescription = dsProduct.Tables[0].Rows[index]["ProductDescription"].ToString(),
                    ProductPrice = Convert.ToDecimal(dsProduct.Tables[0].Rows[index]["ProductPrice"].ToString()),
                    CategoryName = dsProduct.Tables[0].Rows[index]["CategoryName"].ToString(),
                    FilePath = dsProduct.Tables[0].Rows[index]["ProductImagePath"].ToString()
                });
            }

            //Set null value for product data access layer object
            objProductDal = null;

            //return product list 
            return lstProduct;
        }
        
        /// <summary>
        /// Search Product Information by product name
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>List of products by product name search</returns>
        public List<Product> SearchProductDetails(Product objProduct)
        {
            //Initializes object for product data access layer
            ProductDAL objProductDal = new ProductDAL();

            //Initializes product list objext
            List<Product> lstProduct = new List<Product>();

            //Initializes dataset to get list of category from product data access layer
            DataSet dsProduct = objProductDal.SearchProductInfo(objProduct);

            //Check if dataset have records, if records exist in dataset then add these records into product list
            for (int index = 0; index < dsProduct.Tables[0].Rows.Count; index++)
            {
                lstProduct.Add(new Product
                {
                    ProductID = dsProduct.Tables[0].Rows[index]["ProductID"].ToString(),
                    ProductName = dsProduct.Tables[0].Rows[index]["ProductName"].ToString(),
                    ProductDescription = dsProduct.Tables[0].Rows[index]["ProductDescription"].ToString(),
                    ProductPrice = Convert.ToDecimal(dsProduct.Tables[0].Rows[index]["ProductPrice"].ToString()),
                    CategoryID = dsProduct.Tables[0].Rows[index]["CategoryID"].ToString(),
                    CategoryName = dsProduct.Tables[0].Rows[index]["CategoryName"].ToString(),
                    FilePath = dsProduct.Tables[0].Rows[index]["ProductImagePath"].ToString()
                });
            }

            //Set null value for product data access layer object
            objProductDal = null;

            //return product list 
            return lstProduct;
        }
        
        /// <summary>
        /// Get products  details information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>List of products</returns>
        public List<Product> GetProductListDetails(Product objProduct)
        {
            //Initializes object for product data access layer
            ProductDAL objProductDal = new ProductDAL();

            //Initializes product list objext
            List<Product> lstProduct = new List<Product>();

            //Initializes dataset to get list of category from product data access layer
            DataSet dsProduct = objProductDal.GetProductListDetails(objProduct);

            //Check if dataset have records, if records exist in dataset then add these records into product list
            for (int index = 0; index < dsProduct.Tables[0].Rows.Count; index++)
            {
                lstProduct.Add(new Product
                {
                    ProductID = dsProduct.Tables[0].Rows[index]["ProductID"].ToString(),
                    ProductName = dsProduct.Tables[0].Rows[index]["ProductName"].ToString(),
                    ProductDescription = dsProduct.Tables[0].Rows[index]["ProductDescription"].ToString(),
                    ProductPrice = Convert.ToDecimal(dsProduct.Tables[0].Rows[index]["ProductPrice"].ToString()),
                    CategoryName = dsProduct.Tables[0].Rows[index]["CategoryName"].ToString(),
                    FilePath = dsProduct.Tables[0].Rows[index]["ProductImagePath"].ToString()
                });
            }

            //Set null value for product data access layer object
            objProductDal = null;

            //return product list 
            return lstProduct;
        }
        
        /// <summary>
        /// Delete Product Information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check product record deleted properly or not</returns>
        public Int32 DeleteProductDetails(Product objProduct)
        {
            //Initializes object for product data access layer
            ProductDAL objProductDal = new ProductDAL();

            //return result after delete record of product
            return objProductDal.DeleteProducts(objProduct);
        }

        /// <summary>
        /// Update Product Information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check product record update properly or not</returns>
        public Int32 UpdateProductDetails(Product objProduct)
        {
            //Initializes object for product data access layer
            ProductDAL objProductDal = new ProductDAL();

            //return result after delete record of product
            return objProductDal.UpdateProducts(objProduct);
        }
    
        /// <summary>
        /// Get product list for lazy loading implementation
        /// </summary>
        /// <param name="pageIndex">page index e.g. 1</param>
        /// <param name="pageSize">page size e.g. 10</param>
        /// <returns>list of products</returns>
        public List<Product> GetProductData(int pageIndex, int pageSize)
        {
            //Initializes object for product data access layer
            ProductDAL objProductDal = new ProductDAL();

            //Initializes product list objext
            List<Product> lstProduct = new List<Product>();

            //Initializes dataset to get list of category from product data access layer
            DataSet dsProduct = objProductDal.GetProductDataDal(pageIndex, pageSize);

            //Check if dataset have records, if records exist in dataset then add these records into product list
            for (int index = 0; index < dsProduct.Tables[0].Rows.Count; index++)
            {
                lstProduct.Add(new Product
                {
                    ProductID = dsProduct.Tables[0].Rows[index]["ProductID"].ToString(),
                    ProductName = dsProduct.Tables[0].Rows[index]["ProductName"].ToString(),
                    ProductDescription = dsProduct.Tables[0].Rows[index]["ProductDescription"].ToString(),
                    ProductPrice = Convert.ToDecimal(dsProduct.Tables[0].Rows[index]["ProductPrice"].ToString()),
                    CategoryID = dsProduct.Tables[0].Rows[index]["CategoryID"].ToString(),
                    CategoryName = dsProduct.Tables[0].Rows[index]["CategoryName"].ToString(),
                    FilePath = dsProduct.Tables[0].Rows[index]["ProductImagePath"].ToString()
                });
            }

            //Set null value for product data access layer object
            objProductDal = null;

            //return product list 
            return lstProduct;
        }
        
        /// <summary>
        /// Get total number of rows from products
        /// </summary>
        /// <returns>total number of rows from products</returns>
        public Int32 GetProductRowCount()
        {
            //Initializes object for product data access layer
            ProductDAL objProductDal = new ProductDAL();

            //Declare object to get result from product data access layer
            int resultRows = objProductDal.GetProductRows();

            //return products number of rows 
            return resultRows;
        }

    }
}
