using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Slacker.DAO;

namespace Slacker
{
    public partial class Form1 : Form
    {

        private MySQLStorage _store = new MySQLStorage();
        public Form1()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileToOpen = FD.FileName;
                CSVDAO list = new CSVDAO(FD.FileName);
                _store.insert(list.getTimes());
            }
        }
    }
}
