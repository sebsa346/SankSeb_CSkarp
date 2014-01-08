using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    class BoardOptions : INotifyPropertyChanged
    {

        private bool boardOptionsIsEnabled = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool BoardOptionsIsEnabled
        {
            get { return (Boolean)boardOptionsIsEnabled; }
            set
            {
                if (boardOptionsIsEnabled != value)
                {
                    boardOptionsIsEnabled = value;
                    RaisePropertyChanged("BoardOptionsIsEnabled");
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
