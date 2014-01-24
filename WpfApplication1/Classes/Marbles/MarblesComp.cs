using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SanSebKalaha
{
    public class MarbleComp : INotifyPropertyChanged
    {
        private int compPoints = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int CompPoints
        {
            get { return compPoints; }
            set
            {
                compPoints = value;
                OnPropertyChanged("CompPoints");
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
