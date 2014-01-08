using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    class StartButton : INotifyPropertyChanged
    {

        private bool buttonIsEnabled = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool StartButtonIsEnabled
        {
            get { return (Boolean)buttonIsEnabled; }
            set
            {
                if (buttonIsEnabled != value)
                {
                    buttonIsEnabled = value;
                    RaisePropertyChanged("StartButtonIsEnabled");
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
