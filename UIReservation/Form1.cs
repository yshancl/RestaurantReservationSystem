using System;
using System.Windows.Forms;
using ReservationBusinessLogic;
using ReservationDataLogic;
using ReservationDataService;

namespace UIReservation
{
    public partial class ReservationSystem : Form
    {
        private readonly ReservationProcess reservationProcess;

        public ReservationSystem()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            var bookForm = new bookingReservationForm();
            MessageBox.Show("Reservation booked!");
             
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            var bookForm = new ViewReservationForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var bookForm = new UpdateReservationForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var bookForm = new CancelReservationForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}