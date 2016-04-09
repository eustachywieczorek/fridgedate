using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FridgeDate.Core.Interfaces;
using FridgeDate.Core.Services;
using Splat;

namespace FridgeDate.Core
{
    public static class Startup
    {
        public static void RegisterContainers()
        {
            Locator.CurrentMutable.Register(() => new AppContext(), typeof (IAppContext));

        }
    }
}
