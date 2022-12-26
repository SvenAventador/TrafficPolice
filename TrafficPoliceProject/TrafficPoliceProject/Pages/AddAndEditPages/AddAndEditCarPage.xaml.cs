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
    /// Логика взаимодействия для AddAndEditCarPage.xaml
    /// </summary>
    public partial class AddAndEditCarPage : Page
    {
        private static Entities.Car _cars = new Entities.Car();
        public AddAndEditCarPage(Entities.Car car)
        {
            InitializeComponent();
            if (car != null)
                _cars = car;
            DataContext = _cars;

            colorTB.ItemsSource = Entities.TrafficPoliceEntities
                                            .GetContext()
                                            .Color
                                            .OrderBy(x => x.Name)
                                            .ToList();
            typeTB.ItemsSource = Entities.TrafficPoliceEntities
                                            .GetContext()
                                            .TypeOfDrive
                                            .OrderBy(x => x.TypeOfDrive1)
                                            .ToList();
            engineTB.ItemsSource = Entities.TrafficPoliceEntities
                                            .GetContext()
                                            .EngineType
                                            .OrderBy(x => x.EngineTypeName)
                                            .ToList();
        }

        /// <summary>
        /// Сохранение данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDataBtn_Click_1(object sender, RoutedEventArgs e)
        {
            var error = new StringBuilder();

            if (string.IsNullOrEmpty(_cars.VIN))
                error.AppendLine("Пожалуйста, введите VIN номер!");
            if (string.IsNullOrEmpty(_cars.Manufacturer))
                error.AppendLine("Пожалуйста, введите марку машины!");
            if (string.IsNullOrEmpty(_cars.Model))
                error.AppendLine("Пожалуйста, введите модель машины!");
            if (string.IsNullOrEmpty(_cars.Year.ToString()))
                error.AppendLine("Пожалуйста, введите год машины!");
            if (string.IsNullOrEmpty(_cars.Weight.ToString()))
                error.AppendLine("Пожалуйста, введите вес машины!");
            if (_cars.Color.ColorCode == null)
                error.AppendLine("Пожалуйста, введите цвет машины!");
            if (_cars.EngineType.EngineTypeName == null)
                error.AppendLine("Пожалуйста, введите тип двигателя машины!");
            if (_cars.TypeOfDrive.TypeOfDrive1 == null)
                error.AppendLine("Пожалуйста, введите тип машины!");

            var random = new Random();
            var firstValue = (char)random.Next('A', 'Z' + 1);
            var secondValue = random.Next(100, 999);
            var thirdValue = "";

            for (var i = 0; i < 3; i++)
            {
                thirdValue += (char)random.Next('A', 'Z' + 1);
            }

            var number = firstValue + secondValue + thirdValue;
            _cars.CarNumber = number;

            MessageBox.Show($"Данному водителю присвоен номер: {number}",
                             "Внимание!",
                             MessageBoxButton.OK,
                             MessageBoxImage.Information);

            _cars.DriverId = random.Next(2, 198);

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(),
                                "Ошибка!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            if (_cars.Id == 0)
            {
                Entities.TrafficPoliceEntities
                            .GetContext()
                            .Car
                            .Add(_cars);
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
