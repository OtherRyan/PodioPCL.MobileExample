using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PodioPCL.MobileExample.Utility
{

	public class QuickConverter<TInput, TOutput, TParam> : IValueConverter
	{
		private Func<string, object, CultureInfo, string> func;

		public Func<TInput, TParam, CultureInfo, TOutput> ConvertFunction { get; private set; }
		public Func<TOutput, TParam, CultureInfo, TInput> ConvertBackFunction { get; private set; }

		public QuickConverter(
			Func<TInput, TParam, CultureInfo, TOutput> convertFunction = null,
			Func<TOutput, TParam, CultureInfo, TInput> convertBackFunction = null)
		{
			ConvertFunction = convertFunction;
			ConvertBackFunction = convertBackFunction;
		}

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ConvertFunction((TInput)value, (TParam)parameter, culture);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ConvertBackFunction((TOutput)value, (TParam)parameter, culture);
		}
	}
}
