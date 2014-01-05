﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SanSebKalaha
{
    public class MarbleC4 : INotifyPropertyChanged
    {
        private int noMarbles = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int MarblesC4
        {
            get { return noMarbles; }
            set { noMarbles = value;
            OnPropertyChanged("MarblesC4");
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

       /* public override string ToString()
        {
            return noMarbles.ToString();
        }*/

    }
}
