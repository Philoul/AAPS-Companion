using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AndroidAPS_CompanionXAML.Tizen.Watchface.Data
{
    class BgData
    {
        public int bg;
        public long timestamp;

        public BgData(int bg, long timestamp)
        {
            this.bg = bg;
            this.timestamp = timestamp;
        }

        public BgData()
        {

        }

        public override bool Equals(object obj)
        {
            if(this.timestamp != ((BgData)obj).timestamp)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override int GetHashCode()
        {
            var hashCode = -722130759;
            hashCode = hashCode * -1521134295 + bg.GetHashCode();
            hashCode = hashCode * -1521134295 + timestamp.GetHashCode();
            return hashCode;
        }
    }
}
