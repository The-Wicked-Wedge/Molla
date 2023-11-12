using System.Globalization;

namespace Molla.Presentation.Utilities
{
    public static class PersianDateConvertor
    {
        public static string ConvertToShamsi(this DateTime value)
        {
            PersianCalendar persiancal = new PersianCalendar();
            return persiancal.GetYear(value) + "/" + persiancal.GetMonth(value).ToString("00") + "/" +
                   persiancal.GetDayOfMonth(value).ToString("00");
        }
    }
}
