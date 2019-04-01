using System;

namespace Nice2Experience.JwtInfo {
public static class EpochTime
    {
        //
        // Summary:
        //     DateTime as UTV for UnixEpoch
        public static readonly DateTime UnixEpoch = new DateTime(1970,1,1);

        //
        // Summary:
        //     Creates a DateTime from epoch time.
        //
        // Parameters:
        //   secondsSinceUnixEpoch:
        //     Number of seconds.
        //
        // Returns:
        //     The DateTime in UTC.
        public static DateTime DateTime(long secondsSinceUnixEpoch)
        {            
            return secondsSinceUnixEpoch<0 ? UnixEpoch : UnixEpoch.AddSeconds(secondsSinceUnixEpoch);
        }

        
        // Summary:
        //     Per JWT spec: Gets the number of seconds from 1970-01-01T0:0:0Z as measured in
        //     UTC until the desired date/time.
        //
        // Parameters:
        //   datetime:
        //     The DateTime to convert to seconds.
        //
        // Returns:
        //     the number of seconds since Unix Epoch.
        //
        // Remarks:
        //     if dateTimeUtc less than UnixEpoch, return 0
        public static long GetIntDate(DateTime datetime){
            var s = (datetime - UnixEpoch).TotalSeconds;
            return (s<0) ? 0L: Convert.ToInt64(s);
        }
    }
}