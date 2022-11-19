using MiniCRM.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace MiniCRM.Converters
{
    public class IEnumerableTagToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.GetType()
                     .GetInterfaces()
                     .Contains(typeof(IEnumerable)))
            {
                IEnumerable<Tag> items = ((IEnumerable)value).OfType<Tag>();
                if (items != null || items.Any())
                    return string.Join(", ", items.Select(tag => tag.Name));
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
