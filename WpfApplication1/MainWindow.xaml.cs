using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MarbleU1 marblesU1 = new MarbleU1();
        private MarbleU2 marblesU2 = new MarbleU2();
        private MarbleU3 marblesU3 = new MarbleU3();
        private MarbleU4 marblesU4 = new MarbleU4();
        private MarbleU5 marblesU5 = new MarbleU5();
        private MarbleU6 marblesU6 = new MarbleU6();
        private MarbleC1 marblesC1 = new MarbleC1();
        private MarbleC2 marblesC2 = new MarbleC2();
        private MarbleC3 marblesC3 = new MarbleC3();
        private MarbleC4 marblesC4 = new MarbleC4();
        private MarbleC5 marblesC5 = new MarbleC5();
        private MarbleC6 marblesC6 = new MarbleC6();
        private MarbleUser marblesUser = new MarbleUser();
        private MarbleComp marblesComp = new MarbleComp();

        int[] arrayTest = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public MainWindow()
        {
            InitializeComponent();
            //Marble marbles = new Marble();
            setMarbleValues();
            int[] arrayTest33 = { 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 0 };
            arrayTest = arrayTest33;
            board.Items.Insert(0, "Standard");
            board.Items.Insert(1, "African");
            board.Items.Insert(2, "Colombian");

            board.SelectedIndex = 0;

            //if(board.SelectedIndex == someIntValue){} Använd för att se vad användaren valde

            // 6 objekt i varje
            /*List<Marble> userMarbleList = new List<Marble>();
            userMarbleList.Add(marbles);

            List<Marble> compMarbleList = new List<Marble>();
            compMarbleList.Add(marbles);*/

           //arrayTest = { 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 0 }; // Ett bo, 6 skålar, ett bo, 6 skålar
         
        }

        private void setMarbleValues()
        {
            marblesU1.MarblesU1 = arrayTest[0];
            marblesU2.MarblesU2 = arrayTest[1];
            marblesU3.MarblesU3 = arrayTest[2];
            marblesU4.MarblesU4 = arrayTest[3];
            marblesU5.MarblesU5 = arrayTest[4];
            marblesU6.MarblesU6 = arrayTest[5];
            marblesC1.MarblesC1 = arrayTest[12];
            marblesC2.MarblesC2 = arrayTest[11];
            marblesC3.MarblesC3 = arrayTest[10];
            marblesC4.MarblesC4 = arrayTest[9];
            marblesC5.MarblesC5 = arrayTest[8];
            marblesC6.MarblesC6 = arrayTest[7];
            marblesUser.UserPoints = arrayTest[6];
            marblesComp.CompPoints = arrayTest[13];

            u1Label.DataContext = marblesU1;
            u2Label.DataContext = marblesU2;
            u3Label.DataContext = marblesU3;
            u4Label.DataContext = marblesU4;
            u5Label.DataContext = marblesU5;
            u6Label.DataContext = marblesU6;

            c1Label.DataContext = marblesC1;
            c2Label.DataContext = marblesC2;
            c3Label.DataContext = marblesC3;
            c4Label.DataContext = marblesC4;
            c5Label.DataContext = marblesC5;
            c6Label.DataContext = marblesC6;

            uPoints.DataContext = marblesUser;
            cPoints.DataContext = marblesComp;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            marblesU1.MarblesU1 = arrayTest[0];
            marblesU2.MarblesU2 = arrayTest[1];
            marblesU3.MarblesU3 = arrayTest[2];
            marblesU4.MarblesU4 = arrayTest[3];
            marblesU5.MarblesU5 = arrayTest[4];
            marblesU6.MarblesU6 = arrayTest[5];
            marblesC1.MarblesC1 = arrayTest[12];
            marblesC2.MarblesC2 = arrayTest[11];
            marblesC3.MarblesC3 = arrayTest[10];
            marblesC4.MarblesC4 = arrayTest[9];
            marblesC5.MarblesC5 = arrayTest[8];
            marblesC6.MarblesC6 = arrayTest[7];
            marblesUser.UserPoints = arrayTest[6];
            marblesComp.CompPoints = arrayTest[13];
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Är du säker på att du vill ge upp?", "Ge upp?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes: marblesU1.MarblesU1 = 0; break;
                case MessageBoxResult.No: break;
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            // Klickar på positionen närmast boet (5)
            int[] arrayTest2 = { 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 0 };
            int i = 5;
            int moveTheseMarbles = arrayTest[i];
            arrayTest[i] = 0;
            Console.WriteLine("Tjena" + moveTheseMarbles);
            int ii = 0;
            while (ii < moveTheseMarbles)
            {
                ii++;
                int cupPosition = i + ii;
                Console.WriteLine("Tutu" + ii);
                if (cupPosition >= 14)
                {
                    cupPosition = 0;
                    cupPosition = ii;
                }
                Console.WriteLine("Hola" + cupPosition);
                arrayTest[cupPosition] = arrayTest[cupPosition] + 1;
            }
            for (int ipa = 0; ipa < arrayTest.Length; ipa++)
            {
                Console.WriteLine(arrayTest[ipa]);
            }
            setMarbleValues();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
