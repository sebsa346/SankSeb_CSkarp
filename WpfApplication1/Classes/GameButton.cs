using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    public class GameButton : INotifyPropertyChanged
    {

        private bool startButtonIsEnabled = true;
        private bool concedeButtonIsEnabled = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool StartButtonIsEnabled
        {
            get { return (Boolean)startButtonIsEnabled; }
            set
            {
                if (startButtonIsEnabled != value)
                {
                    startButtonIsEnabled = value;
                    OnPropertyChanged("StartButtonIsEnabled");
                }
            }
        }

        public bool ConcedeButtonIsEnabled
        {
            get { return (Boolean)concedeButtonIsEnabled; }
            set
            {
                if (concedeButtonIsEnabled != value)
                {
                    concedeButtonIsEnabled = value;
                    OnPropertyChanged("ConcedeButtonIsEnabled");
                }
            }
        }

        private void OnPropertyChanged(String property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {

                handler(this, new PropertyChangedEventArgs(property));
            }

        }

    }
}
