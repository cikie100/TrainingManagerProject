using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            List<CyclingSession> cyclings = new List<CyclingSession>();

            foreach (CyclingSession sess in dataEntities.CyclingSessions)
            {
                dataGrid1.Items.Add(sess);
            }


            ///////////////////////////////////////////////////
            //Voor Running
            List<RunningSession> runings = new List<RunningSession>();

            foreach (RunningSession rsess in dataEntities.RunningSessions)
            {
                runings.Add(rsess);
            }
            dataGrid2.ItemsSource = runings.ToList();
        }


        private void btnAddCycle_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (CyclingSession cs in dataGrid1.Items)
            {

               // CyclingSession x = new CyclingSession(cs.ToString().);
                if (! dataEntities.CyclingSessions.Contains(cs)){
                 dataEntities.CyclingSessions.Add(cs);
                }
            }
        }

        private void btnDeleteCycle_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedItem != null)
                dataEntities.CyclingSessions.Remove(dataGrid1.SelectedItem as CyclingSession);
        }

        private void btnAddRun_Click(object sender, RoutedEventArgs e)
        {
        //    foreach (RunningSession item in dataGrid2.Items)
        //    {
        //        if (!dataEntities.RunningSessions.Any(p => p.Id == item.Id)) { 
        //        dataEntities.RunningSessions.Add(new RunningSession
        //            (item.When,item.Distance,item.Time,item.AverageSpeed,item.TrainingType,item.co)
        //            );
        //        }
        //    }

        }

        private void btnDeleteRun_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid2.SelectedItem != null)
                dataEntities.RunningSessions.Remove(dataGrid2.SelectedItem as RunningSession);
        }
    }
}
