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
    /// Логика взаимодействия для AddAndEditDriversPage.xaml
    /// </summary>
    public partial class AddAndEditDriversPage : Page
    {
        private Entities.Drivers _drivers = new Entities.Drivers();
        public AddAndEditDriversPage(Entities.Drivers drivers)
        {
            InitializeComponent();

            if (drivers != null)
                _drivers = drivers;
            DataContext = _drivers;
        }

        /// <summary>
        /// Сохранение / изменение данных.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var error = new StringBuilder();

            if (string.IsNullOrEmpty(_drivers.Surname))
                error.AppendLine("Пожалуйста, введите фамилию!");
            if (string.IsNullOrEmpty(_drivers.Name))
                error.AppendLine("Пожалуйста, введите имя!");
            if (string.IsNullOrEmpty(_drivers.Middlename))
                error.AppendLine("Пожалуйста, введите отчество!");

            if (string.IsNullOrEmpty(_drivers.PassportSerial))
                error.AppendLine("Пожалуйста, введите серию паспорта!");
            if (serialTB.Text.Length != 4)
                error.AppendLine("Серия паспорта хранит в себе 4 значения!");
            if (string.IsNullOrEmpty(_drivers.PassportNumber))
                error.AppendLine("Пожалуйста, введите номер паспорта!");
            if (numberTB.Text.Length != 6)
                error.AppendLine("Номер паспорта хранит в себе 6 значения!");

            if (string.IsNullOrEmpty(_drivers.PostCode))
                error.AppendLine("Пожалуйста, введите индекс!");
            if (string.IsNullOrEmpty(_drivers.Address))
                error.AppendLine("Пожалуйста, введите адрес!");
            if (string.IsNullOrEmpty(_drivers.Company))
                error.AppendLine("Пожалуйста, введите название компании!");
            if (string.IsNullOrEmpty(_drivers.JobName))
                error.AppendLine("Пожалуйста, введите должность!");

            if (!(Classes.OtherFunctions.EmailRegex(emailTB.Text)))
                error.AppendLine("Почта введена не корректно!");
            if (!(Classes.OtherFunctions.PhoneRegex(phoneTB.Text)))
                error.AppendLine("Телефон введен не корректно!");

            _drivers.Photo = "gibdd_logo.png";

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString(),
                                "Ошибка!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            if (_drivers.Id == 0)
            {
                Entities.TrafficPoliceEntities
                            .GetContext()
                            .Drivers
                            .Add(_drivers);
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
