/*
* Programmer Name:Dhanraj Bawaskar
* Purpose:Get and Set Product variables
* Date:27 Jan 2016
* Dependancy: AdminWelcome.aspx
*/


namespace ModelController.Prodoucts
{
    public class Product
    {
        private string _ProductID;
        private string _ProductName;
        private string _ProductDescription;
        private decimal _ProductPrice;
        private string _CategoryID;
        private string _CategoryName;
        private string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }

        public string ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }
        
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }
        
        public string ProductDescription
        {
            get { return _ProductDescription; }
            set { _ProductDescription = value; }
        }

        public decimal ProductPrice
        {
            get { return _ProductPrice; }
            set { _ProductPrice = value; }
        }

        public string CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }

        public string CategoryName
        {
            get { return _CategoryName; }
            set { _CategoryName = value; }
        }
    }
}
