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

namespace TrafficPoliceProject.Pages.SeeObject
{
    /// <summary>
    /// Логика взаимодействия для SeeDriverPage.xaml
    /// </summary>
    public partial class SeeDriverPage : Page
    {
        /// <summary>
        /// Критерий поиска.
        /// </summary>
        private static string _findOther;

        /// <summary>
        /// Лист с водителями.
        /// </summary>
        private static List<Entities.Drivers> _drivers = new List<Entities.Drivers>();

        public SeeDriverPage(Entities.Licences licences = null)
        {
            InitializeComponent();
            if (licences != null)
            {
                SearchDataTB.Visibility = Visibility.Hidden;
                Search.Visibility = Visibility.Hidden;
                var currentDrive = Entities.TrafficPoliceEntities
                                            .GetContext()
                                            .Drivers
                                            .OrderBy(x => x.Name).ToList();
                currentDrive = currentDrive.Where(x => x.Licences.ToString().Equals(licences.Id.ToString())).ToList();
                ListDrivers.ItemsSource = currentDrive;
            }

            RefreshData();
        }

        /// <summary>
        /// Сортировка.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchDataTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            GC.Collect();
            _findOther = SearchDataTB.Text.ToLower();

            if (!(string.IsNullOrEmpty(_findOther)))
            {
                _drivers = Entities.TrafficPoliceEntities
                                    .GetContext()
                                    .Drivers
                                    .OrderBy(x => x.Name)
                                    .ToList();

                _drivers = _drivers.OrderBy(x => x.Name)
                            .Where(x => (x.Surname.ToLower().Contains(_findOther)) ||
                                        (x.Name.ToLower().Contains(_findOther)) ||
                                        (x.Middlename.ToLower().Contains(_findOther)) ||
                                        (x.PassportSerial.ToLower().Contains(_findOther)) ||
                                        (x.PassportNumber.ToLower().Contains(_findOther)) ||
                                        (x.PostCode.ToLower().Contains(_findOther)) ||
                                        (x.Address.ToLower().Contains(_findOther)) ||
                                        (x.Company.ToLower().Contains(_findOther)) ||
                                        (x.JobName.ToLower().Contains(_findOther)) ||
                                        (x.Phone.ToLower().Contains(_findOther)) ||
                                        (x.Email.ToLower().Contains(_findOther)))
                            .ToList();

                ListDrivers.ItemsSource = _drivers;
                GC.Collect();
            }
            else
                RefreshData();
        }

        /// <summary>
        /// Добавление данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditPages
                                                            .AddAndEditDriversPage
                                                            (null));
        }

        /// <summary>
        /// Изменение данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditPages
                                                            .AddAndEditDriversPage
                                                            ((sender as Button).DataContext as Entities.Drivers));
        }

        /// <summary>
        /// Удаление элемента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListDrivers_KeyDown(object sender, KeyEventArgs e)
        {
            GC.Collect();
            var deleteElement = ListDrivers
                                    .SelectedItems
                                    .Cast<Entities.Drivers>()
                                    .ToList();

            if (e.Key == Key.Delete)
                if ((MessageBox.Show("Вы уверены, что хотите удалить данного водителя?",
                                     "Внимание!",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question)) == MessageBoxResult.Yes)
                {
                    Entities.TrafficPoliceEntities
                                .GetContext()
                                .Drivers
                                .RemoveRange(deleteElement);
                    Entities.TrafficPoliceEntities
                                .GetContext()
                                .SaveChanges();
                    MessageBox.Show("Информация успешно сохранена.",
                                    "Внимание!",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                    RefreshData();

                }
            GC.Collect();
        }

        /// <summary>
        /// Обновление данных после изменения.
        /// </summary>
        private void RefreshData()
        {
            ListDrivers.ItemsSource = Entities.TrafficPoliceEntities
                                    .GetContext()
                                    .Drivers
                                    .OrderBy(x => x.Name)
                                    .ToList();
        }

        /// <summary>
        /// Загрузчик.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }
    }
}
