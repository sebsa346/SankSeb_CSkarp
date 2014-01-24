using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    public class BoardOptions : INotifyPropertyChanged
    {

        private bool _boardOptionsIsEnabled = true;
        private string _announcement = "";
        private string _color = "Black";

        public event PropertyChangedEventHandler PropertyChanged;

        public bool BoardOptionsIsEnabled
        {
            get { return (Boolean)_boardOptionsIsEnabled; }
            set
            {
                if (_boardOptionsIsEnabled != value)
                {
                    _boardOptionsIsEnabled = value;
                    OnPropertyChanged("BoardOptionsIsEnabled");
                }
            }
        }

        public string Announcement
        {
            get { return _announcement; }
            set
            {
                if (_announcement != value)
                {
                    _announcement = value;
                    OnPropertyChanged("Announcement");
                }
            }
        }

        public string Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    OnPropertyChanged("Color");
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
