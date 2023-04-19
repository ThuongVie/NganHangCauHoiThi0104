using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DTO
{
    public static class Validator
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            var pattern = @"^0\d{9,10}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }

        public static bool IsValidEmail(string email)
        {
            var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static bool IsNumber(string number)
        {
            var pattern = @"^[1-9]\d*(?:\.\d+)?$";
            var regex = new Regex(pattern);
            return regex.IsMatch(number);
        }
        public static bool IsMaHocPhan(string maHocPhan)
        {
            var pattern = @"^\d{12}$";
            var regex = new Regex(pattern);
            return regex.IsMatch(maHocPhan);
        }
    }
}
