/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Category get set variables
* Date:25 Jan 2016
* Dependancy: AdminWelcome.aspx
*/

namespace ModelController.Categories
{
    public class Category
    {
        private string _categoryID;
        private string _categoryName;

        public string CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }
    }
}
