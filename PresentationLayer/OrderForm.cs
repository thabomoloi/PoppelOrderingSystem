using PoppelOrderingSystem.BusinessLayer;
using PoppelOrderingSystem.DatabaseLayer;
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
            public string InStock { get; set; }
            public string Quantity { get; set; }
            public string InvID { get; set; }
        }

        private class ListItemView
        {
            public string ProductID { get; set; }
            public string Barcode { get; set; }
            public string Description { get; set; }
            public string Quantity { get; set; }
            public string Picked { get; set; }
        }
        #endregion

        #region  Data Members
        private ProductHandler productHandler;
        private InventoryItemHandler inventoryItemHandler;
        private CatalogProductHandler catalogProductHandler;

        private Order order;
        private OrderHandler orderHandler;
        private CustomerController customerController;
        private AddressHandler addressHandler;
        private DeliveryAddressHandler deliveryAddressHandler;
        private static OrderItem anItem;

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

            orderHandler = new OrderHandler();

            order = new Order
            {
                ClerkID = clerkID,
                CustomerNumber = custNumber,
                OrderDate = DateTime.Now,
                DeliveryDate = DateTime.MaxValue,
                Status = Order.OrderStatus.New,
                Total = 0,
                Items = new Collection<OrderItem>()
            };

            try
            {
                order.OrderNumber = orderHandler.AllOrders.Last().OrderNumber + 1;
            } catch (Exception)
            {
                order.OrderNumber = 0;
            }
            orderHandler.DataMaintenance(order, DB.DBOperation.Add);
            orderHandler.FinalizeChanges();

            InitializeComponent();
        }
        #endregion

        #region Load
        private void OrderForm_Load(object sender, EventArgs e)
        {
            orderTabControl.Appearance = TabAppearance.FlatButtons;
            orderTabControl.ItemSize = new Size(0, 1);
            orderTabControl.SizeMode = TabSizeMode.Fixed;
            RefreshDataGridView();

        }

        public void RefreshDataGridView()
        {
            viewOrder.Text = order.Items.Count.ToString();
            inventoryItemHandler = new InventoryItemHandler();
            ProductDataViews = new Collection<ProductDataView>();
            filterBox.SelectedIndex = 0;
            searchBox.Text = "";
            for (int i = 0; i < CatalogProducts.Count; i++)
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
                    InStock = item.QuantityInStock.ToString()
                };
                ProductDataViews.Add(view);
            }
            prodGridView.DataSource = ProductDataViews.ToList<ProductDataView>();
            prodGridView.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            prodGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            prodGridView.Columns["Quantity"].Visible = false;
            prodGridView.Columns["InvID"].Visible = false;
        }


        #endregion

        #region Search Methods 
        private void Search(String text)
        {
            text = text.ToLower();
            Collection<ProductDataView> results = new Collection<ProductDataView>();
            for (int i = 0; i < ProductDataViews.Count; i++)
            {
                ProductDataView view = ProductDataViews[i];
                if ((view.ProductID.ToLower().Contains(text) || view.Barcode.ToLower().Contains(text) || view.CatalogID.ToLower().Contains(text) || view.Description.ToLower().Contains(text)) &&
                    ((view.InStock != "0" && filterBox.SelectedItem.ToString() == "In Stock") ||
                    (view.InStock == "0" && filterBox.SelectedItem.ToString() == "Out Of Stock") || filterBox.SelectedItem.ToString() == "All"))
                {
                    results.Add(view);
                }
            }
            prodGridView.DataSource = results.ToList<ProductDataView>();
            prodGridView.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            prodGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

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
                addToOrderButton.Visible = true;
                completeOrderButton.Visible = true;
            }
            else
            {
                itemLabel.Text = "";
                priceLabel.Text = "";
                instockLabel.Text = "";
                addToOrderButton.Visible = false;
                completeOrderButton.Visible = false;
            }
        }
        #endregion

        #region Click Events 

        #region Add to order
        private void addToOrderButton_Click(object sender, EventArgs e)
        {
            var selected = prodGridView.SelectedRows;
            if (selected.Count > 0)
            {
                var prodID = selected[0].Cells[0].Value.ToString();
                var catID = selected[0].Cells[1].Value.ToString();
                var catalogProdut = catalogProductHandler.Find(catID, prodID);

                InventoryItemHandler invHandler = new InventoryItemHandler();
                var invItem = inventoryItemHandler.FindByProdId(inventoryItemHandler.AllInventoryItems, prodID);

                Product prod = productHandler.Find(prodID);
                Catalog catalog = (new CatalogHandler()).Find(catID);

                if (catalog.EndDate < DateTime.Now)
                {
                    MessageBox.Show($"The catalog with ID {catID} has ended on {catalog.EndDate.ToString("dd/MM/yyyy")}", "Catalog Expired");
                }
                else
                {
                    OrderItem newItem = new OrderItem();
                    using (OrderItemForm itemForm = new OrderItemForm(catalogProdut, invItem, prod, newItem))
                    {
                        customerController = new CustomerController();
                        Customer customer = customerController.Find(EnterCustomerNumberDialog.customerNumber);
                        itemForm.Customer = customer;
                        itemForm.Order = order;

                        var dialogResult = itemForm.ShowDialog();
                        if (dialogResult == DialogResult.Cancel) return;
                        else
                        {
                            var anOI = OrderItemForm.anOItem;
                            anOI.OrderNumber = order.OrderNumber;
                            order.add(anOI);
                            var anInv = OrderItemForm.anInv;
                            inventoryItemHandler.DataMaintenance(anInv, DB.DBOperation.Edit);
                            inventoryItemHandler.FinalizeChanges();
                            ProductDataViews = new Collection<ProductDataView>();
                            viewOrder.Text = order.Items.Count.ToString();
                            RefreshDataGridView();
                        }
                    }
                }
            }
        }

        #endregion

        #region Open order items tab

        private void OpenOrderItemsTab()
        {
            orderTabControl.SelectedTab = orderItemsTab;
            RefreshItemView();
            setOrderDataGridView();
        }

        private void RefreshItemView()
        {
            inventoryItemHandler = new InventoryItemHandler();
            Collection<ProductDataView> orderItemData = new Collection<ProductDataView>();

            for (int i = 0; i < order.Items.Count; i++)
            {
                InventoryItem inv = inventoryItemHandler.Find(order.Items[i].InventoryItemID);
                Product prod = productHandler.Find(inv.ProductID);

                ProductDataView view = new ProductDataView
                {
                    ProductID = prod.ProductID,
                    CatalogID = "",
                    Barcode = prod.Barcode,
                    Description = prod.Description,
                    Price = "R" + order.Items[i].Price.ToString(),
                    Quantity = order.Items[i].Quantity.ToString(),
                    InvID = order.Items[i].InventoryItemID.ToString()
                };

                orderItemData.Add(view);
            }
            orderDataGridView.DataSource = orderItemData.ToList<ProductDataView>();
            orderDataGridView.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            orderDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            orderDataGridView.Columns["InStock"].Visible = false;
            orderDataGridView.Columns["CatalogID"].Visible = false;
            orderDataGridView.Columns["InvID"].Visible = false;
        }

        private void viewOrderButton_Click(object sender, EventArgs e)
        {
            OpenOrderItemsTab();
        }

        private void viewOrder_Click(object sender, EventArgs e)
        {
            OpenOrderItemsTab();
        }
        #endregion

        #region Order Items Tab
        private void orderDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            setOrderDataGridView();
        }
        private void setOrderDataGridView()
        {
            if (order.Items.Count == 0) completeOrderButton.Visible = false;
            else completeOrderButton.Visible = true;

            double total = 0;
            foreach (OrderItem anOI in order.Items)
            {
                total += anOI.getSubTotal();
            }
            orderTotalLabel.Text = "R" + total.ToString();

            var selected = orderDataGridView.SelectedRows;
            if (selected.Count > 0)
            {
                var prodID = selected[0].Cells[0].Value.ToString();
                var catID = selected[0].Cells[1].Value.ToString();
                var descprition = selected[0].Cells[3].Value.ToString();
                orderItemLabel.Text = descprition;
                var price = selected[0].Cells[4].Value.ToString();
                itemPriceLabel.Text = price;
                var qty = selected[0].Cells[6].Value.ToString();
                itemQuantityLabel.Text = qty;
                var inviD = selected[0].Cells[7].Value.ToString();


                foreach (OrderItem oi in order.Items)
                {
                    if (oi.InventoryItemID == int.Parse(inviD))
                    {
                        anItem = oi;
                        break;
                    }
                }
                subtotalLabel.Text = "R" + anItem.getSubTotal();
                removeItemButton.Visible = true;
                removePanel.Visible = true;
            }
            else
            {
                orderItemLabel.Text = "";
                itemPriceLabel.Text = "";
                itemQuantityLabel.Text = "";
                subtotalLabel.Text = "";
                removeItemButton.Visible = false;
                removePanel.Visible = false;
            }
        }
        #endregion

        #region Order Items tab Click
        private void addMoreButton_Click(object sender, EventArgs e)
        {
            orderTabControl.SelectedTab = addItemsTab;
        }
        #endregion

        #region Remove Buttton
        private void removeItemButton_Click(object sender, EventArgs e)
        {
            var selected = orderDataGridView.SelectedRows;
            if (selected.Count > 0)
            {
                var prodID = selected[0].Cells[0].Value.ToString();
                var catID = selected[0].Cells[1].Value.ToString();
                var descprition = selected[0].Cells[3].Value.ToString();
                orderItemLabel.Text = descprition;
                var price = selected[0].Cells[4].Value.ToString();
                itemPriceLabel.Text = price;
                var qty = selected[0].Cells[6].Value.ToString();
                itemQuantityLabel.Text = qty;
                var inviD = selected[0].Cells[7].Value.ToString();


                foreach (OrderItem oi in order.Items)
                {
                    if (oi.InventoryItemID == int.Parse(inviD))
                    {
                        anItem = oi;
                        break;
                    }
                }

                order.remove(anItem);
                var anInv = inventoryItemHandler.Find(anItem.InventoryItemID);
                anInv.QuantityInStock += int.Parse(qty);
                inventoryItemHandler.DataMaintenance(anInv, DB.DBOperation.Edit);
                inventoryItemHandler.FinalizeChanges();

                setOrderDataGridView();
                RefreshDataGridView();
                RefreshItemView();
                
            }
        }

        #endregion

        #region Complete Order

        private void completeOrderButton_Click(object sender, EventArgs e)
        {
            orderTabControl.SelectedTab = completeOrderTab;

            customerController = new CustomerController();
            Customer customer = customerController.Find(EnterCustomerNumberDialog.customerNumber);

            addressHandler = new AddressHandler();
            Address address = addressHandler.FindByCustNo(addressHandler.AllAddresses, customer.CustomerNumber);
            addressLabel.Text = address.ToString();

            completeOrderTotal.Text = "R" + order.getTotal().ToString();
        }

        #endregion

        #endregion

        private void backToOrder_Click(object sender, EventArgs e)
        {
            orderTabControl.SelectedTab = orderItemsTab;
        }

        private void confirmOrderButton_Click(object sender, EventArgs e)
        {
            orderTabControl.SelectedTab = detailsTab;

            customerController = new CustomerController();
            Customer customer = customerController.Find(EnterCustomerNumberDialog.customerNumber);

            addressHandler = new AddressHandler();
            Address address = addressHandler.FindByCustNo(addressHandler.AllAddresses, customer.CustomerNumber);
            address2Label.Text = address.ToString();

            orderLabelTotal.Text = "R" + order.getTotal().ToString();
            orderIDLabel.Text = order.OrderNumber.ToString();

            
            custNameLabel.Text = customer.Name;

            AccountHandler acHandler = new AccountHandler();
            Account account = acHandler.FindByCustNo(acHandler.AllAccounts, customer.CustomerNumber);
            account.AvailableCredit -= order.getTotal();
            account.Balance -= order.getTotal();

            customer.CustCreditStatus = Customer.CreditStatus.OnHold;
            balLabel.Text = "R" + Math.Abs(account.Balance).ToString();

            customerController.DataMaintenance(customer, DB.DBOperation.Edit);
            customerController.FinalizeChanges();

            acHandler.DataMaintenance(account, DB.DBOperation.Edit);
            acHandler.FinalizeChanges();
            order.Status = Order.OrderStatus.Confirmed;
            
            orderHandler.DataMaintenance(order, DB.DBOperation.Edit);
            orderHandler.FinalizeChanges();

            foreach (OrderItem item in order.Items)
            {
                OrderItemHandler orderItemHandler = new OrderItemHandler();
                orderItemHandler.DataMaintenance(item, DB.DBOperation.Add);
                orderItemHandler.FinalizeChanges();
            }
        }

        private void orderTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void viewList_Click(object sender, EventArgs e)
        {
            orderTabControl.SelectedTab = pickList;
            customerController = new CustomerController();
            Customer customer = customerController.Find(EnterCustomerNumberDialog.customerNumber);
            custPick.Text = "Customer Name: " + customer.Name;

            addressHandler = new AddressHandler();
            Address address = addressHandler.FindByCustNo(addressHandler.AllAddresses, customer.CustomerNumber);
            shipAddress.Text = address.ToString();

            orderPickNum.Text = "Order Number: " + order.OrderNumber.ToString();

            datePick.Text = "Date: " + order.OrderDate.ToString("yyyy/MM/dd");


            inventoryItemHandler = new InventoryItemHandler();
            var ListViews = new Collection<ListItemView>();

            for (int i = 0; i < order.Items.Count; i++)
            {
                OrderItem anOi = order.Items[i];
                InventoryItem item = inventoryItemHandler.Find(anOi.InventoryItemID);
                Product prod = productHandler.Find(item.ProductID);

                ListItemView itemList = new ListItemView
                {
                    ProductID = prod.ProductID,
                    Barcode = prod.Barcode,
                    Description = prod.Description,
                    Quantity = anOi.Quantity.ToString(),
                    Picked = "No"
                };
                ListViews.Add(itemList);
            }
            dataGridViewList.DataSource = ListViews.ToList<ListItemView>();
            dataGridViewList.Columns["Barcode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewList.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
           

        }
    }

}
