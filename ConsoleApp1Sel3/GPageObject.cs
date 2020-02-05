using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Sel3
{
    class GPageObject
    {

        public GPageObject()
        {
            PageFactory.InitElements(Properties.driver, this);
        }
        [FindsBy(How =How.Id,Using = "Name")]     
        public IWebElement txtFirstName { get; set; }
       
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "Message")]
        public IWebElement txtMessage { get; set; }

       



        [FindsBy(How = How.Id, Using = "PosaljiEmail")]
        public IWebElement btnSend { get; set; }

        [FindsBy(How = How.Id, Using = "MainPageButtonImage")]
        public IWebElement btnMore { get; set; }


    }
}
