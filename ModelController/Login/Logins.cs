/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Category get set variables
* Date:25 Jan 2016
* Dependancy: AdminLogin.aspx
*/

namespace ModelController.Login
{
    public class Logins
    {
        /// <summary>
        /// Variable Declaration
        /// </summary>
        private string _UserName;
        private string _UserPassword;

        /// <summary>
        /// Get and set value for user name
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        /// <summary>
        /// Get and set value for user password
        /// </summary>
        public string UserPassword
        {
            get { return _UserPassword; }
            set { _UserPassword = value; }
        }
    }
}
