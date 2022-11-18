using MiniCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MiniCRM.Converters
{
    public class GenderToTextConverter : IValueConverter
    {
        private static IDictionary<Gender, string> _descriptions = new Dictionary<Gender, string>
        {
            { Gender.Female, "Женский"  },
            { Gender.Male, "Мужской"},
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Gender gender)
            {
                return _descriptions[gender];
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
