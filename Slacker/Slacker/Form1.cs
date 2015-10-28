using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Slacker.DAO;
using CADCoder.Controls.Basic;
using Slacker.Native;

namespace Slacker
{
    public partial class Slacker : Form
    {

        private MySQLStorage _store = new MySQLStorage();
        public Slacker()
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
                list.FileHandler = new WindowsFileHandler();
                list.loadTimes();
                _store.insert(list.getTimes());
                System.Windows.Forms.MessageBox.Show("Complete.");
            }
        }
    }
}
