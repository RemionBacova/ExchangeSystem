using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

namespace CRMMobileDemo.Common
{
    public class iOSFormFactory : IFormFactory
    {
        #region IFormFactory Members

        private static readonly string[] SuppotedDevices = new string[] { "android", "iphone", "chrome", "ipad" };

        public IForm CreateForm(string strCurrentPage, params object[] arrArguments)
        {
            object objInstance = null;

            if (SuppotedDevices.Any(supportedDevice => VWGContext.Current.HttpContext.Request.UserAgent.ToLowerInvariant().Contains(supportedDevice)))
            {
                objInstance = Activator.CreateInstance(Type.GetType("CRMMobileDemo.iosForm, CRMMobileDemo"), arrArguments);
            }
            /*
            else if( For other browsers/mobile devices...)
            {
                objInstance = You can load and form according to the user agent...
            }
            */

            if (objInstance == null)
            {
                // For the meantime, always return the iosForm to support all browsers for now..
                objInstance = Activator.CreateInstance(Type.GetType("CRMMobileDemo.iosForm, CRMMobileDemo"), arrArguments);                
            }

            if (objInstance != null && objInstance is IForm)
            {
                return objInstance as IForm;
            }

            return null;
        }

        #endregion
    }
}