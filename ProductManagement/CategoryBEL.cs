using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagement
{
    
    public class CategoryBEL
    {
        private string _categoryID;
        private string _categoryName;

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        public string CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
    }
}