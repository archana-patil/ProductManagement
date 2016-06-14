using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ProductManagement
{
    public class CategoryDAL
    {
        //SQL Connection string
        string ConnectionString = ConfigurationManager.ConnectionStrings["LocalConnection"].ToString();

        #region Insert Category Details
        /// <summary>
        /// Insert Job Details
        /// </summary>
        /// <param name="objBELJobs"></param>
        /// <returns></returns>
        public string InsertCategory(CategoryBEL objBELCategory)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertCategoryInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@CategoryName", objBELCategory.CategoryName);
                cmd.ExecuteNonQuery();
                con.Close();
                return "Category Inserted Successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }
        #endregion
    }
}