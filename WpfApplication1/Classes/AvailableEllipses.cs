using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    class AvailableEllipses : INotifyPropertyChanged
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
                    RaisePropertyChanged("UserEllipsesIsEnabled");
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
                    RaisePropertyChanged("CompEllipsesIsEnabled");
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
