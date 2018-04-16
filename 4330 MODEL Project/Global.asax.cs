using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace _4330_MODEL_Project
{
    public class Global : HttpApplication
    {
        static Timer _timer = null;
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            if (_timer == null)
            {
                _timer = new Timer();
                _timer.Interval = 30000; // some interval
                _timer.Elapsed += new ElapsedEventHandler(AssessmentTool.randomMethod);
                _timer.Start();
            }
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}