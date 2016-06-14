/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Category Data Access Layer
* Date:25 Jan 2016
* Dependancy: AdminWelcome.aspx
*/

using System;
using System.Data.SqlClient;
using System.Data;

namespace ModelController.Categories
{
    public class CategoryDAL
    {
        
        /// <summary>
        /// Get SQL Connection string from web.config
        /// </summary>
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProductMgmtConnString"].ConnectionString;

        /// <summary>
        /// Insert Category Information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>0 or 1 to check category status inserted or not</returns>
        public Int32 InsertCategory(Category objBELCategory)
        {
            //Variable declaration
            int result;

            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("InsertCategoryInfo", con);

                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.AddWithValue("@CategoryName", objBELCategory.CategoryName);

                //Check the connection statte if it closed then open the connection for execution
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                //Execute the sql command 
                result = cmd.ExecuteNonQuery();

                //Dispose command object
                cmd.Dispose();
                
                //Set if result is greater than zero means error in query execution  
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                //Throw an Exception 
                throw ex;
            }
            finally
            {
                //Finally check if sql connection object is not closed then colse the connection
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }          
            }
        }

        /// <summary>
        /// Get Category Information
        /// </summary>
        /// <returns>List of category</returns>
        public DataSet GetCategory()
        {
            //Initializes a dataset
            DataSet dsCategory = new DataSet();
            
            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("GetCategoryDetails", con);

                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Initializes a new instance of the SqlDataAdapter class with the specified SqlCommand as the SelectCommand property.
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                //Fill dataset using command execution 
                adp.Fill(dsCategory);

                //Dispose command object
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                //Throw an exception
                throw ex;
            }
            finally
            {
                //Dispose dataset object
                dsCategory.Dispose();
            }
            
            //return login user list
            return dsCategory;
        }

        /// <summary>
        /// Delete Category Information
        /// </summary>
        /// <param name="objCategory">category object</param>
        /// <returns>0 or 1 to check category status deleted or not</returns>
        public Int32 DeleteCategory(Category objBELCategory)
        {
            //Variable declaration
            int result;

            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);

            //Check weather these category is exist in product list, if it exist then return 1.
            if (checkIfExist(objBELCategory))
            {
                return 1;
            }
            else
            {
                try
                {
                    //Create a command object identifying the stored procedure
                    SqlCommand cmd = new SqlCommand("DeleteCategoryInfo", con);
                    
                    //Set the command object so it knows to execute a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Add parameter to command, which will be passed to the stored procedure
                    cmd.Parameters.AddWithValue("@CategoryID", objBELCategory.CategoryID);

                    //Check the connection statte if it closed then open the connection for execution
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    //Execute the sql command 
                    result = cmd.ExecuteNonQuery();

                    //Dispose command object
                    cmd.Dispose();

                    //Set if result is greater than zero means error in query execution  
                    if (result > 0)
                    {
                        return result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    //Throw an Exception 
                    throw ex;
                }
                finally
                {
                    //Finally check if sql connection object is not closed then colse the connection
                    if (con.State != ConnectionState.Closed)
                    {
                        con.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Check if category is exist 
        /// </summary>
        /// <param name="objBELCategory"></param>
        /// <returns>true or false</returns>
        private bool checkIfExist(Category objBELCategory)
        {
            //Variable declaration   
            int result;

            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("CheckCategoryIfExist", con);

                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameter to command, which will be //Set the command object so it knows to execute a stored procedure passed to the stored procedure
                cmd.Parameters.AddWithValue("@CategoryID", objBELCategory.CategoryID);

                //Check the connection statte if it closed then open the connection for execution
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //Execute the sql command 
                result = Convert.ToInt16(cmd.ExecuteScalar());

                //Dispose command object
                cmd.Dispose();

                //Set if result is greater than zero means error in query execution  
                if (result == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //Throw exception
                throw ex;
            }
            finally
            {
                //Finally check if sql connection object is not closed then colse the connection
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Update Category Information
        /// </summary>
        /// <param name="objCategory">category object</param>
        /// <returns>0 or 1 to check category status updated or not</returns>
        public Int32 UpdateCategory(Category objBELCategory)
        {
            //Variable declaration
            int result;

            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("UpdateCategoryInfo", con);

                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameter to command, which will be passed to the stored procedure

                cmd.Parameters.AddWithValue("@CategoryID", objBELCategory.CategoryID);
                cmd.Parameters.AddWithValue("@CategoryName", objBELCategory.CategoryName);

                //Check the connection statte if it closed then open the connection for execution
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                //Execute the sql command 
                result = cmd.ExecuteNonQuery();
                
                //Dispose command object
                cmd.Dispose();
                
                //Set if result is greater than zero means error in query execution  
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                //Throw an Exception 
                throw ex;
            }
            finally
            {
                //Finally check if sql connection object is not closed then colse the connection
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        /// <summary>
        /// Search Category Information
        /// </summary>
        /// <param name="objCategory">Category Object</param>
        /// <returns>List of Category</returns>
        public DataSet SearchCategoryInfo(Category objCategory)
        {
            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            
            //Initializes a dataset
            DataSet dsProducts = new DataSet();
            
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("SearchCategoryDetails", con);
                
                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                
                //Add parameter to command, which will be //Set the command object so it knows to execute a stored procedure passed to the stored procedure
                cmd.Parameters.AddWithValue("@CategoryName", objCategory.CategoryName);
                
                //Initializes a new instance of the SqlDataAdapter class with the specified SqlCommand as the SelectCommand property.
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                //Fill dataset using command execution 
                adp.Fill(dsProducts);
                
                //Dispose command object
                cmd.Dispose();
            }
            catch(Exception ex)
            {
                //Throw an exception
                throw ex;
            }
            finally
            {
                //Dispose dataset object
                dsProducts.Dispose();
            }
            //return category list
            return dsProducts;
        }

    }
}
