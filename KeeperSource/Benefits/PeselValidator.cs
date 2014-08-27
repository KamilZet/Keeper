using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KeeperRichClient.Modules.Benefits
{
    public class PeselValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (string.IsNullOrEmpty(value.ToString())) return new ValidationResult(false, "Pesel value cannot be empty.");
            else
            {
                if (!HelperFuncs.IsPeselValid(value.ToString())) return new ValidationResult(false, "Pesel is invalid.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
