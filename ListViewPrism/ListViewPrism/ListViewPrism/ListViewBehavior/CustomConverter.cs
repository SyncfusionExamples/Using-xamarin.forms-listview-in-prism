using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewPrism
{
    public class CustomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Syncfusion.ListView.XForms.SwipeEndedEventArgs eventArg = null;
            if (value is Syncfusion.ListView.XForms.SwipeEndedEventArgs)
            {
                eventArg = value as Syncfusion.ListView.XForms.SwipeEndedEventArgs;
            }
           
            return eventArg;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
