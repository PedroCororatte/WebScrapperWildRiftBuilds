using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.IO;

namespace WebScraperRankBoost
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void lbConnect_Click(object sender, EventArgs e)
        {
            Data.Conect();
           lbConnect.Text = Data.ConnectionStatus;
           
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Data.Conect();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Scrapper.RefreshLists();
            
             foreach(string name in Scrapper.nameList) 
             {
                Data.InsertNames(name);
             }

            foreach (string stats in Scrapper.statsList)
            {
                Data.InsertStats(stats);
            }

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Data.Disconnect();
        }


    }
}
 