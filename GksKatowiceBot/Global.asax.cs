using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Timers;
using System.Threading.Tasks;
using System.Data;

namespace GksKatowiceBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

         //   var registry = new Registry();
            //    registry.Schedule(() => MessagesController.SendThreadMessage()).ToRunEvery().Hours().;

            MessagesController.AddToLog("Wywołanie metody Application_Start");
         //   MessagesController.SendThreadMessage();
            Timer aTimer = new System.Timers.Timer();
            aTimer.Interval = 3 * 60 * 1000;

            aTimer.Elapsed += OnTimedEvent;
            aTimer.Start();

        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (DateTime.UtcNow.Hour == 17 && (DateTime.UtcNow.Minute > 0 && DateTime.UtcNow.Minute <= 3))
            {
                DataTable dtWiadomosci = MessagesController.GetWiadomosci();
                DataTable dtWiadomosciOrlen = MessagesController.GetWiadomosciOrlen();
                DataTable dt = MessagesController.GetUser();
                List<IGrouping<string, string>> hrefList2 = new List<IGrouping<string, string>>();
                List<IGrouping<string, string>> hreflist3 = new List<IGrouping<string, string>>();
                foreach (DataRow dr in dt.Rows)
                {
                    Task.Run(() => MessagesController.SendThreadMessage(dr,dtWiadomosci,dtWiadomosciOrlen));
                }
                MessagesController.ZapiszWiadomosci(dtWiadomosci, dtWiadomosciOrlen);
            }
        }
    }
}
