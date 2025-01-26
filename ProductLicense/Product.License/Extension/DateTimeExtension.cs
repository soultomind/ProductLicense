using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Extension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// <see cref="DateTime.Now"/> 값에 시간값(Year,Month,Day)은 모두 0으로 설정한 값을 반환합니다.
        /// </summary>
        /// <returns></returns>
        public static DateTime ToNowSetTimeYearMonthDayExceptTimeZero()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }
    }
}
