using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K2Field.Azure.Search.Sandbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateIndex_Click(object sender, EventArgs e)
        {
            Client.SearchIndex.CreateIndex(txtIndexName.Text, null, null);
        }

        private void btnExists_Click(object sender, EventArgs e)
        {

            MessageBox.Show(Client.SearchIndex.GetIndex(txtIndexName.Text).name);
        }
    }
}
