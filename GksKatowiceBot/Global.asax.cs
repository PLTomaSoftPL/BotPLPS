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
        [NonSerialized]
        static DataTable dtWiadomosci;
        [NonSerialized]
        static DataTable dtWiadomosciOrlen;
        [NonSerialized]
        static DataTable dt;
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
            try
            {
                if (DateTime.UtcNow.Hour == 17 && (DateTime.UtcNow.Minute > 0 && DateTime.UtcNow.Minute <= 3))
                {
                    MessagesController.AddToLog("Wywołanie metody OnTimedEvent");
                    dtWiadomosci= MessagesController.GetWiadomosci();
                    dtWiadomosciOrlen = MessagesController.GetWiadomosciOrlen();
                    dt = MessagesController.GetUser();
                    List<IGrouping<string, string>> hrefList2 = new List<IGrouping<string, string>>();
                    List<IGrouping<string, string>> hreflist3 = new List<IGrouping<string, string>>();
                    int i = 0;
                    while (i <= dt.Rows.Count)
                    {
                        var listaUzytkownikow = dt.AsEnumerable().Take(20).ToList();
                        Task.Run(() => MessagesController.SendThreadMessage(listaUzytkownikow, dtWiadomosci, dtWiadomosciOrlen));
                        i = 20;
                    }
                    MessagesController.AddToLog("Wartosc i: " + i);
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Task.Run(() => MessagesController.SendThreadMessage(dr,dtWiadomosci,dtWiadomosciOrlen));
                    //}
                    MessagesController.ZapiszWiadomosci(dtWiadomosci, dtWiadomosciOrlen);
                }
            }
            catch
            {

            }
        }
    }
}
