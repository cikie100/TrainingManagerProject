using DomainLibrary.Domain;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppTraining
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        trainingDBEntities dataEntities = new trainingDBEntities();
        public ObservableCollection<Grid> GridCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GridCollection = new ObservableCollection<Grid>();

            //Voor Cycling
            foreach (CyclingSession sess in dataEntities.CyclingSessions)
            {
                dataGrid1.Items.Add(sess);
            }


            ///////////////////////////////////////////////////
            //Voor Running
            foreach (RunningSession rsess in dataEntities.RunningSessions)
            {
                dataGrid2.Items.Add(rsess);
            }

        }


        private void btnAddCycle_Click(object sender, RoutedEventArgs e)
        {
            
            CyclingSession cs = new CyclingSession();
            #region addNew Cycle
            cs.When = DateTime.ParseExact(cyWhen.Text, "yyyy-MM-dd HH:mm tt", null);
            if(cyDist.Text != null) {
                cs.Distance = float.Parse(cyDist.Text);
            };
            cs.Time = TimeSpan.Parse(cyTime.Text);
            if (cyAvgSpeed.Text != null)
            {
                cs.AverageSpeed = float.Parse(cyAvgSpeed.Text); 
            }
            if (cyAvgWat.Text != "")
            {
                cs.AverageWatt = Convert.ToInt32(cyAvgWat.Text); 
            }
            if (cyTrainType.Text.ToUpper().Equals(("Interval").ToUpper())) {
                cs.TrainingType = 0;
            }
            else if (cyTrainType.Text.ToUpper().Equals(("Endurance").ToUpper()))
            {
                cs.TrainingType = 1;
            }
            else if (cyTrainType.Text.ToUpper().Equals(("Recuperation").ToUpper()))
            {
                cs.TrainingType = 2;
            }
            if(cyComm.Text != "") { 
            cs.Comments = cyComm.Text;
            }

            if (cyBiket.Text.ToUpper().Equals(("RacingBike").ToUpper())) { 
            cs.BikeType = 0;
            } else if (cyBiket.Text.ToUpper().Equals(("IndoorBike").ToUpper()))
            {
                cs.BikeType = 1;
            }
            else if (cyBiket.Text.ToUpper().Equals(("CityBike").ToUpper()))
            {
                cs.BikeType = 2;
            }
            else if (cyBiket.Text.ToUpper().Equals(("MountainBike").ToUpper()))
            {
                cs.BikeType = 3;
            }
            #endregion

            dataEntities.CyclingSessions.Add(cs);
            dataEntities.SaveChanges();
            dataGrid1.Items.Add(cs);


        }

        private void btnDeleteCycle_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
                dataEntities.CyclingSessions.Remove(dataGrid1.SelectedItem as CyclingSession);
                dataGrid1.Items.Remove(dataGrid1.SelectedItem);
                dataEntities.SaveChanges();
        }

        private void btnAddRun_Click(object sender, RoutedEventArgs e)
        {

            RunningSession cs = new RunningSession();
            #region addNew run
            cs.When = DateTime.ParseExact(ruWhen.Text, "yyyy-MM-dd HH:mm tt", null);
            cs.Distance = Convert.ToInt32(ruDist.Text);
            cs.Time = TimeSpan.Parse(cyTime.Text);

            if (ruAvgSpeed.Text != null)
            {
                cs.AverageSpeed = float.Parse(ruAvgSpeed.Text);
            }

            if (ruTrainType.Text.ToUpper().Equals(("Interval").ToUpper()))
            {
                cs.TrainingType = 0;
            }
            else if (ruTrainType.Text.ToUpper().Equals(("Endurance").ToUpper()))
            {
                cs.TrainingType = 1;
            }
            else if (ruTrainType.Text.ToUpper().Equals(("Recuperation").ToUpper()))
            {
                cs.TrainingType = 2;
            }
            if (ruyComm.Text != "")
            {
                cs.Comments = ruyComm.Text;
            }
            
            #endregion

            dataEntities.RunningSessions.Add(cs);
            dataEntities.SaveChanges();
            dataGrid2.Items.Add(cs);

        }

        private void btnDeleteRun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid2.SelectedItem != null)
                dataEntities.RunningSessions.Remove(dataGrid2.SelectedItem as RunningSession);
            dataGrid2.Items.Remove(dataGrid2.SelectedItem);
            dataEntities.SaveChanges();
        }
    }
}
