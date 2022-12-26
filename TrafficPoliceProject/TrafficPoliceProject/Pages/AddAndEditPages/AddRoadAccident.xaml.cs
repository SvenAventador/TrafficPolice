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
    /// Логика взаимодействия для AddRoadAccident.xaml
    /// </summary>
    public partial class AddRoadAccident : Page
    {
        private Entities.RoadAccident _roadAccident = new Entities.RoadAccident();
        public AddRoadAccident()
        {
            InitializeComponent();
        }

        private void SaveDataBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = new StringBuilder();
            if (string.IsNullOrEmpty(_roadAccident.CrimeScene))
                error.AppendLine("Пожалуйста, введите место происшествия!");
            if (_roadAccident.Classification.ClassificationName == null)
                error.AppendLine("Пожалуйста, выберите классификацию ДТП!");
            if (_roadAccident.NumberOfVictims < 1)
                error.AppendLine("Простите, но количество не может быть меньше 1!");

            var random = new Random();
            _roadAccident.DriverId = random.Next(2, 198);
            _roadAccident.LicenceId = random.Next(2, 198);
            _roadAccident.DateOfIncident = DateTime.Now;
            _roadAccident.TimeOfIncident = DateTime.Now;

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(),
                                "Ошибка!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            if (_roadAccident.Id == 0)
            {
                Entities.TrafficPoliceEntities
                            .GetContext()
                            .RoadAccident
                            .Add(_roadAccident);
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
