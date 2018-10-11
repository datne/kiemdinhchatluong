using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiemdinhchatluong_dat
{
    public partial class formCheck : Form
    {
        public formCheck()
        {
            InitializeComponent();
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtDay.Text = "";
            txtMonth.Text = "";
            txtYear.Text = "";
        }

        private void txtDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDay.Text) && !string.IsNullOrEmpty(txtMonth.Text) && !string.IsNullOrEmpty(txtYear.Text))
            {
                if (this.checkValidate(txtDay.Text,txtMonth.Text,txtYear.Text))
                {
                    MessageBox.Show(this.checkDate(txtMonth.Text,txtYear.Text).ToString());
                    
                }
                else { MessageBox.Show("Đầu vào không hợp lệ !"); }
            }
            else { MessageBox.Show("chua co chu nao"); }        
        }

        private bool checkValidate(string day,string month,string year)
        {
            int n;        
            if((int.Parse(day) <= 31 && int.Parse(day) >= 1) && (int.Parse(month) <= 12 && int.Parse(month) >= 1))
            {
                return true;
            }
            else if(int.TryParse(year, out n))
            {
                return true;
            }
            return false;
        }

        private int checkDate(string monthInput, string yearInput)
        {
            int year = int.Parse(yearInput);
            int month = int.Parse(monthInput);
            int[] date31 = { 1, 3, 5, 7, 8, 10, 12 };
            int[] date30 = { 4, 6, 9, 11 };          
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                //nhuan
                if (!date31.Contains(month) && !date30.Contains(month))
                {
                    // la thang 2 cua nam nhuan
                    return 29;
                }
                else
                {
                    if (date31.Contains(month)) { return 31; }
                    else { return 30; }
                }          
            }
            else {
                if (!date31.Contains(month) && !date30.Contains(month))
                {
                    // la thang 2 cua nam khong nhuan
                    return 28;
                }
                else
                {
                    if (date31.Contains(month)) { return 31; }
                    else { return 30; }
                }
            }        

        }

        private void formCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Exit or no?",
                       "Confirm",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
