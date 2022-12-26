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
    /// Логика взаимодействия для SeeRoadAccidentPage.xaml
    /// </summary>
    public partial class SeeRoadAccidentPage : Page
    {
        public SeeRoadAccidentPage()
        {
            InitializeComponent();
            RefreshData();
        }

        /// <summary>
        /// Зарегистрировать ДТП.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDataBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditPages.AddRoadAccident());
        }

        /// <summary>
        /// Обновление данных.
        /// </summary>
        private void RefreshData()
        {
            DBGridModel.ItemsSource = Entities.TrafficPoliceEntities
                                    .GetContext()
                                    .RoadAccident
                                    .OrderBy(x => x.Id)
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
                                    .Cast<Entities.RoadAccident>()
                                    .ToList();

            if (e.Key == Key.Delete)
                if ((MessageBox.Show($"Вы уверены, что хотите удалить {deleteElement.Count} элемента(-ов)?",
                                     "Внимание!",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question)) == MessageBoxResult.Yes)
                {
                    Entities.TrafficPoliceEntities
                                .GetContext()
                                .RoadAccident
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
