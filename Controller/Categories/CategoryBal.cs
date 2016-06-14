/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Category get set variables
* Date:28 Jan 2016
* Dependancy: CategoryDal.cs, Adminwelcome.aspx
*/

using System;
using ModelController.Categories;
using System.Data;
using System.Collections.Generic;

namespace Controller.Categories
{
    public class CategoryBal
    {
        /// <summary>
        /// Insert Category Information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>0 or 1 to check category status inserted or not</returns>
        public Int32 InsertCategoryDetails(Category objCategory)
        {
            //Initializes object for category data access layer
            CategoryDAL objCategoryDal = new CategoryDAL();

            //return result after insert record of category
            return objCategoryDal.InsertCategory(objCategory);
        }

        /// <summary>
        /// Get Category Information
        /// </summary>
        /// <returns>List of category</returns>
        public List<Category> GetCategoryDetail()
        {
            //Initializes object for category data access layer
            CategoryDAL objCategoryDal = new CategoryDAL();

            //Initializes category list objext
            List<Category> lstCategory = new List<Category>();

            //Initializes dataset to get list of category from category data access layer
            DataSet dsCategory = objCategoryDal.GetCategory();

            //Check if dataset have records, if records exist in dataset then add these records into category list
            for (int index = 0; index < dsCategory.Tables[0].Rows.Count; index++)
            {
                lstCategory.Add(new Category
                {
                    CategoryID = dsCategory.Tables[0].Rows[index]["CategoryID"].ToString(),
                    CategoryName = dsCategory.Tables[0].Rows[index]["CategoryName"].ToString()
                });
            }

            //Set null value for category data access layer object
            objCategoryDal = null;

            //return category list 
            return lstCategory;
        }
        
        /// <summary>
        /// Search Category Information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>List of Category</returns>
        public List<Category> SearchCategoryDetails(Category objCategory)
        {
            //Initializes object for category data access layer
            CategoryDAL objCategoryDal = new CategoryDAL();

            //Initializes category list objext
            List<Category> lstCategory = new List<Category>();

            //Initializes dataset to get list of category from category data access layer
            DataSet dsCategory = objCategoryDal.SearchCategoryInfo(objCategory);

            //Check if dataset have records, if records exist in dataset then add these records into category list
            for (int index = 0; index < dsCategory.Tables[0].Rows.Count; index++)
            {
                lstCategory.Add(new Category
                {
                    CategoryID = dsCategory.Tables[0].Rows[index]["CategoryID"].ToString(),
                    CategoryName = dsCategory.Tables[0].Rows[index]["CategoryName"].ToString()
                });
            }

            //Set null value for category data access layer object
            objCategoryDal = null;

            //return category list 
            return lstCategory;
        }
        
        /// <summary>
        /// Delete Category Information
        /// </summary>
        /// <param name="objCategory">category object</param>
        /// <returns>0 or 1 to check category status deleted or not</returns>
        public Int32 DeleteCategoryDetails(Category objCategory)
        {
            //Initializes object for category data access layer
            CategoryDAL objCategoryDal = new CategoryDAL();

            //return result after delete record of category
            return objCategoryDal.DeleteCategory(objCategory);
        }

        /// <summary>
        /// Update Category Information
        /// </summary>
        /// <param name="objCategory">category object</param>
        /// <returns>0 or 1 to check category status updated or not</returns>
        public Int32 UpdateCategoryDetails(Category objCategory)
        {
            //Initializes object for category data access layer
            CategoryDAL objCategoryDal = new CategoryDAL();

            //return result after update record of category
            return objCategoryDal.UpdateCategory(objCategory);
        }
    }
}
