using System;

namespace VP.Qontak.Crm.Common
{
    public static class DateTimeHelper
    {
        public static DateTime UnixTimeStampToDateTimeUtc(int totalSeconds)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(totalSeconds);

            return dtDateTime;
        }
    }
}