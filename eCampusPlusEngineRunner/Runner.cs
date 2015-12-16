using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Reflection;
using eCampusPlus.Engine.Configuration.Drivers;
using Fr.eCampusPlus.Engine.Model.POCO;
using Fr.eCampusPlus.Engine.Pages;
using Newtonsoft.Json.Converters;
using System.Threading;

namespace Fr.eCampusPlus.Engine.Runner
{
    public static class Runner
    {
        public static void RunTest(int stepInProcess, string generatedUrl = "")
        {
            var eCampusPlusUser = new eCampusPlusUser();
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamReader sr = new StreamReader(@"D:\eCampusPlusPOCData\eCampusPlusTestData\eCampusPlusTestData.json"))
            {
                eCampusPlusUser = serializer.Deserialize(sr, eCampusPlusUser.GetType()) as eCampusPlusUser;
            }
            
            var eCampusPlusConfig = new eCampusPlusConfiguration();
            using (StreamReader sr = new StreamReader(@"D:\eCampusPlusPOCData\eCampusPlusEngineData\eCampusPlusEngineData.json"))
            {
                eCampusPlusConfig = serializer.Deserialize(sr, eCampusPlusConfig.GetType()) as eCampusPlusConfiguration;
            }

            //Browser start
            //Browser.SetWebDriver("FIREFOX");

            string plateformeId = "FR";
            string targetId = "MA";
            string pageId = string.Empty;
            string url = string.Empty;
            Page page = null;

            switch (stepInProcess)
            {
                case 1:
                    //REGISTRATION
                    pageId = "RGTR";
                    url = eCampusPlusConfig.Plateforme.FirstOrDefault(pt => pt.PlateformeId.Equals(plateformeId))
                            .Targets.FirstOrDefault(t => t.TargetId.Equals(targetId))
                            .Accesses.FirstOrDefault(a => a.AccesseId.Equals(pageId))
                            .Url;
                    page = new Page(plateformeId, pageId, url);
                    //ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);
                    break;
                case 2:
                    //Confirmation
                    pageId = "ACNT-CONF";
                    url = generatedUrl; 
                    //Exemple d'URL "http://pastel.diplomatie.gouv.fr/etudesenfrance/dyn/public/confirmerCompte.html?ticket=083d2bfa-8129-4d2a-b932-3ebbe4a070b7";
                    page = new Page(plateformeId, pageId, url);
                    //ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);
                    break;
                case 3:
                    //LOGIN
                    pageId = "ACNT-LGN";
                    url =
                        eCampusPlusConfig.Plateforme.FirstOrDefault(pt => pt.PlateformeId.Equals(plateformeId))
                            .Targets.FirstOrDefault(t => t.TargetId.Equals(targetId))
                            .Accesses.FirstOrDefault(a => a.AccesseId.Equals(pageId))
                            .Url;
                    page = new Page(plateformeId, pageId, url);
                    ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);

                    //SET FILE DATA
                    pageId = "ACNT-CAND-STDNT-INFO";
                    page = new Page(plateformeId, pageId, string.Empty, false);
                    ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);

                    pageId = "ACNT-CAND-STDNT-SKILLS";
                    page = new Page(plateformeId, pageId, string.Empty, false);
                    ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);

                    pageId = "ACNT-CAND-STDNT-LANGUA";
                    page = new Page(plateformeId, pageId, string.Empty, false);
                    ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);
                    break;
            }

            //END
            //Browser.WebDriver.Quit();
            
        }

        private static void ProcessingAction(Page page, eCampusPlusUser eCampusPlusUser, eCampusPlusConfiguration eCampusPlusConfig)
        {
            
            var eCampusUserProperties = eCampusPlusUser.GetType().GetProperties();
            page.PageElements.ForEach(e =>
            {
                var property = eCampusUserProperties.FirstOrDefault(p => p.Name.Equals(e.Name));
                if (property != null)
                {
                    string value = property .GetValue(eCampusPlusUser).ToString();
                    PagesHelper.PerformAction((PagesHelper.ActionElementType)Enum.Parse(typeof(PagesHelper.ActionElementType), e.ElementType, true), e.Accessor, value);
                    Thread.Sleep(100);
                    if (e.RequireReload)
                    {
                        Browser.WebDriver.Navigate().Refresh();
                        e.PreActionField.ForEach(pre =>
                        {
                            PagesHelper.PerformAction((PagesHelper.ActionElementType)Enum.Parse(typeof(PagesHelper.ActionElementType), pre.ElementType, true), pre.Accessor);
                            Thread.Sleep(50);
                        });
                        
                    }
                }
            });  
            
        }
    }
}
