using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E94111091_王昊晨_practice8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'e94111091_dbDataSet2.Items' 資料表。您可以視需要進行移動或移除。
            this.itemsTableAdapter.Fill(this.e94111091_dbDataSet2.Items);
            // TODO: 這行程式碼會將資料載入 'e94111091_dbDataSet2.Customers' 資料表。您可以視需要進行移動或移除。
            this.customersTableAdapter.Fill(this.e94111091_dbDataSet2.Customers);
            // TODO: 這行程式碼會將資料載入 'e94111091_dbDataSet2.TransactionHistory' 資料表。您可以視需要進行移動或移除。
            this.transactionHistoryTableAdapter.Fill(this.e94111091_dbDataSet2.TransactionHistory);

        }
    }
}
