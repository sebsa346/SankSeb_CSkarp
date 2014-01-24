using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SanSebKalaha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        RuleMaster ruleMaster = new RuleMaster();

        public MainWindow()
        {
            InitializeComponent();

            setLabelContexts();

            ruleMaster.preGame();

            board.SelectedIndex = 0;

            Closing += ruleMaster.MainWindowClosing;
                   
        }

        public void setLabelContexts()
        {

            start.DataContext = ruleMaster.gameButton;
            concede.DataContext = ruleMaster.gameButton;

            board.DataContext = ruleMaster.boardOptions;

            displayTurn.DataContext = ruleMaster.playersTurn;
            uName.DataContext = ruleMaster.playersTurn;
            cName.DataContext = ruleMaster.playersTurn;
            gameOver.DataContext = ruleMaster.boardOptions;

            u1Label.DataContext = ruleMaster.marbles;
            u2Label.DataContext = ruleMaster.marbles;
            u3Label.DataContext = ruleMaster.marbles;
            u4Label.DataContext = ruleMaster.marbles;
            u5Label.DataContext = ruleMaster.marbles;
            u6Label.DataContext = ruleMaster.marbles;

            c1Label.DataContext = ruleMaster.marbles;
            c2Label.DataContext = ruleMaster.marbles;
            c3Label.DataContext = ruleMaster.marbles;
            c4Label.DataContext = ruleMaster.marbles;
            c5Label.DataContext = ruleMaster.marbles;
            c6Label.DataContext = ruleMaster.marbles;

            uPoints.DataContext = ruleMaster.marblesUser;
            cPoints.DataContext = ruleMaster.marblesComp;

            u1.DataContext = ruleMaster.availableEllipses;
            u2.DataContext = ruleMaster.availableEllipses;
            u3.DataContext = ruleMaster.availableEllipses;
            u4.DataContext = ruleMaster.availableEllipses;
            u5.DataContext = ruleMaster.availableEllipses;
            u6.DataContext = ruleMaster.availableEllipses;

            c1.DataContext = ruleMaster.availableEllipses;
            c2.DataContext = ruleMaster.availableEllipses;
            c3.DataContext = ruleMaster.availableEllipses;
            c4.DataContext = ruleMaster.availableEllipses;
            c5.DataContext = ruleMaster.availableEllipses;
            c6.DataContext = ruleMaster.availableEllipses;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            setLabelContexts();
            ruleMaster.gameRules(board.SelectedIndex);
        }

        private void ConcedeButton_Click(object sender, RoutedEventArgs e)
        {
            ruleMaster.ConcedeWindow();
       
        }
        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MouseDownEllipse(object sender, MouseButtonEventArgs e)
        {
            ruleMaster.collectEllipseID(sender);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ruleMaster.saveGameToDB();

        }

        private void GetButton_Click(object sender, RoutedEventArgs e)
        {
            Program dbC = new Program();
            dbC.checkForSavedGame();

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Program dbC = new Program();
            dbC.removePreviousGame();

        }
        
    }


}
