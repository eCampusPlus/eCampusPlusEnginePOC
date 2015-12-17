using System;
using eCampusPlus.Engine.Configuration.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Fr.eCampusPlus.Engine.Pages
{
    public static class PagesHelper
    {
        #region Properties
        public enum ActionType
        {
            GET,
            SET,
            CLEAR
        };

        public enum ActionElementType
        {
            INPUT,
            INPUT_FILE,
            HIDDEN_INPUT_FILE,
            CHECKBOX,
            DROPDOWNLIST,
            BUTTON,
            LINK,
            DIV,
            TABLE_CELL_LINK,
            FORM
        };
        #endregion

        #region Actions helpers

        private static void InputSetHelper(string xPath,string value)
        {
            InputClearHelper(xPath);
            Browser.Driver.FindElement(By.XPath(xPath)).SendKeys(value);
        }

        private static string InputGetHelper(string xPath)
        {
            return Browser.Driver.FindElement(By.XPath(xPath)).GetAttribute("value");
        }

        private static void InputClearHelper(string xPath)
        {
            Browser.Driver.FindElement(By.XPath(xPath)).Clear();
        }

        private static void CheckboxHelper(string xPath)
        {
            Browser.Driver.FindElement(By.XPath(xPath)).Click();
        }

        private static void DropdownHelper(string xPath, string value)
        {        
            Thread.Sleep(1000);
            var selectElement = new SelectElement(Browser.Driver.FindElement(By.XPath(xPath)));
            Thread.Sleep(1500);
            selectElement.SelectByText(value);
            
        }

        private static void ButtonHelper(string xPath)
        {
            Browser.Driver.FindElement(By.XPath(xPath)).Click();
        }

        private static void InputFileHelper(string xPath,string filePath)
        {
            Browser.Driver.FindElement(By.XPath(xPath)).SendKeys(filePath);
        }

        private static void HiddenInputFileHelper(string xPath,string filePath) 
        {
            var js = (IJavaScriptExecutor)Browser.Driver;            
            js.ExecuteScript(string.Format("document.getElementById(\"{0}\").style.visibility = \"visible\";", "champPhoto"));           
            InputFileHelper(xPath, filePath);
            Browser.WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(100));
        }

        private static void TableCellLinkHelper(string xPath, int lineNumber = 1)
        {
            Thread.Sleep(3000);
            Browser.Driver.FindElement(By.XPath(string.Format(xPath, lineNumber))).Click();
            Thread.Sleep(100);
        }

        private static void FormHelper(string xPath)
        {
            Browser.Driver.FindElement(By.XPath(xPath)).Submit();
        }
        #endregion

        #region Actions 

        public static void PerformAction(ActionElementType actionElementType, string xPath, string value = "", ActionType actionType = ActionType.SET)
        {
            switch (actionElementType)
            {
                case ActionElementType.INPUT:
                {
                    if (actionType.Equals(ActionType.GET))
                    {
                        value = InputGetHelper(xPath);
                    }
                    if (actionType.Equals(ActionType.SET))
                    {
                        InputSetHelper(xPath, value);
                    }
                    if (actionType.Equals(ActionType.CLEAR))
                    {
                        InputClearHelper(xPath);
                    }
                    break; 
                } 
                case ActionElementType.INPUT_FILE:
                {
                    InputFileHelper(xPath, value);
                    break;
                }
                case ActionElementType.TABLE_CELL_LINK:
                {
                    TableCellLinkHelper(xPath);
                    break;
                }
                case ActionElementType.CHECKBOX:
                {
                    CheckboxHelper(xPath);
                    break;
                }
                case ActionElementType.DROPDOWNLIST:
                {
                    DropdownHelper(xPath, value);
                    break;
                }
                case ActionElementType.BUTTON:
                case ActionElementType.LINK:
                {
                    ButtonHelper(xPath);
                    break;
                } 
                case ActionElementType.FORM:
                {
                    FormHelper(xPath);
                    break;
                }
                case ActionElementType.HIDDEN_INPUT_FILE:
                {
                    HiddenInputFileHelper(xPath, value);
                    break;
                }
            }
        }

        #endregion
    }
}