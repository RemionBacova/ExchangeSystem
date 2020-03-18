using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Server;
using Gizmox.WebGUI.Hosting;

namespace CRMMobileDemo.Common
{
    public class CRMContext : Context
    {
        public CRMContext(HostContext objHostContext)
            :base(objHostContext)
        {
            
        }

        protected override string GetApplicationMetadataTags() 
        {
            string metaDataTags = base.GetApplicationMetadataTags();

            string currentTheme = this["CurrentIosTheme"] as string;

            if (!string.IsNullOrEmpty(currentTheme))
            {
                this.CurrentTheme = currentTheme;
            }

            metaDataTags += @"<meta name=""viewport"" content=""width=device-width, user-scalable=yes, initial-scale=1, maximum-scale=1 , minimum-scale=1"" /><meta name=""apple-mobile-web-app-capable"" content=""yes"" />";            

            return metaDataTags;
        }

    }
}