using System.Text.RegularExpressions;

namespace apiwebvivanet.Utils
{
	public class General
	{
		public static bool IsValidPeriodoDateFormat(string dateString)
		{
			string pattern = @"^(0[1-9]|1[0-2])\/\d{4}$";
			return Regex.IsMatch(dateString, pattern);
		}
	}
}
