using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoppelOrderingSystem.BusinessLayer
{
    public class Catalog
    {
        #region Data Members 
        private string id, description;
        private int year;
        private DateTime effectiveDate, endDate;
        #endregion

        #region Poperties 
        public string CatalogID
        {
            get { return id; }
            set { id = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public DateTime EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        #endregion
    }
}
