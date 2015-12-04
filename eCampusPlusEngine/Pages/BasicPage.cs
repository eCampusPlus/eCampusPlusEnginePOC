using System;
using eCampusPlus.Engine.Configuration.Drivers;

namespace Fr.eCampusPlus.Engine.Pages
{
    /// <summary>
    /// Base port page
    /// </summary>
    public class BasicPage
    {        
        protected string PageName;
        protected string PageUrl;

        public void Goto()
        {
            try
            {
                Browser.GoTo(PageUrl);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Can not open the page, Details:<br/>" + e.Message);
            }
        }

        public void RedirectTo(string targetPageUrl)
        {
            try
            {
                Browser.RedirectTo(targetPageUrl);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Can not open the page, Details:<br/>" + e.Message);
            }
        }

        public void GoBackTo()
        {
            try
            {
                Browser.SwitchToParent(); 
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Can not get back to the page, Details:<br/>" + e.Message);
            }
        }
    }
}
