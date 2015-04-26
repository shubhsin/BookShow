using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// The entire project follows MVC Design Pattern. In each file the role(Model,View,Controller)
// is written just after the using files
namespace BookShow
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }

        public class Globals
        {
            //Access from anywhere
            //Change values
            public static bool logged = false;

            public static Reguser_Model regUser;
            public static Movie_Model selectedMovie;
            //Change values. Remember its static instance
            public static Form1 f1 = new Form1();//Globally hide and show this instance of the form
            public static Login_Form f2 = new Login_Form();//Globally hide and show this instance of the form
            public static Signup f3 = new Signup();
            public static LoginSelection f4 = new LoginSelection();

            public static String currentForm;

            public static SeatSelect f5 = new SeatSelect();
            public static int selectedSeat;

            public static bool foodSelected;
            public static bool couponSelected;

            public static FoodAndCoupon f6 = new FoodAndCoupon();

            public static TicketBookedView tbv = new TicketBookedView();

            public static String bookingId = "";
        }
    }
}
