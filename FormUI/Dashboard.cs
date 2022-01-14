using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Dashboard : Form
    {
        public string EventCode = "";
        List<ResidentsParking> resident = new List<ResidentsParking>();
        List<ResidentsParking> formalResident = new List<ResidentsParking>();
        List<ParkingEvents> parkingEvents = new List<ParkingEvents>();

        public Dashboard()
        {
            InitializeComponent();
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            residentListBox.DataSource = resident;
            residentListBox.DisplayMember = "FullResidentInfo";
            flatNumberListBox.DataSource = resident;
            flatNumberListBox.DisplayMember = "CarRegisteredNumber";
            eventsListBox.DataSource = parkingEvents;
            eventsListBox.DisplayMember = "EventDetails";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            resident = db.GetResident(flatNumberTextBox.Text);
            UpdateBinding();
        }

        private void entryButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            formalResident = db.GetResidentFormal(flatNumberTextBox1.Text, registeredCarNumberTextBox1.Text);
            
            EventCode = "Ent";
            db.InsertParkingEvent(formalResident, EventCode);

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            formalResident = db.GetResidentFormal(flatNumberTextBox1.Text, registeredCarNumberTextBox1.Text);

            EventCode = "Ext";
            db.InsertParkingEvent(formalResident, EventCode);
        }

        private void searchButton1_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            parkingEvents = db.GetParkingEvents(registeredCarNumberTextBox2.Text);
            UpdateBinding();
        }
    }
}
