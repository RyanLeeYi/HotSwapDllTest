using InterfaceLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlugin
{
    public class Plugin : IMyInterface
    {
        public string MyMethod()
        {
            return "Hello from plugin!0002";
        }
    }
}
