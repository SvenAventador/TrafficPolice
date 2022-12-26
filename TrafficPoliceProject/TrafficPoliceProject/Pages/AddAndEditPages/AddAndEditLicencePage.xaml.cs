using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

namespace TrafficPoliceProject.Pages.AddAndEditPages
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditLicencePage.xaml
    /// </summary>
    public partial class AddAndEditLicencePage : Page
    {
        private Entities.Licences _licences = new Entities.Licences();
        public AddAndEditLicencePage(Entities.Licences licences)
        {
            InitializeComponent();

            if (licences != null)
                _licences = licences;
            DataContext = _licences;
        }

        /// <summary>
        /// Генерация серии.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateSerial_Click(object sender, RoutedEventArgs e)
        {
            serial.Clear();
            var random = new Random();
            var first = random.Next(10, 99);
            var second = random.Next(10, 99);
            serial.Text = $"{first} {second}";
        }

        /// <summary>
        /// Генерация номера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateNumber_Click(object sender, RoutedEventArgs e)
        {
            number.Clear();
            var random = new Random();
            number.Text = random.Next(100000, 999999).ToString();
        }

        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            var error = new StringBuilder();

            if (_licences.LicenceDate > DateTime.Now)
                error.AppendLine("Пожалуйста, не живите в будущем!");
            if (string.IsNullOrEmpty(_licences.LicenceNumber))
                error.AppendLine("Пожалуйста, введите номер лицензии!");
            if (string.IsNullOrEmpty(_licences.LicenceSerial))
                error.AppendLine("Пожалуйста, введите серию лицензии!");
            _licences.ExpireDate = _licences.LicenceDate.AddYears(10);

            var random = new Random();
            _licences.DriverId = random.Next(2, 199);

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(),
                                "Ошибка!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            if (_licences.Id == 0)
            {
                Entities.TrafficPoliceEntities
                            .GetContext()
                            .Licences
                            .Add(_licences);
            }

            try
            {
                Entities.TrafficPoliceEntities
                            .GetContext()
                            .SaveChanges();
                MessageBox.Show("Данные успешно сохранены!",
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                Classes.Manager.MainFrame.GoBack();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());

                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }
        }
    }
}
