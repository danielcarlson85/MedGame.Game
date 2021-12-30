using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace MedGame.Services
{

    public static class DateHandler
    {
        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        private static extern bool Win32SetSystemTime(ref SystemTime sysTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Millisecond;
        };

        public static void SetSystemDateTime(int year, int month, int day, int hour,
            int minute, int second, int millisecond)
        {
            SystemTime updatedTime = new SystemTime
            {
                Year = (ushort)year,
                Month = (ushort)month,
                Day = (ushort)day,
                Hour = (ushort)hour,
                Minute = (ushort)minute,
                Second = (ushort)second,
                Millisecond = (ushort)millisecond
            };

            // If this returns false, then the problem is most likely that you don't have the 
            // admin privileges required to set the system clock
            if (!Win32SetSystemTime(ref updatedTime))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public static void SetSystemDateTime(DateTime dateTime)
        {
            SetSystemDateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute,
                dateTime.Second, dateTime.Millisecond);
        }
    }

}
