using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sindrol.Model.Utils
{
    public class MidGenerater
    {
        public static long NewMid(int bit)
        {
            if (bit > 16) throw new Exception("bit must <= 16");
            if (bit < 6) throw new Exception("bit must >= 6");
            Int64 mid = -1;
            string midStr = "";
            var guid = Guid.NewGuid();
            var bytes = guid.ToByteArray();
            for (int i = 0; i < bit; i++)
            {
                midStr += bytes[i].ToString().Last();
            }
            if (midStr[0] == '0') midStr = new Random().Next(1, 10).ToString() + midStr.Substring(1);
            mid = Int64.Parse(midStr);
            return mid;
        }
        public static long NewMid64Bit()
        {
            return NewMid(16);
        }

    }
}
