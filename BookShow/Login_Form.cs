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
    public partial class Login_Form : Form
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
        Reguser_Model[] regUserArray = new Reguser_Model[10];
        int t = 0; // TO KEEP COUNT OF ROWS COMING FROM DB

        bool found = false;
        public Login_Form()
        {
            InitializeComponent();
            connect1();
            
        }

        public void connect1()
        {
            string oradb = "Data Source=SHUBHAMSORTD531;User ID=system;Password=sorte";
            conn = new OracleConnection(oradb);  // C#
            conn.Open();

            comm = new OracleCommand();
            comm.CommandText = "select * from reguser";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "reguser");
            dt = ds.Tables["reguser"];
            int t = dt.Rows.Count;

            for (int x = 0; x < t; x++)
            {
                dr = dt.Rows[x];
                count = x;
                regUserArray[count] = new Reguser_Model();
                regUserArray[count].id = dr["id"].ToString();
                regUserArray[count].adharno = dr["adharno"].ToString();
                regUserArray[count].name = dr["name"].ToString();
                regUserArray[count].emailid = dr["emailid"].ToString();
                //regUserArray[count].phoneno = dr["phoneno"].ToString(); ;
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Type in your Details!!");
            }

            else
            {
                for (int i = 0; i < count; i++)
                {
                    if (textBox1.Text == regUserArray[i].name)
                    {
                        found = true;
                        if (textBox2.Text == regUserArray[i].id)
                        {
                            MessageBox.Show("Login Success");
                            Program.Globals.logged = true;
                            Program.Globals.regUser = regUserArray[i];
                            Program.Globals.bookingId += Program.Globals.regUser.id;
                            if (Program.Globals.currentForm.Equals("MainForm"))
                            {
                                Program.Globals.f1.Show();
                              
                            }
                             
                            goToPreviousPage();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Invalid Credentials");

                        }
                    }
                }

                if (!found)
                {
                    MessageBox.Show("Kuch to sahi dal");
                }
            }
        }
        private void goToPreviousPage()
        {
            this.Hide();
            if (Program.Globals.currentForm.Equals("MainForm"))
            {
                Program.Globals.f1.displayLoggedInfo();
            }
            


        }
        
    }
}
