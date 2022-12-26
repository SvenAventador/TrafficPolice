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
using System.Windows.Threading;

namespace TrafficPoliceProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Поля

        /// <summary>
        /// Количество нажатий на кнопку.
        /// </summary>
        private static int _countOfInput = 0;

        /// <summary>
        /// Время отсчета.
        /// </summary>
        private static int _time = 60;

        /// <summary>
        /// Подключение таймера.
        /// </summary>
        private static DispatcherTimer _Timer;

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            BlockTimeTB.Visibility = Visibility.Hidden;

            //var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(61) };
            //timer.Tick += delegate
            //{
            //    timer.Stop();
            //    MessageBox.Show("До скорых встреч, товарищ инспектор!",
            //                    "Внимание!",
            //                    MessageBoxButton.OK,
            //                    MessageBoxImage.Information);
            //    Application.Current.Shutdown(0);
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

        #region Адаптация функции Watermark

        /// <summary>
        /// Получение фокуса над элементом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (loginTB.Text == "Поле для ввода логина...")
            {
                loginTB.Foreground = new SolidColorBrush(Colors.LightGray);
                loginTB.Text = "";
            }
        }

        /// <summary>
        /// Получение фокуса над элементом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordTB_GotFocus(object sender, RoutedEventArgs e)
        {
            if (passwordTB.Text == "Поле для ввода пароля...")
            {
                passwordTB.Foreground = new SolidColorBrush(Colors.LightGray);
                passwordTB.Text = "";
            }
        }

        /// <summary>
        /// Потеря фокуса над элементом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(loginTB.Text))
            {
                loginTB.Foreground = new SolidColorBrush(Colors.LightGray);
                loginTB.Text = "Поле для ввода логина...";
            }
            if (!(string.IsNullOrEmpty(loginTB.Text)) ||
                (loginTB.Text != "Поле для ввода логина..."))
            {
                loginTB.Foreground = new SolidColorBrush(Colors.Black);
                loginTB.Text = loginTB.Text;
            }
        }

        /// <summary>
        /// Потеря фокуса над элементом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordTB.Text))
            {
                passwordTB.Foreground = new SolidColorBrush(Colors.LightGray);
                passwordTB.Text = "Поле для ввода логина...";
            }
            if (!(string.IsNullOrEmpty(passwordTB.Text)) ||
                (passwordTB.Text != "Поле для ввода логина..."))
            {
                passwordTB.Foreground = new SolidColorBrush(Colors.Black);
                passwordTB.Text = loginTB.Text;
            }
        }

        #endregion

        /// <summary>
        /// Вход в систему.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEntry_Click(object sender, RoutedEventArgs e)
        {
            _countOfInput++;

            if (_countOfInput > 3)
            {
                BlockTimeTB.Visibility = Visibility.Visible;
                BtnEntry.IsEnabled = false;
                _Timer = new DispatcherTimer();
                _Timer.Interval = _Timer.Interval = new TimeSpan(0, 0, 1);
                _Timer.Tick += Timer_Tick;
                _Timer.Start();
            }

            var login = loginTB.Text;
            var password = passwordTB.Text;

            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Пожалуйста, введите логин!",
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите пароль!",
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            if (login != password)
            {
                MessageBox.Show("Логин и пароль должны совпадать!",
                                "Внимание!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            using (var db = new Entities.TrafficPoliceEntities())
            {
                foreach (var item in db.Inspector)
                {
                    if ((login == item.LoginInspector) &&
                        (password == item.PasswordInspector))
                    {
                        MessageBox.Show($"Добро пожаловать, {login}",
                                        "Внимание!",
                                        MessageBoxButton.OK,
                                        MessageBoxImage.Information);
                        new Windows.InspectorMenuWindow().Show();
                        this.Hide();
                        return;
                    }
                }
                MessageBox.Show("Неудачная попытка входа.",
                                "Ошибка!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }
        }

        /// <summary>
        /// Работа таймера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_time != 0)
            {
                BlockTimeTB.Text = $"Время блокировки: {string.Format("00:0{0}:{1}", _time / 60, _time % 60)}";
                _time--;
            }
            else
            {
                _Timer.Stop();
                BlockTimeTB.Visibility = Visibility.Hidden;
                BtnEntry.IsEnabled = true;
                _countOfInput = 0;
                _time = 60;
            }
        }

    }
}
