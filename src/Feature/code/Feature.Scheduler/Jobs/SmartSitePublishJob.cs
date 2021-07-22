using Quartz;
using Sitecore.Data;
using Sitecore.Data.Managers;
using Sitecore.Diagnostics;
using Sitecore.Globalization;

namespace Feature.Scheduler.Jobs
{
    public class SmartSitePublishJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Log.Info("SmartSitePublishJob Execute - Start", this);

            Database master = Sitecore.Configuration.Factory.GetDatabase("master");

            Database[] targetDBs = new Database[] { Sitecore.Configuration.Factory.GetDatabase("web") }; //you can get this via config if you need customize targets
            Language[] languages = languages = LanguageManager.GetLanguages(master).ToArray();

            Sitecore.Publishing.PublishManager.PublishSmart(master, targetDBs, languages);

            Log.Info("SmartSitePublishJob Execute - End", this);
        }
    }
}