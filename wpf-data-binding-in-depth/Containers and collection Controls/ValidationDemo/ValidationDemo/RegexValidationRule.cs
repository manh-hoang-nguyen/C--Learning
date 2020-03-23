using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ValidationDemo
{
    public class RegexValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (Expression == null) return ValidationResult.ValidResult;

            //Regex regex = new Regex(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$");
            Regex regex = new Regex(Expression);
            Match match = regex.Match(value.ToString());
            if (match == null || match == Match.Empty)
            {
                return new ValidationResult(false, "Invalid input format");
            }
            else return ValidationResult.ValidResult;
        }
        public string Expression { get; set; }
    }
}