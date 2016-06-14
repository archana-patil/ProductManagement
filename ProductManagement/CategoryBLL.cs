using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement
{
    public class CategoryBLL
    {
        #region Insert Category Information
        /// <summary>
        /// Insert Category
        /// </summary>
        /// <param name="objUserBEL"></param>
        /// <returns></returns>
        public string InsertUserDetails(CategoryBEL objCategory)
        {
        CategoryDAL objCategoryDAL = new CategoryDAL();
        try
        {
            return objCategoryDAL.InsertCategory(objCategory);
        }
        catch (Exception ex)
        {
        throw ex;
        }
        finally
        {
            objCategoryDAL = null;
        }
        }
        #endregion
        
        
    }
}