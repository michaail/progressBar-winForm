using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MProgressBar
{
    public partial class MProgressBar : Form
    {
        private System.Threading.CancellationTokenSource cts { get; set; }
        public string infoText
        {
            get
            {
                return this.infoLabel.Text;
            }
            set
            {
                this.infoLabel.BeginInvoke(new Action(() =>
                {
                    this.infoLabel.Text = value;
                }));
            }
        }

        public MProgressBar(System.Threading.CancellationTokenSource cts)
        {
            this.cts = cts;
            this.infoLabel.Text = "";
            InitializeComponent();
        }

        /// <summary>
        /// Cancel button event handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (cts != null) cts.Cancel();
        }



    }
}
