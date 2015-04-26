using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookShow
{
    public partial class SeatSelect : Form
    {
        public SeatSelect()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                MessageBox.Show("You can now add Coupons to your order");
                Program.Globals.couponSelected = true;
            }
            else
                Program.Globals.couponSelected = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                MessageBox.Show("You can now add food to your order");
                Program.Globals.foodSelected = true;
            }
            Program.Globals.foodSelected = false;
        }

        private void SeatSelect_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedSeat(button1, 1);
        }

        //Selects seat and disables all other seats
        
        public void selectedSeat(Button b, int num)
        {
            DisableControls(this);
            EnableControls(button25);
            EnableControls(checkBox1);
            EnableControls(checkBox2);
            EnableControls(b);
            EnableControls(button26);
            
            Program.Globals.selectedSeat = num;
            if (num >= 1 && num <= 8)
            {
                MessageBox.Show("Select seat is Platinum :" + num);
            }
            if (num >= 9 && num <= 16)
            {
                MessageBox.Show("Select seat is Gold :" + num);
            }
            if (num >= 17 && num <= 24)
            {
                MessageBox.Show("Select seat is Silver :" + num);
            }

        }


        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }

        }

        void ChangeEnabled(bool enabled)
        {
            foreach (Control c in this.Controls)
            {
                c.Enabled = enabled;
            }
        } 

        private void button26_Click(object sender, EventArgs e)
        {

            ChangeEnabled(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selectedSeat(button2, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedSeat(button3, 3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            selectedSeat(button4, 4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            selectedSeat(button6, 5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            selectedSeat(button5, 6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            selectedSeat(button7, 7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            selectedSeat(button8, 8);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            selectedSeat(button16, 9);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            selectedSeat(button15, 10);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            selectedSeat(button13,11);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            selectedSeat(button14, 12);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            selectedSeat(button12, 13);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            selectedSeat(button11, 14);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            selectedSeat(button9, 15);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            selectedSeat(button10, 16);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            selectedSeat(button24, 17);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            selectedSeat(button23, 18);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            selectedSeat(button21, 19);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            selectedSeat(button22, 20);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            selectedSeat(button20, 21);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            selectedSeat(button19, 22);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            selectedSeat(button17, 23);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            selectedSeat(button18, 24);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Globals.f6.Show();
        }
    }

}
