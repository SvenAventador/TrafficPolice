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
    /// Логика взаимодействия для SeeLicencesPage.xaml
    /// </summary>
    public partial class SeeLicencesPage : Page
    {
        public SeeLicencesPage()
        {
            InitializeComponent();
            RefreshData();
        }

        /// <summary>
        /// Изменение данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditPages.AddAndEditLicencePage(
                                                         (sender as Button).DataContext as Entities.Licences));
        }

        /// <summary>
        /// Добавление данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDataBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.AddAndEditPages.AddAndEditLicencePage(null));
        }

        /// <summary>
        /// Просмотр определенного пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SeeDriverBtn_Click(object sender, RoutedEventArgs e)
        {
            Classes.Manager.MainFrame.Navigate(new Pages.SeeObject.SeeDriverPage(
                                                        (sender as Button).DataContext as Entities.Licences));
        }

        /// <summary>
        /// Обновление данных.
        /// </summary>
        private void RefreshData()
        {
            DBGridModel.ItemsSource = Entities.TrafficPoliceEntities
                                                .GetContext()
                                                .Licences
                                                .OrderBy(x => x.LicenceNumber)
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
                                    .Cast<Entities.Licences>()
                                    .ToList();

            if (e.Key == Key.Delete)
                if ((MessageBox.Show($"Вы уверены, что хотите удалить {deleteElement.Count} элемента(-ов)?",
                                     "Внимание!",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Question)) == MessageBoxResult.Yes)
                {
                    Entities.TrafficPoliceEntities
                                .GetContext()
                                .Licences
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
