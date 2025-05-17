using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace TodoList.UI
{
    	public class InverseBoolConverter : IValueConverter
    	{
        	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        	{
            	if (value is bool b)
                	return !b;

            	return false;
        	}

        	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        	{
            		throw new NotSupportedException();
        	}
    	}

    	public class EditSaveConverter : IValueConverter
    	{
        	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        	{
            		if (value is bool isEditing)
                		return isEditing ? "Сохранить" : "Изменить";
					return "Изменить";
        	}

        	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        	{
            		throw new NotSupportedException();
        	}
    	}
}
