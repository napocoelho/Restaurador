using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurador.Helpers
{
    public static class Extensions
    {
        public static int ToInt(this object self)
        {
            int result;
            if (int.TryParse(self.ToString(), out result))
            {
                return result;
            }

            return 0;
        }

        public static Int64 ToInt64(this object self)
        {
            Int64 result;
            if (Int64.TryParse(self.ToString(), out result))
            {
                return result;
            }

            return 0;
        }
    }
}
