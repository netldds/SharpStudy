using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
    class FXVersionInRegistry
    {
        public static int GetFXVersion()
        {
            using (RegistryKey ndpkey = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, "").OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
            {
                int ReleaseKey = Convert.ToInt32(ndpkey.GetValue("Release"));
                //Console.WriteLine(ReleaseKey);
                return ReleaseKey;
            }
        }
    }
}
