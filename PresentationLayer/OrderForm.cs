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
    public partial class OrderForm : Form
    {
        #region Private View Class
        private class ProductDataView
        {
            public string ProductID { get; set; }
            public string CatalogID { get; set; }
            public string Barcode { get; set; }
            public string Description { get; set; }
            public string Price { get; set; }
            public string QuantityInStock { get; set; }
        }
        #endregion

        #region  Data Members
        private ProductHandler productHandler;
        private InventoryItemHandler inventoryItemHandler;
        private CatalogProductHandler catalogProductHandler;
        #endregion

        #region Private Properties 
        private Collection<InventoryItem> Items;
        private Collection<Product> Products;
        private Collection<CatalogProduct> CatalogProducts;

        private Collection<ProductDataView> ProductDataViews;
        #endregion

        #region Constructor
        public OrderForm(string custNumber, string clerkID)
        {
            productHandler = new ProductHandler();
            inventoryItemHandler = new InventoryItemHandler();
            catalogProductHandler = new CatalogProductHandler();

            Items = inventoryItemHandler.AllInventoryItems;
            Products = productHandler.AllProducts;
            CatalogProducts = catalogProductHandler.AllCatalogProducts;

            ProductDataViews = new Collection<ProductDataView>();
            InitializeComponent();
        }
        #endregion

        #region Load
        private void OrderForm_Load(object sender, EventArgs e)
        {
            filterBox.SelectedIndex = 0;
            for (int i = 0; i <CatalogProducts.Count; i++)
            {
                CatalogProduct catProd = CatalogProducts[i];
                Product prod = productHandler.Find(catProd.ProductID);
                InventoryItem item = inventoryItemHandler.FindByProdId(inventoryItemHandler.AllInventoryItems, prod.ProductID);

                ProductDataView view = new ProductDataView
                {
                    ProductID = prod.ProductID,
                    CatalogID = catProd.CatalogID,
                    Barcode = prod.Barcode,
                    Description = prod.Description,
                    Price = "R" + catProd.Price.ToString(),
                    QuantityInStock = item.QuantityInStock.ToString()
                };
                ProductDataViews.Add(view);
            }
            prodGridView.DataSource = ProductDataViews.ToList<ProductDataView>();
        }
        #endregion

        #region Search Methods 
        private void Search(String text)
        {
            Collection<ProductDataView> results = new Collection<ProductDataView>();
            for (int i = 0; i < ProductDataViews.Count; i++)
            {
                ProductDataView view = ProductDataViews[i];
                if ((view.ProductID.ToLower().Contains(text) || view.Barcode.ToLower().Contains(text) || view.CatalogID.ToLower().Contains(text) || view.Description.ToLower().Contains(text)) &&
                    ((view.QuantityInStock != "0" && filterBox.SelectedItem.ToString() == "In Stock") ||
                    (view.QuantityInStock == "0" && filterBox.SelectedItem.ToString() == "Out Of Stock") || filterBox.SelectedItem.ToString() == "All"))
                {
                    results.Add(view);
                }
            }
            prodGridView.DataSource = results.ToList<ProductDataView>();
            
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            Search(searchBox.Text.Trim());
        }
        private void filterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search(searchBox.Text);
        }

        #endregion

        #region Item Select
        private void prodGridView_SelectionChanged(object sender, EventArgs e)
        {
            var selected = prodGridView.SelectedRows;
            if (selected.Count > 0)
            {
                var prodID = selected[0].Cells[0].Value.ToString();
                var catID = selected[0].Cells[1].Value.ToString();
                var descprition = selected[0].Cells[3].Value.ToString() + $"(ProductID: {prodID}, CatalogID: {catID})";
                itemLabel.Text = descprition;
                var price = selected[0].Cells[4].Value.ToString();
                priceLabel.Text = price;
                var qty = selected[0].Cells[5].Value.ToString();
                instockLabel.Text = qty;
            }
            else
            {
                itemLabel.Text = "";
                priceLabel.Text = "";
                instockLabel.Text = "";
            }
        }
        #endregion

        #region Click Events 
        private void addToOrderButton_Click(object sender, EventArgs e)
        {
            var selected = prodGridView.SelectedRows;
            if (selected.Count > 0)
            {
                var prodID = selected[0].Cells[0].Value.ToString();
                var catID = selected[0].Cells[1].Value.ToString();
                var catalogProdut = catalogProductHandler.Find(catID, prodID);

                InventoryItemHandler invHandler = new InventoryItemHandler();
                var item = inventoryItemHandler.FindByProdId(inventoryItemHandler.AllInventoryItems, prodID);

                Product prod = productHandler.Find(prodID);

            }
        }

        private void viewOrderButton_Click(object sender, EventArgs e)
        {

        }

        private void viewOrder_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
