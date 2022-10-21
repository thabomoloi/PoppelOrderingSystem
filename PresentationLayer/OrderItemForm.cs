using PoppelOrderingSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoppelOrderingSystem.PresentationLayer
{
    public partial class OrderItemForm : Form
    {
        #region Data Members
        private CatalogProduct catProduct;
        private Product product;
        private InventoryItem inventoryItem;
        private OrderItem orderItem;
        private OrderItemHandler itemHandler;
        private InventoryItemHandler invItemHandler;

        private int quantity;
        private int qtyStock;
        public static InventoryItem anInv;
        public static OrderItem anOItem;
        public Customer Customer { get; set; }
        private Account account;
        public Order Order { get; set; }
        #endregion

        #region Constructor
        public OrderItemForm(CatalogProduct catProd, InventoryItem invItem, Product prod, OrderItem anOI)
        {
            catProduct = catProd;
            product = prod;
            inventoryItem = invItem;

            itemHandler = new OrderItemHandler();
            invItemHandler = new InventoryItemHandler();

            quantity = anOI.Quantity;
            qtyStock = 0;
            orderItem = anOI;
            orderItem.Price = catProd.Price;
            orderItem.InventoryItemID = invItem.InventoryItemID;
           
            InitializeComponent();
        }
        #endregion

        #region Click Listeners
        private void decreaseQuantity_Click(object sender, EventArgs e)
        {
            if (quantity == 0) return;
            quantityLabel.Text = (--quantity).ToString();
            qtyStock++;
            subtotalLabel.Text = "R" + (quantity * orderItem.Price).ToString();
        }

        private void increaseQuantity_Click(object sender, EventArgs e)
        {
            if (quantity == inventoryItem.QuantityInStock)
            {
                MessageBox.Show($"Only {quantity} items are availabe.", "Quantity exceeded");
                return;
            }
            quantityLabel.Text = (++quantity).ToString();
            qtyStock--;
            subtotalLabel.Text = "R" + (quantity * orderItem.Price).ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var accHandler = new AccountHandler();
            account = accHandler.FindByCustNo(accHandler.AllAccounts ,Customer.CustomerNumber);

            if (Order.getTotal() + (quantity * orderItem.Price) > account.AvailableCredit)
            {
                MessageBox.Show($"Order for customer ({Customer.CustomerNumber}) exceeded customer's available credit.\nOrder total: R{Order.getTotal()}\nAvailable credit: R{account.AvailableCredit}", "Credit exceeded", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            orderItem.Quantity += quantity;
            inventoryItem.QuantityInStock += qtyStock;
            this.DialogResult = DialogResult.OK;
            anInv = inventoryItem;
            anOItem = orderItem;
            this.Close();
        }
        #endregion

        #region Form Load
        private void OrderItemForm_Load(object sender, EventArgs e)
        {
            productIDLabel.Text = product.ProductID;
            barcodeLabel.Text = product.Barcode;
            descriptionLabel.Text = product.Description;
            priceLabel.Text = "R" + catProduct.Price.ToString();
            catalogIDLabel.Text = catProduct.CatalogID;
            inStockLabel.Text = inventoryItem.QuantityInStock.ToString();
            quantityLabel.Text = quantity.ToString();
            subtotalLabel.Text = "R0";
        }
        #endregion
    }
}
