using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPstrategy
{
    public partial class Form1 : Form
    {
        double total = 0.0d;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //version 1
            //double totalPrices = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text);
            //
            //total = total + totalPrices;
            //
            //lbxList.Items.Add("单价：" + txtPrice.Text + " 数量：" + txtNum.Text + "合计： " 
            //   + totalPrices.ToString());
            //
            //lblResult.Text = total.ToString();

            //version 2
            //double totalPrices = 0d;
            //switch (cbxType.SelectedIndex)
            //{ 
            //    case 0:
            //        totalPrices = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text);
            //        break;
            //    case 1:
            //        totalPrices = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text) 
            //            * 0.8;
            //        break;
            //    case 2:
            //        totalPrices = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text) 
            //            * 0.7;
            //        break;
            //    case 3:
            //        totalPrices = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text) 
            //            * 0.5;
            //        break;
            //}
            //total = total + totalPrices;
            //lbxList.Items.Add("单价：" + txtPrice.Text + " 数量：" + txtNum.Text + 
            //    " " + cbxType.SelectedItem + " 合计： " + totalPrices.ToString());
            //lblResult.Text = total.ToString();

            //version 3
            //CashSuper csuper = CashFactory.createCashAccept(cbxType.SelectedItem.ToString());
            //double totalPrices = 0d;
            //totalPrices = csuper.acceptCash(Convert.ToDouble(txtPrice.Text) 
            //    * Convert.ToDouble(txtNum.Text));
            //total = total + totalPrices;
            //lbxList.Items.Add("单价：" + txtPrice.Text + " 数量：" + txtNum.Text +
            //    " " + cbxType.SelectedItem + " 合计： " + totalPrices.ToString());
            //lblResult.Text = total.ToString();

            //version 4
            CashContext csuper = new CashContext(cbxType.SelectedItem.ToString());
            double totalPrices = 0d;
            totalPrices = csuper.GetResult(Convert.ToDouble(txtPrice.Text)
                * Convert.ToDouble(txtNum.Text));
            total = total + totalPrices;
            lbxList.Items.Add("单价：" + txtPrice.Text + " 数量：" + txtNum.Text +
                " " + cbxType.SelectedItem + " 合计： " + totalPrices.ToString());
            lblResult.Text = total.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //version 2 
            //cbxType.Items.AddRange(new object[] { "正常收费", "打八折", "打七折", "打五折" });

            //version 3 4
            cbxType.Items.AddRange(new object[] { "正常收费", "打8折", "满300返100" });

            cbxType.SelectedIndex = 0;
        }
    }
}
