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
    public partial class Form1 : Form
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
        Movie_Model[] movieArray = new Movie_Model[10];
        int t = 0; // TO KEEP COUNT OF ROWS COMING FROM DB
        public Form1()
        {
            InitializeComponent();
            connect1();
            Connect_Click();
            Program.Globals.logged = false;// Inintially Logout if person selects the login or opens this form
            Program.Globals.currentForm = "MainForm";
        }

        //Connecting to the database through the connection string
        public void connect1()
        {
        string oradb = "Data Source=SHUBHAMSORTD531;User ID=system;Password=sorte";
            conn = new OracleConnection(oradb);  // C#
            conn.Open();
            
        }

        private void Connect_Click()
        {
            connect1();
            comm = new OracleCommand();
            comm.CommandText = "select * from movie";
            comm.CommandType = CommandType.Text;
            ds = new DataSet();
            da = new OracleDataAdapter(comm.CommandText, conn);
            da.Fill(ds, "movie");
            dt = ds.Tables["movie"];
            int t = dt.Rows.Count;

            for (int x = 0; x < t; x++)
            {
                dr = dt.Rows[x];
                count = x;
                movieArray[count] = new Movie_Model();
                movieArray[count].movie_na = dr["movie_na"].ToString();
                movieArray[count].actor = dr["leadactor"].ToString();
                movieArray[count].actress = dr["leadactress"].ToString();
                movieArray[count].director = dr["director"].ToString();
                movieArray[count].producer = dr["producer"].ToString();
               // movieArray[count].rating = (int)dr["rating"];
               
            }
   
            for (int i = 0; i <= count; i++)
            {
                String tempString = String.Empty;
                tempString = movieArray[i].movie_na;
                comboBox1.Items.Add(tempString);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = movieArray[comboBox1.SelectedIndex].movie_na;
            label2.Text = "Director : "+ movieArray[comboBox1.SelectedIndex].director;
            label3.Text = "Actor :"+movieArray[comboBox1.SelectedIndex].actor;
            label4.Text = "Actress :"+ movieArray[comboBox1.SelectedIndex].actress;

            Program.Globals.selectedMovie = movieArray[comboBox1.SelectedIndex];
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Program.Globals.f2.Show(); // Projecting the second form.
        }


        public void displayLoggedInfo()
        {
            if(Program.Globals.logged)
            label5.Text = "Logged in as: "+Program.Globals.regUser.name + "\nID :" +Program.Globals.regUser.id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Globals.f3.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Program.Globals.f4.Show();
            Program.Globals.currentForm = "LoginSelection";
        }

 

    }
}
