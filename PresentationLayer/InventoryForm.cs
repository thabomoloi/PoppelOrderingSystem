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
    public partial class InventoryForm : Form
    {
        private class InventoryDataView
        {
            public string ProductID { get; set; }
            public string Description { get; set; }
            public string Supplier { get; set; }
            public string Barcode { get; set; }
            public string InventoryItemID { get; set; }
            public string QuantityOnHand { get; set; }
            public string QuantityInStock { get; set; }
        }

        private ProductHandler productHandler;
        private InventoryItemHandler inventoryItemHandler;

        private Collection<InventoryItem> Items { get; set; }
        private Collection<Product> Products { get; set; }

        public InventoryForm()
        {
            productHandler = new ProductHandler();
            inventoryItemHandler = new InventoryItemHandler();

            Items = inventoryItemHandler.AllInventoryItems;
            Products = productHandler.AllProducts;

            InitializeComponent();
        }
        private Collection<InventoryDataView> InventoryDataViews { get; set; }
        private void InventoryForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                InventoryItem item = Items[i];
                Product prod = productHandler.Find(item.ProductID);

                InventoryDataView inventoryDataView = new InventoryDataView
                {
                    ProductID = prod.ProductID,
                    Description = prod.Description,
                    Barcode = prod.Barcode,
                    Supplier = prod.Supplier,
                    InventoryItemID = item.InventoryItemID.ToString(),
                    QuantityOnHand = item.QuantityOnHand.ToString(),
                    QuantityInStock = item.QuantityInStock.ToString()
                };
                InventoryDataViews.Add(inventoryDataView);
            }
            dataGridView.DataSource = InventoryDataViews;
        }
    }
}
