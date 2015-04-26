using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace BookShow
{
    public partial class FoodAndCoupon : Form
    {
        OracleConnection conn;
        OracleCommand comm;
        // Following classes are used only with select query
        OracleDataAdapter da;
        DataSet ds;
        DataTable dt;
        DataRow dr;
        int i = 0;
        int count = 0;
        Food_Model[] foodData = new Food_Model[10];
        Coupon_Model[] couponData = new Coupon_Model[5];
        public FoodAndCoupon()
        {
            InitializeComponent();
            connect1();

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

        public void connect1()
        {
            string oradb = "Data Source=SHUBHAMSORTD531;User ID=system;Password=sorte";
            conn = new OracleConnection(oradb);  // C#
            conn.Open();
            //if (Program.Globals.foodSelected)
            //{
                getFoodData();
            //}
        }

        private void getFoodData()
        {
            comm = new OracleCommand();
            comm.CommandText = "select * from food";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "food");
            dt = ds.Tables["food"];
            int t = dt.Rows.Count;

            for (int x = 0; x <t; x++)
            {
                dr = dt.Rows[x];
                count = x;
                foodData[count] = new Food_Model();

                foodData[count].item_no = int.Parse(dr["item_no"].ToString());
                foodData[count].stall = int.Parse(dr["stall"].ToString());
                foodData[count].price =int.Parse(dr["price"].ToString());
                foodData[count].food_name = dr["food_name"].ToString();

                checkedListBox1.Items.Add(foodData[count].food_name);
                //MessageBox.Show(foodData[count].food_name );

            }
            
            
            OracleCommand comm2 = new OracleCommand();
            comm2.CommandText = "select * from coupon";
            comm2.CommandType = CommandType.Text;
     
            OracleDataAdapter da2 = new OracleDataAdapter(comm2.CommandText, conn);
            DataSet ds2 = new DataSet();
            DataTable dt2;
            DataRow dr2;
            int i2 = 0;
            int count2 = 0;
            
            da2.Fill(ds2, "coupon");
            dt2 = ds2.Tables["coupon"];
            int t2 = dt2.Rows.Count;

            for (int x = 0; x < t2; x++)
            {
                dr2 = dt2.Rows[x];
                count2 = x;
                couponData[count2] = new Coupon_Model() ;
                couponData[count2].id = int.Parse(dr2["id"].ToString());
                couponData[count2].cno = int.Parse(dr2["cno"].ToString());
                couponData[count2].type = dr2["type"].ToString();
                couponData[count2].partners_with = dr2["partners_with"].ToString();

                checkedListBox2.Items.Add(couponData[count2].type);

                //MessageBox.Show(foodData[count].food_name );

            }
             

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Price :"+foodData[checkedListBox1.SelectedIndex].price.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Globals.tbv.Show();
        }

    }
}
