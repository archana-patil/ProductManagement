/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Get Login User Information
* Date:28 Jan 2016
* Dependancy: AdminLogin.aspx
*/

using System.Data;
using System.Data.SqlClient;
using System;

namespace ModelController.Login
{
    
    public class LoginDal
    {
        /// <summary>
        /// Get Sql Connection String from web.config file
        /// </summary>
        string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ProductMgmtConnString"].ConnectionString;

        /// <summary>
        ///Check user exist or not for user login  
        /// </summary>
        /// <param name="objLogin"></param>
        /// <returns></returns>
        public DataSet GetUserList(Logins objLogin)
        {
            //Initializes a dataset
            DataSet dsUsers = new DataSet();

            //Initializes a new instance of the SqlConnection class with a string that contains the connection string.
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                //Create a command object identifying the stored procedure
                SqlCommand cmd = new SqlCommand("GetUserInfo", con);
                
                //Set the command object so it knows to execute a stored procedure
                cmd.CommandType = CommandType.StoredProcedure;

                //Add parameters to command, which will be passed to the stored procedure
                cmd.Parameters.AddWithValue("@UserName", objLogin.UserName);
                cmd.Parameters.AddWithValue("@UserPassword", objLogin.UserPassword);

                //Initializes a new instance of the SqlDataAdapter class with the specified SqlCommand as the SelectCommand property.
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                //Fill dataset using command execution 
                adp.Fill(dsUsers);

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
                dsUsers.Dispose();
            }
            
            //return login user list
            return dsUsers;
        }
    }
}
