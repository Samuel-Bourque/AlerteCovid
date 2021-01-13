using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlerteCovid_Affaires
{
    public class InfoRegion : INotifyPropertyChanged
    {
        private string _nomRegion;
        private int _nbEclosions;

        public string NomRegion { get => _nomRegion; set => _nomRegion = value; }

        public int NbEclosions
        {
            get => _nbEclosions;
            set { _nbEclosions = value;
                this.notifier("NbEclosions");
                this.notifier("CouleurEtatAlerte");
                this.notifier("NomEtatAlerte");
            }
        }
        public string CouleurEtatAlerte
        {
            get
            {
                if (_nbEclosions <= 25)
                {
                    return "LightGreen";
                }
                else if (_nbEclosions <= 50)
                {
                    return "Yellow";
                }
                else if (_nbEclosions <= 100)
                {
                    return "Orange";
                }
                else return "Red";
            }
        }
        public string NomEtatAlerte
        {
            get
            {
                if (_nbEclosions <= 25)
                {
                    return ("Vigilante");
                }
                else
                if (_nbEclosions <= 50)
                {
                    return ("Préalerte");
                }
                else
                if (_nbEclosions <= 100)
                {
                    return ("Alerte modérée");
                }
                else
                    return ("Alerte maximale");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void notifier(string propriete) {
                PropertyChanged(this, new PropertyChangedEventArgs(propriete));
        }      
        
        public InfoRegion(string nom, int nbNouveauxCas)
        {
            _nomRegion = nom;
            _nbEclosions = nbNouveauxCas;
        }
    }
}
