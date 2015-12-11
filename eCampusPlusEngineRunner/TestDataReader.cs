using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Reflection;
using eCampusPlus.Engine.Configuration.Drivers;
using Fr.eCampusPlus.Engine.Model.POCO;
using Fr.eCampusPlus.Engine.Pages;
using Newtonsoft.Json.Converters;

namespace Fr.eCampusPlus.Engine.Runner
{
    public static class TestDataReader
    {
        public static void RunTest()
        {
            var eCampusPlusUser = new eCampusPlusUser();
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            

            //TEST DATA
            //USER DATA
            using (StreamReader sr = new StreamReader(@"eCampusPlusTestData\eCampusPlusTestData.json"))
            {
                eCampusPlusUser = serializer.Deserialize(sr, eCampusPlusUser.GetType()) as eCampusPlusUser;
            }
            //CAMPUS DATA
            var eCampusPlusConfig = new eCampusPlusConfiguration();
            using (StreamReader sr = new StreamReader(@"eCampusPlusEngineData\eCampusPlusEngineData.json"))
            {
                eCampusPlusConfig = serializer.Deserialize(sr, eCampusPlusConfig.GetType()) as eCampusPlusConfiguration;
            }

            //Browser start
            Browser.SetWebDriver("FIREFOX");

            string plateformeId = "FR";
            string targetId = "MA";

            //REGISTRATION
            string pageId = "RGTR";
            string url =
                eCampusPlusConfig.Plateforme.FirstOrDefault(pt => pt.PlateformeId.Equals(plateformeId))
                    .Targets.FirstOrDefault(t => t.TargetId.Equals(targetId))
                    .Accesses.FirstOrDefault(a => a.AccesseId.Equals(pageId))
                    .Url;            
            var page = new Page(plateformeId, pageId, url);
            //ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);
            
            //LOGIN
            pageId = "ACNT-LGN";
            url =
                eCampusPlusConfig.Plateforme.FirstOrDefault(pt => pt.PlateformeId.Equals(plateformeId))
                    .Targets.FirstOrDefault(t => t.TargetId.Equals(targetId))
                    .Accesses.FirstOrDefault(a => a.AccesseId.Equals(pageId))
                    .Url;
            page = new Page(plateformeId, pageId, url);
            ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);

            //Candidate
            //pageId = "ACNT-NAV";
            //page = new Page(plateformeId, pageId, string.Empty,false);
            //Process some actions
            //pageId = "ACNT-CAND-NAV";
            //page = new Page(plateformeId, pageId, string.Empty, false);
            //Process some actions
            //pageId = "ACNT-CAND-STDNT-INFO";
            //page = new Page(plateformeId, pageId, string.Empty, false);
            //pageId = "ACNT-CAND-STDNT-SKILLS";
            //page = new Page(plateformeId, pageId, string.Empty, false);
            //pageId = "ACNT-CAND-STDNT-LANGUA";
            //page = new Page(plateformeId, pageId, string.Empty, false);

            pageId = "ACNT-CAND-STDNT-CHOSE-SCHOOL";
            page = new Page(plateformeId, pageId, string.Empty, false);
            ProcessingAction(page, eCampusPlusUser, eCampusPlusConfig);

            //END
            Browser.WebDriver.Quit();
            
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
                    if (e.RequireReload)
                    {
                        Browser.WebDriver.Navigate().Refresh();
                        PagesHelper.PerformAction((PagesHelper.ActionElementType)Enum.Parse(typeof(PagesHelper.ActionElementType), e.PreActionField.ElementType, true), e.PreActionField.Accessor);
                    }
                }
            });  
            
        }
    }
}
