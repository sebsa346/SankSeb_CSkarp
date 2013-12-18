﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApplication1
{
    public class Marble : INotifyPropertyChanged
    {
        private int noMarbles = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Marbles
        {
            get { return noMarbles; }
            set { noMarbles = value;
            OnPropertyChanged("Marbles");
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
