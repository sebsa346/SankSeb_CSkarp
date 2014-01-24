using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    public class AvailableEllipses : INotifyPropertyChanged
    {

        private bool _userEllipsesIsEnabled = false;
        private bool _compEllipsesIsEnabled = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool UserEllipsesIsEnabled
        {
            get { return (Boolean)_userEllipsesIsEnabled; }
            set
            {
                if (_userEllipsesIsEnabled != value)
                {
                    _userEllipsesIsEnabled = value;
                    OnPropertyChanged("UserEllipsesIsEnabled");
                }
            }
        }

        public bool CompEllipsesIsEnabled
        {
            get { return (Boolean)_compEllipsesIsEnabled; }
            set
            {
                if (_compEllipsesIsEnabled != value)
                {
                    _compEllipsesIsEnabled = value;
                    OnPropertyChanged("CompEllipsesIsEnabled");
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
