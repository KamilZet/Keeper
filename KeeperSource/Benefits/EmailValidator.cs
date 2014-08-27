using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KeeperRichClient.Modules.Benefits
{
    public class EmailValidator : ValidationRule 
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "Email value cannot be empty.");
            else if (!IsEmailValid(value.ToString()))
                return new ValidationResult(false,"Email address is invalid.");
            else
                return ValidationResult.ValidResult;
        }

        public static bool IsEmailValid(string ArgEmailAddress)
        {
            return Regex.IsMatch(ArgEmailAddress, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        }
    }
}
