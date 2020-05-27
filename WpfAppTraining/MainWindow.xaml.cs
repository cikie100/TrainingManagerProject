using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppTraining
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        trainingDBEntities dataEntities = new trainingDBEntities();

        public MainWindow()
        {
            InitializeComponent();

            //Voor Cycling
            List<CyclingSession> cyclings = new List<CyclingSession>();

            foreach (CyclingSession sess in dataEntities.CyclingSessions)
            {
                cyclings.Add(sess);
            }

            dataGrid1.ItemsSource = cyclings.ToList();

            ///////////////////////////////////////////////////
            //Voor Running
            List<RunningSession> runings = new List<RunningSession>();

            foreach (RunningSession rsess in dataEntities.RunningSessions)
            {
                runings.Add(rsess);
            }
            dataGrid2.ItemsSource = runings.ToList();
        }

    }
}
