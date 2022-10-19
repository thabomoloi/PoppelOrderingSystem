using PoppelOrderingSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem.PresentationLayer
{
    public partial class CatalogProductsForm : Form
    {
        private class CatalogProductView
        {
            public string ProductID { get; set; }
            public string CatalogID { get; set; }
            public string ProductDescription { get; set; }
            public string CatalogDescription { get; set; }
            public string Barcode { get; set; }
            public string Price { get; set; }
            public string SpecialPrice { get; set; }
        }

        private ProductHandler productHandler;
        private CatalogProductHandler catalogProductHandler;
        private CatalogHandler catalogHandler;

        private Collection<Product> products;
        private Collection<CatalogProduct> catalogProducts;
        private Collection<Catalog> catalogs;

        private Collection<CatalogProductView> CatalogProductViews { get; set; }
        public CatalogProductsForm()
        {
            productHandler = new ProductHandler();
            catalogProductHandler = new CatalogProductHandler();

            products = productHandler.AllProducts;
            catalogProducts = catalogProductHandler.AllCatalogProducts;

            catalogHandler = new CatalogHandler();
            catalogs = catalogHandler.AllCatalogs;

            CatalogProductViews = new Collection<CatalogProductView>();
            InitializeComponent();
        }

        private void CatalogProductsForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < catalogProducts.Count; i ++)
            {
                CatalogProduct catalogProd = catalogProducts[i];
                Catalog catalog = catalogHandler.Find(catalogProd.CatalogID);
                Product product = productHandler.Find(catalogProd.ProductID);

                CatalogProductView catProdView = new CatalogProductView
                {
                    CatalogID = catalog.CatalogID,
                    ProductID = product.ProductID,
                    CatalogDescription = catalog.Description,
                    ProductDescription = product.Description,
                    Barcode = product.Barcode,
                    Price = catalogProd.Price.ToString(),
                    SpecialPrice = catalogProd.SpecialPrice.ToString()
                };
                CatalogProductViews.Add(catProdView);
            }
            dataGridView.DataSource = CatalogProductViews;

        }
    }
}
