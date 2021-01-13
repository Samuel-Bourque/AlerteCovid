using AlerteCovid_Affaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlerteCovid_UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<InfoRegion> Regions { get; }
        private Random _random;

        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
            Regions = new List<InfoRegion>() {
              new InfoRegion("01- Bas Saint-Laurent", _random.Next(1,150)),
              new InfoRegion("03- Capitale Nationale", _random.Next(1,150)),
              new InfoRegion("08- Montréal", _random.Next(1,150)),
              new InfoRegion("12- Chaudière-Appalaches", _random.Next(1,150))
            };

            grilleAlerteCovid.DataContext = this;

            Timer chrono = new Timer();
            chrono.Interval = 2000;
            chrono.Enabled = true;
            chrono.Elapsed += new ElapsedEventHandler(genererNouvelleValeur);
        }
        private void genererNouvelleValeur(object sender, ElapsedEventArgs e)
        {
            foreach (InfoRegion uneRegion in Regions)
                uneRegion.NbEclosions = _random.Next(1, 150);
        }
    }
}
