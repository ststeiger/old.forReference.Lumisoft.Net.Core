
using System;
using System.Collections.Generic;
using System.Text;


namespace System.TimeZone
{

    public class CurrentTimeZone
    {


        public static System.TimeSpan GetUtcOffset(System.DateTime datetime)
        {
            return System.TimeZoneInfo.Local.GetUtcOffset(datetime);
        }


    }


}
