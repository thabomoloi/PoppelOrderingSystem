using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Product
    {
        #region Data Members
        private string id, description, barcode, supplier;
        #endregion

        #region Properties
        public string ProductID
        {
            get { return id; }
            set { id = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Barcode
        {
            get { return barcode; }
            set { barcode= value; }
        }
        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }
        #endregion
    }
}
