using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApplication1
{
    public class MarbleU3 : INotifyPropertyChanged
    {
        private int noMarbles = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int MarblesU3
        {
            get { return noMarbles; }
            set { noMarbles = value;
            OnPropertyChanged("MarblesU3");
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
