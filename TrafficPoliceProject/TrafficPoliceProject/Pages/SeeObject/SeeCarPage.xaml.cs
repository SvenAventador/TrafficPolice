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
    /// Логика взаимодействия для SeeCarPage.xaml
    /// </summary>
    public partial class SeeCarPage : Page
    {
        /// <summary>
        /// Критерий поиска.
        /// </summary>
        private static string _findOther;

        /// <summary>
        /// Лист с водителями.
        /// </summary>
        private static List<Entities.Car> _cars = new List<Entities.Car>();

        public SeeCarPage()
        {
            InitializeComponent();
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
                _cars = Entities.TrafficPoliceEntities
                                    .GetContext()
                                    .Car
                                    .OrderBy(x => x.VIN)
                                    .ToList();

                _cars = _cars.OrderBy(x => x.VIN)
                            .Where(x => (x.VIN.ToLower().Contains(_findOther)) ||
                                        (x.Manufacturer.ToLower().Contains(_findOther)) ||
                                        (x.Model.ToLower().Contains(_findOther)) ||
                                        (x.Year.ToString().ToLower().Contains(_findOther)) ||
                                        (x.Year.ToString().ToLower().Contains(_findOther)) ||
                                        (x.EngineType.EngineTypeName.ToLower().Contains(_findOther)) ||
                                        (x.TypeOfDrive.TypeOfDrive1.ToLower().Contains(_findOther)) ||
                                        (x.Color.ColorCode.ToLower().Contains(_findOther)))
                            .ToList();

                DBGridModel.ItemsSource = _cars;
                GC.Collect();
            }
            else
                RefreshData();
        }

        /// <summary>
        /// Изменение данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditPages.AddAndEditCarPage(
                                                        (sender as Button).DataContext as Entities.Car));
            GC.Collect();
        }

        /// <summary>
        /// Добавление данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditPages.AddAndEditCarPage(null));
            GC.Collect();
        }

        /// <summary>
        /// Обновление данных после изменения.
        /// </summary>
        private void RefreshData()
        {
            DBGridModel.ItemsSource = Entities.TrafficPoliceEntities
                                    .GetContext()
                                    .Car
                                    .OrderBy(x => x.VIN)
                                    .ToList();
        }

        /// <summary>
        /// Удаление данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DBGridModel_KeyDown(object sender, KeyEventArgs e)
        {
            var deleteElement = DBGridModel
                                    .SelectedItems
                                    .Cast<Entities.Car>()
                                    .ToList();

            if (e.Key == Key.Delete)
                if ((MessageBox.Show($"Вы уверены, что хотите удалить {deleteElement.Count} элемента(-ов)?",
                                     "Внимание!",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question)) == MessageBoxResult.Yes)
                {
                    Entities.TrafficPoliceEntities
                                .GetContext()
                                .Car
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
