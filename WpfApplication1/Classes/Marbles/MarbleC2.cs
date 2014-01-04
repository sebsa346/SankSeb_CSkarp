using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApplication1
{
    public class MarbleC2 : INotifyPropertyChanged
    {
        private int noMarbles = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int MarblesC2
        {
            get { return noMarbles; }
            set { noMarbles = value;
            OnPropertyChanged("MarblesC2");
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
