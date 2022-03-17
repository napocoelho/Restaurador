using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurador.Helpers
{
    /// <summary>
    /// Used to detect the current build mode.
    /// </summary>
    public static class ModeDetectorHelper
    {
        /// <summary>
        /// Gets a value indicating whether the assembly was built in debug mode.
        /// </summary>
        public static bool IsDebug
        {
            get
            {
                bool isDebug = false;


                try
                {
#if (DEBUG)
                    isDebug = true;
#else
                    isDebug = false;
#endif
                }
                catch(Exception ex)
                { }

                return isDebug;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the assembly was built in release mode.
        /// </summary>
        public static bool IsRelease
        {
            get { return !IsDebug; }
        }
    }
}
