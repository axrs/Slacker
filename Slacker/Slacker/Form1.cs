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
        public Form1()
        {
            InitializeComponent();
            CSVDAO dao = new CSVDAO(@"L:\Repos\Slacker\Basis\sample.csv");
            dao.execute();
        }
    }
}
