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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TrafficPoliceProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для InspectorMenuWindow.xaml
    /// </summary>
    public partial class InspectorMenuWindow : Window
    {
        public InspectorMenuWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.SeeObject.SeeDriverPage());
            Classes.Manager.MainFrame = MainFrame;
            //var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(61) };
            //timer.Tick += delegate
            //{
            //    timer.Stop();
            //    MessageBox.Show("До скорых встреч, товарищ инспектор!",
            //                    "Внимание!",
            //                    MessageBoxButton.OK,
            //                    MessageBoxImage.Information);
            //    new MainWindow().Show();
            //    this.Hide();
            //    timer.Start();
            //};
            //timer.Start();
            //InputManager.Current.PostProcessInput += delegate (object s, ProcessInputEventArgs r)
            //{
            //    if ((r.StagingItem.Input is MouseButtonEventArgs) ||
            //        (r.StagingItem.Input is KeyEventArgs))
            //        timer.Interval = TimeSpan.FromSeconds(61);
            //};
        }

        /// <summary>
        /// Переход назад.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
            else
            {
                new MainWindow().Show();
                this.Hide();
            }
        }

        /// <summary>
        /// Визуализация кнопки перехода.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MainFrame.CanGoBack)          
                BtnBack.Content = "Назад";          
            else     
                BtnBack.Content = "Выход";
        }

        /// <summary>
        /// Переход на страницу Driver.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DriversBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SeeObject.SeeDriverPage());
        }

        /// <summary>
        /// Переход на страницу Licences.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LicencesBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SeeObject.SeeLicencesPage());
        }

        /// <summary>
        /// Переход на страницу Car.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SeeObject.SeeCarPage());
        }

        /// <summary>
        /// Переход на страницу с ДТП.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoadAccidentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.SeeObject.SeeRoadAccidentPage());
        }
    }
}
