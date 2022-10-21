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

        private OrderHandler orderHandler;
        private Collection<Order> Orders { get; set; }
        private Collection<OrderDataView> OrderDataViews;
        public OrderListForm()
        {
            orderHandler = new OrderHandler();
            Orders = orderHandler.AllOrders;
            OrderDataViews = new Collection<OrderDataView>();
            InitializeComponent();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Orders.Count; i++)
            {
                Order order = Orders[i];

                OrderDataView view = new OrderDataView
                {
                    OrderNumber = order.OrderNumber.ToString(),
                    OrderDate = order.OrderDate.ToString("yyyy/MM/dd"),
                    DeliveryDate = (DateTime.MaxValue.Subtract(order.DeliveryDate).Days < 2) ? "" : order.DeliveryDate.ToString("yyyy/MM/dd"),
                    Status = order.Status.ToString(),
                    Total = order.Total.ToString(),
                    CustomerNumber = order.CustomerNumber,
                    ClerkID = order.ClerkID
                };
                OrderDataViews.Add(view);
            }
            dataGridView.DataSource = OrderDataViews;
            dataGridView.Columns["Total"].Visible = false;
            dataGridView.Columns["OrderNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
            dataGridView.Columns["OrderDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
            dataGridView.Columns["DeliveryDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
            dataGridView.Columns["Status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView.Columns["CustomerNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView.Columns["ClerkID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
        }
    }
}
