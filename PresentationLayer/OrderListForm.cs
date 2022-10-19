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
    public partial class OrderListForm : Form
    {
        private class OrderDataView
        {
            public string OrderNumber { get; set; }
            public string OrderDate { get; set; }
            public string DeliveryDate { get; set; }
            public string Status { get; set; }
            public string Total { get; set; }
            public string CustomerNumber { get; set; }
            public string ClerkID { get; set; }
        }

        private ProductHandler productHandler;
        private InventoryItemHandler inventoryItemHandler;

        private Collection<InventoryItem> Items { get; set; }
        private Collection<Product> Products { get; set; }
        private Collection<OrderDataView> OrderDataViews;
        public OrderListForm()
        {
            productHandler = new ProductHandler();
            inventoryItemHandler = new InventoryItemHandler();

            Items = inventoryItemHandler.AllInventoryItems;
            Products = productHandler.AllProducts;

            OrderDataViews = new Collection<OrderDataView>();

            InitializeComponent();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                InventoryItem item = Items[i];
                Product prod = productHandler.Find(item.OrderNumber);

                OrderDataView inventoryDataView = new OrderDataView
                {
                    OrderNumber = prod.OrderNumber,
                    OrderDate = prod.OrderDate,
                    Status = prod.Status,
                    DeliveryDate = prod.DeliveryDate,
                    Total = item.Total.ToString(),
                    CustomerNumber = item.CustomerNumber.ToString(),
                    ClerkID = item.ClerkID.ToString(),
                    ReservedItems = (item.CustomerNumber - item.ClerkID).ToString()
                };
                OrderDataViews.Add(inventoryDataView);
            }
            dataGridView.DataSource = OrderDataViews;
            dataGridView.Columns["Total"].Visible = false;
        }
    }
}
