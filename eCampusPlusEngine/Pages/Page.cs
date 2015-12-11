using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using eCampusPlus.Engine.Configuration.Drivers;
using Fr.eCampusPlus.Engine.Model.POCO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Fr.eCampusPlus.Engine.Pages
{
    public class Page : BasicPage, IDisposable
    {

        #region Constructors

        public Page(string plateformeId, string pageId, string pageUrl, bool needGoto = true)
        {
            PlateformeId = plateformeId;
            PageId = pageId;
            PageUrl = pageUrl;
            BuildPage();
            if (needGoto) Goto();
        }

        #endregion

        #region Properies       
        public string PlateformeId { get; set; }
        public string PageId { get; set; }
        #endregion

        public List<eCampusPlusWebElement> PageElements { get; set;}

        private void BuildPage()
        {          
            //STEP1
            //Read uri content - Use display name for mapping
            //STEP2
            //Build the list of page's elements            
            PageElements = new List<eCampusPlusWebElement>();
            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            eCampusPlusPagesConfiguration config = new eCampusPlusPagesConfiguration();

            using (StreamReader sr = new StreamReader(ConfigurationManager.AppSettings["PagesAccessibilityDataPath"]))
            {                
                config = serializer.Deserialize(sr, config.GetType()) as eCampusPlusPagesConfiguration;
            }
            PageElements = config.Plateforme.FirstOrDefault(pt => pt.PlateformeId.Equals(PlateformeId)).Pages.FirstOrDefault(pg => pg.PageId.Equals(PageId)).Fields;
        }

        public void Dispose()
        {
            Browser.WebDriver.Quit();
        }
    }
}
