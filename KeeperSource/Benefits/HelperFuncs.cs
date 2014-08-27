using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;


namespace KeeperRichClient.Modules.Benefits
{
    public static class HelperFuncs
    {

        public static DateTime NextMonthStart(DateTime Arg)
        {
            return new DateTime(Arg.Year, Arg.Month, 1).AddMonths(1);
        }

        public static DateTime ThisMonthEnd(DateTime Arg)
        {
            return NextMonthStart(Arg).AddDays(-1);
        }


        public static bool IsPeselValid(string ArgPesel)
        {
            int[] multipliers = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            try
            {
                if (ArgPesel.Length == 11)
                {
                    int sum = 0;
                    for (int i = 0; i < multipliers.Length; i++)
                    {
                        sum += multipliers[i] * int.Parse(ArgPesel[i].ToString());
                    }
                    int reszta = sum % 10;
                    if (reszta != 0) reszta = 10 - reszta;
                    return (reszta.ToString() == ArgPesel[10].ToString());
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                //throw new ArgumentException("Wrong PESEL length);
                return false;
            }
        }
        public static string GetYearFromPesel(string ArgPesel)
        {
            if (ArgPesel == null) return string.Empty;

            int _PeselYearPrefix = Convert.ToInt32(ArgPesel.Substring(2, 2));
            int _PeselMonth = Convert.ToInt32(ArgPesel.Substring(0, 2));
            string _Result;

            if (_PeselYearPrefix > 80)
                _Result = "18" + (_PeselMonth - 80).ToString();
            else if (_PeselYearPrefix > 60)
                _Result = "22" + (_PeselMonth - 60).ToString();
            else if (_PeselYearPrefix > 40)
                _Result = "21" + (_PeselMonth - 40).ToString();
            else if (_PeselYearPrefix > 20)
                _Result = "20" + (_PeselMonth - 20).ToString();
            else if (_PeselYearPrefix > 0)
                _Result = "19" + _PeselMonth.ToString();
            else
                throw new ArgumentOutOfRangeException("Pesel value is invalid");

            return _Result;
        }

        public static string GetMonthFromPesel(string ArgPesel)
        {
            if (ArgPesel == null) return string.Empty;

            if (ArgPesel == null) return String.Empty;
            int _PeselMonth = Convert.ToInt32(ArgPesel.Substring(2, 2));
            string _Result;

            if (_PeselMonth > 80)
                _Result = (_PeselMonth - 80).ToString();
            else if (_PeselMonth > 60)
                _Result = (_PeselMonth - 60).ToString();
            else if (_PeselMonth > 40)
                _Result = (_PeselMonth - 40).ToString();
            else if (_PeselMonth > 20)
                _Result = (_PeselMonth - 20).ToString();
            else if (_PeselMonth > 0)
                _Result = _PeselMonth.ToString();
            else
                throw new ArgumentOutOfRangeException("Pesel value is invalid");

            return _Result;
        }

        public static string GetDayFromPesel(string ArgPesel)
        {
            if (ArgPesel == null) return string.Empty;
            return ArgPesel.Substring(4, 2);
        }

        public static string GetSexFromPesel(string ArgPesel)
        {
            if (ArgPesel == null) return string.Empty;
            return (int.Parse(ArgPesel.Substring(9, 1)) % 2 == 0) ? "F" : "M";
        }



    }


    [ValueConversion(typeof(bool), typeof(bool))]
    public class IsPaidByEmpConv : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (!(bool)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(object), typeof(bool))]
    public class SelectedBenefToReadOnly : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null) ? false : true;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
    
