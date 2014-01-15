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
                    RaisePropertyChanged("StartButtonIsEnabled");
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
                    RaisePropertyChanged("ConcedeButtonIsEnabled");
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
