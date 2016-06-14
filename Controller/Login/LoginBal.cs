/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Get Login User Information
* Date:28 Jan 2016
* Dependancy: LoginDal.cs, AdminLogin.aspx
*/

using System.Data;
using ModelController.Login;
using System;
using System.Collections.Generic;

namespace Controller.Login
{
    public class LoginBal
    {
        /// <summary>
        /// Search Category Information
        /// </summary>
        /// <param name="objLogin">get login object</param>
        /// <returns>login data</returns>
        public List<Logins> GetUserList(Logins objLogin)
        {
            //initialize object for login data access layer
            LoginDal objLoginDal = new LoginDal();
            
            //Initialize object for list of login 
            List<Logins> lstLogin = new List<Logins>();
            
            //Initialize dataset and get list of users from login data access layer 
            DataSet ds = objLoginDal.GetUserList(objLogin);

            //check dataset records, if records exist then add value for list of logins
            for (int index = 0; index < ds.Tables[0].Rows.Count; index++)
            {
                lstLogin.Add(new Logins
                {
                    UserName = ds.Tables[0].Rows[index]["UserName"].ToString(),
                    UserPassword = ds.Tables[0].Rows[index]["UserPassword"].ToString()
                });
            }

            //return list of login users
            return lstLogin;
        }
    }
}
