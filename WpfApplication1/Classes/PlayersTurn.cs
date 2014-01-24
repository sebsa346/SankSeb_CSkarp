using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha.Classes
{
    public class PlayersTurn : INotifyPropertyChanged
    {

        private string _whosTurn = "";
        private string _color = "";

        private string _player1Name = "";
        private string _player2Name = "";

        public event PropertyChangedEventHandler PropertyChanged;

        public string WhosTurn
        {
            get { return _whosTurn; }
            set
            {
                if (_whosTurn != value)
                {
                    _whosTurn = value;
                    OnPropertyChanged("WhosTurn");
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

        public string Player1Name
        {
            get { return _player1Name; }
            set
            {
                _player1Name = value;               
            }
        }

        public string Player2Name
        {
            get { return _player2Name; }
            set
            {
                _player2Name = value;
            }
        }

        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

        }

    }
}
