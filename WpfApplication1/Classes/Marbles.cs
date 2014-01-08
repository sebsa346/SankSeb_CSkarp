using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SanSebKalaha
{
    public class Marbles : INotifyPropertyChanged
    {
        private int noMarblesC1 = 0;
        private int noMarblesC2 = 0;
        private int noMarblesC3 = 0;
        private int noMarblesC4 = 0;
        private int noMarblesC5 = 0;
        private int noMarblesC6 = 0;
        private int noMarblesU1 = 0;
        private int noMarblesU2 = 0;
        private int noMarblesU3 = 0;
        private int noMarblesU4 = 0;
        private int noMarblesU5 = 0;
        private int noMarblesU6 = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int MarblesC1
        {
            get { return noMarblesC1; }
            set
            {
                noMarblesC1 = value;
                OnPropertyChanged("MarblesC1");
            }
        }

        public int MarblesC2
        {
            get { return noMarblesC2; }
            set
            {
                noMarblesC2 = value;
                OnPropertyChanged("MarblesC2");
            }
        }

        public int MarblesC3
        {
            get { return noMarblesC3; }
            set
            {
                noMarblesC3 = value;
                OnPropertyChanged("MarblesC3");
            }
        }

        public int MarblesC4
        {
            get { return noMarblesC4; }
            set
            {
                noMarblesC4 = value;
                OnPropertyChanged("MarblesC4");
            }
        }

        public int MarblesC5
        {
            get { return noMarblesC5; }
            set
            {
                noMarblesC5 = value;
                OnPropertyChanged("MarblesC5");
            }
        }

        public int MarblesC6
        {
            get { return noMarblesC6; }
            set
            {
                noMarblesC6 = value;
                OnPropertyChanged("MarblesC6");
            }
        }

        public int MarblesU1
        {
            get { return noMarblesU1; }
            set
            {
                noMarblesU1 = value;
                OnPropertyChanged("MarblesU1");
            }
        }

        public int MarblesU2
        {
            get { return noMarblesU2; }
            set
            {
                noMarblesU2 = value;
                OnPropertyChanged("MarblesU2");
            }
        }

        public int MarblesU3
        {
            get { return noMarblesU3; }
            set
            {
                noMarblesU3 = value;
                OnPropertyChanged("MarblesU3");
            }
        }

        public int MarblesU4
        {
            get { return noMarblesU4; }
            set
            {
                noMarblesU4 = value;
                OnPropertyChanged("MarblesU4");
            }
        }

        public int MarblesU5
        {
            get { return noMarblesU5; }
            set
            {
                noMarblesU5 = value;
                OnPropertyChanged("MarblesU5");
            }
        }

        public int MarblesU6
        {
            get { return noMarblesU6; }
            set
            {
                noMarblesU6 = value;
                OnPropertyChanged("MarblesU6");
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
