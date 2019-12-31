using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;

namespace bdPhoneNumberGen
{
    public partial class bpngHome : MetroForm
    {
        public bpngHome()
        {
            InitializeComponent();
        }

        private void BtnGen_Click(object sender, EventArgs e)
        {
            lblProgress.Text = "";
            string sl = txtSL.Text;
            string quat = txtQ.Text;
            int q;
            if (String.IsNullOrWhiteSpace(quat))
            {
                MessageBox.Show("Quantity should be 1 to 30000");
                return;
            }
            bool valid=int.TryParse(quat, out q);
            if (!valid)
            {
                MessageBox.Show("Quantity should be 1 to 30000");
                return;
            }
            if (q<1 || q > 30000)
            {
                MessageBox.Show("Quantity should be 1 to 30000");
                return;
            }
            if (sl == "1")
            {
                MessageBox.Show("Serial should be a 13,14,15,16,17,18,19");
                return;
            }
            if (q > 0) {
                pbProgress.Visible = true;
                Random rand = new Random();
                pbProgress.Value = 0;
                pbProgress.Step = 1;
                pbProgress.Maximum = q;
                pbProgress.Minimum = 0;
                string num="";
                int progress = 0;

                for(int i = 0; i < q; i++)
                {
                    num+= "880" + sl + rand.Next(10000000, 99999999).ToString()+Environment.NewLine;
                    
                    progress = (int)(((i+1) / ((double)q)) * 100);
                    lblProgress.Text = progress.ToString() + "%";
                    pbProgress.PerformStep();

                }
                lblProgress.Text = "Completed";
                txtNum.AppendText(num);
            }
        }

        

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtNum.Text = "";
        }
    }
}
