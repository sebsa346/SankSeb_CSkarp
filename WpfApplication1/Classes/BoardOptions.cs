using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    public class BoardOptions : INotifyPropertyChanged
    {

        private bool _boardOptionsIsEnabled = true;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool BoardOptionsIsEnabled
        {
            get { return (Boolean)_boardOptionsIsEnabled; }
            set
            {
                if (_boardOptionsIsEnabled != value)
                {
                    _boardOptionsIsEnabled = value;
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
