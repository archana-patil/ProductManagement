/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Category Data Access Layer
* Date:28 Jan 2016
* Dependancy: AdminWelcome.aspx, ProductBal.cs
*/

using System;
using System.Data;
using System.Data.SqlClient;

namespace ModelController.Prodoucts
{
    public class ProductDAL
    {
        /// <summary>
        /// Get Sql Connection String from web.config file
        /// </summary>
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProductMgmtConnString"].ConnectionString;

        /// <summary>
        /// Insert Product Details
        /// </summary>
        /// <param name="objProductBel">Product object</param>
        /// <returns>0 or 1 to check product record inserted properly or not</returns>
        public Int32 InsertProducts(Product objProductBel)
        {
            //Variable declaration
            int result;

            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("InsertProductInfo", con);

                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters to command, which will be //Set the command object so it knows to execute a stored procedure passed to the stored procedure
                cmd.Parameters.AddWithValue("@ProductName", objProductBel.ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", objProductBel.ProductDescription);
                cmd.Parameters.AddWithValue("@ProductPrice", objProductBel.ProductPrice);
                cmd.Parameters.AddWithValue("@CategoryID", objProductBel.CategoryID);
                cmd.Parameters.AddWithValue("@ProductFilePath", objProductBel.FilePath);
                
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
                if (result >0)
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
        /// Get Product Information
        /// </summary>
        /// <returns>Get total product list</returns>
        public DataSet GetProductDetails()
        {
            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            
            //Initializes a dataset
            DataSet dsProducts = new DataSet();
            
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("GetProductDetails", con);
                
                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                
                //Initializes a new instance of the SqlDataAdapter class with the specified SqlCommand as the SelectCommand property.
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                //Fill dataset using command execution 
                adp.Fill(dsProducts);
                
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
                dsProducts.Dispose();
            }
            //return product list
            return dsProducts;
        }

        /// <summary>
        /// Search Product Information by product name
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>List of products by product name search</returns>
        public DataSet SearchProductInfo(Product objProduct)
        {
            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            
            //Initializes a dataset
            DataSet dsProducts = new DataSet();
            
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("SearchProductDetails", con);
                
                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.AddWithValue("@ProductName", objProduct.ProductName);

                //Initializes a new instance of the SqlDataAdapter class with the specified SqlCommand as the SelectCommand property.
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                //Fill dataset using command execution 
                adp.Fill(dsProducts);

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
                dsProducts.Dispose();
            }

            //return product list
            return dsProducts;
        }

        /// <summary>
        /// Get products  details information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>List of products</returns>
        public DataSet GetProductListDetails(Product objProduct)
        {
            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            
            //Initializes a dataset
            DataSet dsProducts = new DataSet();
            
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("GetProductDetailsInfo", con);
                
                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                
                //Add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.AddWithValue("@ProductID", objProduct.ProductID);
                
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
            return dsProducts;
        }

        /// <summary>
        /// Get product list for lazy loading implementation
        /// </summary>
        /// <param name="pageIndex">page index e.g. 1</param>
        /// <param name="pageSize">page size e.g. 10</param>
        /// <returns>list of products</returns>
        public DataSet GetProductDataDal(int pageIndex, int pageSize)
        {
            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            
            //Initializes a dataset
            DataSet dsProducts = new DataSet();
            
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("Getproductspagewise", con);
                
                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                
                //Add parameters to command, which will be passed to the stored procedure
                cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);
                cmd.Parameters.Add("@PageCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                
                //Initializes a new instance of the SqlDataAdapter class with the specified SqlCommand as the SelectCommand property.
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                
                //Fill dataset using command execution 
                adp.Fill(dsProducts, "Products");

                DataTable dt = new DataTable("PageCount");
                dt.Columns.Add("PageCount");
                dt.Rows.Add();
                dt.Rows[0][0] = cmd.Parameters["@PageCount"].Value;
                dsProducts.Tables.Add(dt);

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

            //return product list
            return dsProducts;
        }

        /// <summary>
        /// Get total number of rows from products
        /// </summary>
        /// <returns>total number of rows from products</returns>
        public Int32 GetProductRows()
        {
            //Variable declaration
            int result;

            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("GetProductRows", con);
                
                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Check the connection statte if it closed then open the connection for execution
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //Execute the sql command 
                result = Convert.ToInt16(cmd.ExecuteScalar());

                //Dispose command object
                cmd.Dispose();
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
            return result;
        }

        /// <summary>
        /// Delete Product Information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check product record deleted properly or not</returns>
        public Int32 DeleteProducts(Product objProduct)
        {
            //Variable declaration
            int result;

            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("DeleteProductInfo", con);

                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;
                
                //Add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.AddWithValue("@ProductID", objProduct.ProductID);

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
        /// Update Product Information
        /// </summary>
        /// <param name="objProduct"></param>
        /// <returns>0 or 1 to check product record update properly or not</returns>
        public Int32 UpdateProducts(Product objProduct)
        {
            //Variable declaration
            int result;
            
            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);
            
            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("UpdateProductInfo", con);
                
                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters to command, which will be passed to the stored procedure
                cmd.Parameters.AddWithValue("@ProductID", objProduct.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", objProduct.ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", objProduct.ProductDescription);
                cmd.Parameters.AddWithValue("@ProductPrice", objProduct.ProductPrice);
                cmd.Parameters.AddWithValue("@CategoryID", objProduct.CategoryID);
                cmd.Parameters.AddWithValue("@ProductImagePath", objProduct.FilePath);
                
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
}
