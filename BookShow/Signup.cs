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
    public partial class Signup : Form
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
        public Signup()
        {
            InitializeComponent();
            connect1();
        }

        public void connect1()
        {
            string oradb = "Data Source=SHUBHAMSORTD531;User ID=system;Password=sorte";
            conn = new OracleConnection(oradb);  // C#
            conn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            connect1();
            OracleCommand cm = new OracleCommand();
            cm.Connection = conn;
            
            cm.CommandText = "insert into reguser values (" + int.Parse(textBox5.Text) + "," + int.Parse(textBox1.Text) + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + Int32.Parse(textBox4.Text) + ",null)";
            //Console.WriteLine("insert into reguser values" + tempString);
            //MessageBox.Show("insert into reguser values" + tempString);

            cm.CommandType = CommandType.Text;
            cm.ExecuteNonQuery();

            MessageBox.Show("Successful signup with id"+textBox5.Text);
            conn.Close();
            this.Hide();
            Program.Globals.f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Globals.f1.Show();
        }

        


    }
}
