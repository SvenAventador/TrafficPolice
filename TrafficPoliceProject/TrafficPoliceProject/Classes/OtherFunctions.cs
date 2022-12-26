using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrafficPoliceProject.Classes
{
    /// <summary>
    /// Валидация объектов.
    /// </summary>
    public static class OtherFunctions
    {
        /// <summary>
        /// Проверка почты на соответствие.
        /// </summary>
        /// <param name="email"> Строка с почтой. </param>
        /// <returns>true - почта введена корректно / 
        ///          false - почта введена не корректно.</returns>
        public static bool EmailRegex(string email)
        {
            var regex = new Regex(@"^[-\w.]+@([A-Za-z0-9][-A-Za-z0-9]+\.)+[A-Za-z]{2,4}$");

            return (regex.IsMatch(email)) ? true
                                          : false;
        }

        /// <summary>
        /// Проверка телефона на соответствие.
        /// </summary>
        /// <param name="phone"> Строка с телефоном. </param>
        /// <returns>true - телефон введен корректно / 
        ///          false - телефон введен не корректно.</returns>
        public static bool PhoneRegex(string phone)
        {
            var regex = new Regex("^((8|\\+7)[\\- ]?)?(\\(?\\d{3}\\)?[\\- ]?)?[\\d\\- ]{7,10}$");

            return (regex.IsMatch(phone)) ? true
                                          : false;
        }
    }
}
