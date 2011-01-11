using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageNine.PhotoHandler
{
    public class TimeStampFormatter
    {
        public DateTime UnixTimeStampToDateTime(double timeStamp)
        {
            // First make a System.DateTime equivalent to the UNIX Epoch.
            var dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

            // Add the number of seconds in UNIX timestamp to be converted.
            dateTime = dateTime.AddSeconds(timeStamp);

            // The dateTime now contains the right date/time so to format the string,
            return dateTime;
        }
    }
}
