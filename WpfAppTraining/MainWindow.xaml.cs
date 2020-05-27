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
            String x = cyTrainType.Text;
            CyclingSession cs = new CyclingSession();

            cs.When = new DateTime(long.Parse(cyWhen.Text));
            if(cyDist.Text != null) {
                cs.Distance = float.Parse(cyDist.Text);
            };
            cs.Time = new TimeSpan(long.Parse(cyTime.Text));
            if (cyAvgSpeed.Text != null)
            {
                cs.AverageSpeed = float.Parse(cyAvgSpeed.Text); 
            }
            if (cyAvgWat.Text != null)
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
            if(cyComm.Text != null) { 
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


            dataEntities.CyclingSessions.Add(cs);
            dataGrid1.Items.Add(cs);


        }

        private void btnDeleteCycle_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
                dataEntities.CyclingSessions.Remove(dataGrid1.SelectedItem as CyclingSession);
        }

        private void btnAddRun_Click(object sender, RoutedEventArgs e)
        {
            foreach (object item in dataGrid2.Items)
            {


                RunningSession rs = new RunningSession();
               // dataGrid2.Items[dataGrid2.Items.IndexOf(item)].
        //        if (!dataEntities.RunningSessions.Any(p => p.Id == item.Id)) { 
        //        dataEntities.RunningSessions.Add(new RunningSession
        //            (item.When,item.Distance,item.Time,item.AverageSpeed,item.TrainingType,item.co)
        //            );
        //        }
            }

        }

        private void btnDeleteRun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid2.SelectedItem != null)
                dataEntities.RunningSessions.Remove(dataGrid2.SelectedItem as RunningSession);
        }
    }
}
