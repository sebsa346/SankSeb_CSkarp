using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    public class BoardOption : INotifyPropertyChanged
    {
        private string chosenBoard = "Standard";

        public event PropertyChangedEventHandler PropertyChanged;

        public string BoardOptions
        {
            get { return chosenBoard;  }
            set { chosenBoard = value;
            OnPropertyChanged("BoardOptions"); 
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
