using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SanSebKalaha
{
    public class MarbleUser : INotifyPropertyChanged
    {
        private int userPoints = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int UserPoints
        {
            get { return userPoints; }
            set
            {
                userPoints = value;
            OnPropertyChanged("UserPoints");
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
