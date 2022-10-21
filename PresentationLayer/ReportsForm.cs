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
    public partial class ReportsForm : Form
    {
        private class ExpiredView
        {
            public string ProductID { get; set; }
            public string  Barcode { get; set; }
            public string Description { get; set; }
            public string Supplier { get; set; }
            public string ExpiryDate { get; set; }
            public string QuantityExpired { get; set; }
        }

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            Collection<ExpiredView> views = new Collection<ExpiredView>();
            Random rand = new Random(2012);
            views.Add( new ExpiredView {
                ProductID = "P000001", 
                Description = "Coca-Cola Original 6 x 300ml Cans", 
                Barcode = "5449000256812",
                Supplier = "Supplier A",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000001", 
                Description = "Coca-Cola Original 6 x 300ml Cans", 
                Barcode = "5449000256812",
                Supplier = "Supplier A",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000002", 
                Description = "Coca-Cola Original Less Sugar  12 x 300ml",
                Barcode = "5000112638448",
                Supplier = "Supplier B",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add(new ExpiredView
            {
                ProductID = "P000003",
                Description = "Coca-Cola 12 x 1 Litre",
                Barcode = "5119010256812",
                Supplier = "Supplier C",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000003", 
                Description = "Coca-Cola 12 x 1 Litre", 
                Barcode = "5119010256812",
                Supplier = "Supplier C",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000004", 
                Description = "Fanta 6 x 300ml Cans", 
                Barcode = "6430002533212",
                Supplier = "Supplier D",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000005", 
                Description = "Fanta 12 x 300ml Cans",
                Barcode = "5442433056812",
                Supplier = "Supplier E",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000006", 
                Description = "Pepsi 6 x 500ml Bottles", 
                Barcode = "9872000255262",
                Supplier = "Supplier F",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000007", 
                Description = "Pepsi 12 x 500ml", 
                Barcode = "7282888256812",
                Supplier = "Supplier G",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000007", 
                Description = "Pepsi 12 x 500ml", 
                Barcode = "7282888256812",
                Supplier = "Supplier G",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000008", 
                Description = "Sprite 6 x 300ml Cans",
                Barcode = "4567800256812",
                Supplier = "Supplier H",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000009", 
                Description = "Sprite 12 x 1 Litre", 
                Barcode = "4657632561233",
                Supplier = "Supplier I",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add(new ExpiredView
            {
                ProductID = "P000010",
                Description = "Stoney 6 x 300ml Cans",
                Barcode = "6449120253412",
                Supplier = "Supplier J",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add( new ExpiredView {
                ProductID = "P000009", 
                Description = "Sprite 12 x 1 Litre", 
                Barcode = "4657632561233",
                Supplier = "Supplier I",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            views.Add(new ExpiredView
            {
                ProductID = "P000010",
                Description = "Stoney 6 x 300ml Cans",
                Barcode = "6449120253412",
                Supplier = "Supplier J",
                QuantityExpired = rand.Next(1, 20).ToString(),
                ExpiryDate = DateTime.Now.AddDays(-1 * rand.Next(0, 60)).ToString("yyyy/MM/dd")
            });
            dataGridView1.DataSource = views.ToList<ExpiredView>();
            dataGridView1.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            var sum = 0;
            foreach (var view in views)
            {
                sum += int.Parse(view.QuantityExpired);
                total.Text = "Total Expired: " + sum.ToString();
            }

        }
    }
}
