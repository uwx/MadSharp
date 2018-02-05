using System;

namespace Cum
{
    public class Date
    {
        private readonly long _time;

        public Date()
        {
            _time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public long GetTime()
        {
            return _time;
        }
    }
}