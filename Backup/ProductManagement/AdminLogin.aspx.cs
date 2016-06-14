/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:User Interface Layer
* Date:28 Jan 2016
* Dependancy: LoginDal.cs, LoginBal.cs, Login.cs, ProductWebService.cs(web service)
*/

using System;
using ModelController.Login;
using ProductManagement.ProductServiceReference;
using System.Collections.Generic;

namespace ProductManagement
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        #region -- Variable Declaration --

        /// <summary>
        /// Initializes login object
        /// </summary>
        Logins objLogin = new Logins();

        #endregion

        /// <summary>
        /// Default Page load method event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Check user login validation for admin user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            //set values for login object 
            objLogin.UserName = txtUserName.Text;
            objLogin.UserPassword = txtPassword.Text;

            //Initializes object for WCF service
            ProductServiceClient productClient = new ProductServiceClient();
            
            //Initializes login list object
            IList<Logins> lstLogin = new List<Logins>();

            //Get user list using method from WCF service
            lstLogin = productClient.GetUserList(objLogin);
            
            //check is user exist or not if admin user exist then it will redirect to category list page else display alert message
            if (lstLogin.Count > 0)
            {
                //Set user name value to the session user
                Session["UserLogin"] = lstLogin[0].UserName;

                //Redirect to category list page
                Response.Redirect("AdminWelcome.aspx");
            }
            else
            {
                //Set label text value
                lblMsg.Text = "Invalid User Credentials";

                //Set color of label for warning
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }

            //close the product object
            productClient.Close();
        }
    }
}