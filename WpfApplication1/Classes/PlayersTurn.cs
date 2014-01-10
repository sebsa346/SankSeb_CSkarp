using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    class PlayersTurn : INotifyPropertyChanged
    {

        private string _whosTurn = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string WhosTurn
        {
            get { return _whosTurn; }
            set
            {
                if (_whosTurn != value)
                {
                    _whosTurn = value;
                    RaisePropertyChanged("WhosTurn");
                }
            }
        }

        private void RaisePropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

        }

    }
}
