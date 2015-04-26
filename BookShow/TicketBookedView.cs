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
    public partial class TicketBookedView : Form
    {
        public TicketBookedView()
        {
            InitializeComponent();
            getQrCode();
        }

        private void getQrCode()
        {
            /*
            var request = WebRequest.Create("https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=shubhsin");

            using (var response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                pictureBox1.Image = Bitmap.FromStream(stream);
            }
             */
         

    }

        private void button1_Click(object sender, EventArgs e)
        {
            String seatType = "";

            int seat = Program.Globals.selectedSeat;
            if (seat >= 1 && seat <= 8)
            {
                seatType = "PL";
            }
            if (seat >= 9 && seat <= 16)
            {
                seatType = "GL";
            }
            if (seat >= 17 && seat <= 24)
            {
                seatType = "SL";
            }
            String regUserID;
            if (!Program.Globals.logged)
            {
                regUserID = "";
            }
            else
            {
               regUserID = Program.Globals.regUser.id;
            }
           // if (Program.Globals.logged)
              pictureBox1.Load("https://api.qrserver.com/v1/create-qr-code/?size=150x150&data=" +regUserID +Program.Globals.selectedMovie.movie_na +seatType + seat);

              label1.Text = "Scan the QR Code to get your booking id\nScan it at the box office";

        }

    }
}
