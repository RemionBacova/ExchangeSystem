using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Server;
using Gizmox.WebGUI.Hosting;

namespace CRMMobileDemo.Common
{
    public class CRMRouter : Router
    {
        protected override Context CreateContext(HostContext objHostContext)
        {
            return new CRMContext(objHostContext);
        }
    }
}