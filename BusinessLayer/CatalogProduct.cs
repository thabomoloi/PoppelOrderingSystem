using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class CatalogProduct
    {
        #region Data members 
        private string catalogId, productID;
        private double price, specialPrice;
        #endregion

        #region Properties 
        public string CatalogID
        {
            get { return catalogId; }
            set { catalogId = value; }
        }
        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public double SpecialPrice
        {
            get { return specialPrice; }
            set { specialPrice = value; }
        }
        #endregion
    }
}
