using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    class ConcedeButton : INotifyPropertyChanged
    {

        private bool buttonIsEnabled = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool ConcedeButtonIsEnabled
        {
            get { return (Boolean)buttonIsEnabled; }
            set
            {
                if (buttonIsEnabled != value)
                {
                    buttonIsEnabled = value;
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
