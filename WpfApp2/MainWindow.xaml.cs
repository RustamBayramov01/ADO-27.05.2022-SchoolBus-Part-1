using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Threading;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        DispatcherTimer dispatcherTimer1 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer2 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer3 = new DispatcherTimer();
        DispatcherTimer dispatcherTimer4 = new DispatcherTimer();

        int incerement = 199;
        int incerementt = 479;
        bool CatagoriBorderVerif = true;
        bool CatagoriBorderVerif2 = false;

        public MainWindow()
        {
            InitializeComponent();
            BorderSelection.Margin = new Thickness(185, 0, 5, 0);
            AddBorder.Margin = new Thickness(0, 0, 500, 0);
            AddNewDriver.Visibility = Visibility.Hidden;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try { DragMove(); }
            catch (Exception) { throw; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CatagoriBorderVerif == false)
            {
                dispatcherTimer1.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer1.Tick += MarginnIncer;
                dispatcherTimer1.Start();

            }
            else
            {

                dispatcherTimer2.Interval = TimeSpan.FromSeconds(0.0005);
                dispatcherTimer2.Tick += MarginnDecr;
                dispatcherTimer2.Start();

            }
        }


        public void MarginnIncer(object sender, EventArgs e)
        {
            incerement++;
            if (incerement != 200) { BorderSelection.Margin = new Thickness(incerement, 0, 0, 0); }
            else
            {
                dispatcherTimer1.Stop();
                CatagoriBorderVerif = true;
                back.Source = new BitmapImage(new Uri("Icon/arrow (1).png", UriKind.Relative));
                BorderSelection.Margin = new Thickness(185, 0, 5, 0);
            }
        }

        public void MarginnDecr(object sender, EventArgs e)
        {
            incerement--;
            if (incerement != 0) { BorderSelection.Margin = new Thickness(incerement, 0, 0, 0); }
            else
            {
                dispatcherTimer2.Stop();
                CatagoriBorderVerif = false;
                back.Source = new BitmapImage(new Uri("Icon/burger-bar.png", UriKind.Relative));
                BorderSelection.Margin = new Thickness(0, 0, 5, 0);


            }
        }



        public void MarginnIncer2(object sender, EventArgs e)
        {
            incerementt++;
            if (incerementt != 480) { AddBorder.Margin = new Thickness(0, 0, incerementt, 0); }
            else
            {
                dispatcherTimer3.Stop();
                CatagoriBorderVerif2 = true;
            }
        }

        public void MarginnDecr2(object sender, EventArgs e)
        {
            incerementt--;
            if (incerementt != 0) { AddBorder.Margin = new Thickness(0, 0, incerementt, 0); }
            else
            {
                dispatcherTimer4.Stop();
                CatagoriBorderVerif2 = false;

            }
        }


        private void NewDrive(object sender, RoutedEventArgs e)
        {
            AddNewDriver.Visibility = Visibility.Visible;
            NewDrivePage newDrivePage = new NewDrivePage();
            BasketFrame.Navigate(newDrivePage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //AddBorder.Margin = new Thickness(0, 0, 0, 0); 480
            if (CatagoriBorderVerif2 == false)
            {
                dispatcherTimer3.Interval = TimeSpan.FromSeconds(0.0001);
                dispatcherTimer3.Tick += MarginnIncer2;
                dispatcherTimer3.Start();

            }
            else
            {

                dispatcherTimer4.Interval = TimeSpan.FromSeconds(0.0001);
                dispatcherTimer4.Tick += MarginnDecr2;
                dispatcherTimer4.Start();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            dispatcherTimer4.Interval = TimeSpan.FromSeconds(0.0001);
            dispatcherTimer4.Tick += MarginnDecr2;
            dispatcherTimer4.Start();
        }
    }
}
