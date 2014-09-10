using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Markup;

namespace KeeperRichClient.Modules.Employees 
{
    public class RowNumberConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            //get the list view and the list view item

            ListViewItem item = values[0] as ListViewItem;
            ListView listView = values[1] as ListView;

            int index = listView.Items.IndexOf(item.Content);

            return index.ToString();
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    //public class RowNumberConverter : MarkupExtension, IValueConverter
    //{
    //    static RowNumberConverter converter;

    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        DataGridRow row = value as DataGridRow;
    //        if (row != null)
    //            return row.GetIndex()+1;
    //        else
    //            return -1;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override object ProvideValue(IServiceProvider serviceProvider)
    //    {
    //        if (converter == null) converter = new RowNumberConverter();
    //        return converter;
    //    }

    //    public RowNumberConverter()
    //    {
    //    }
    //}


}
