using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1Sel3
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        [SetUp]
        public void Initialise() {
            Properties.driver = new ChromeDriver();   //otvara chrome
            Properties.driver.Navigate().GoToUrl("http://www.roxoft.hr/");   //navigacija na url 
            Console.WriteLine("Opened");  //ispisi da je otvoreno
        }

        
        [Test]
        public void Test() {

           
            GPageObject gp = new GPageObject();  //inicijalizacija moje GPageObject klase
           

            //testiram ako cu poslat praznu formu da li cu dobit alert poruku
            gp.btnSend.Click();   //klik na posalji
            IAlert alert = Properties.driver.SwitchTo().Alert(); 
            string errorText = Properties.driver.SwitchTo().Alert().Text;    //dohvacam poruku alerta
            Assert.IsTrue(errorText.Contains("Molimo unesite Vašu e-mail adresu.")); 
            //provjeravam da li je poruka ispravna 
            alert.Accept();  //prihvacam alert



            Console.WriteLine("Tested");
            Console.WriteLine(errorText);  //ispisi mi alert poruku
            
        }

        [Test]
        public void Test1()
        {

            //testiram da li je slanje kontakta ispravno
            GPageObject gp = new GPageObject();

            //upisujem tekst pomocu SendKeys 
            gp.txtFirstName.SendKeys("pero peric"); 
            gp.txtEmail.SendKeys("email@gmail.com");
            gp.txtMessage.SendKeys("testiram");

            gp.btnSend.Click();
            IAlert alert = Properties.driver.SwitchTo().Alert();
            string errorText = Properties.driver.SwitchTo().Alert().Text;
            alert.Accept();
            
            Console.WriteLine("Tested");
            Console.WriteLine(errorText);
        }

        [Test]
        public void Test2()
        {


            GPageObject gp = new GPageObject();

            gp.txtFirstName.SendKeys("pero peric");
            gp.txtEmail.SendKeys("email");  //email je pogresan,testiram da li cu klikom na slanje dobit alert poruku
            gp.btnSend.Click();
          
            IAlert alert = Properties.driver.SwitchTo().Alert();
            string errorText = Properties.driver.SwitchTo().Alert().Text;     //dohvati text
            Assert.IsTrue(errorText.Contains("Format e-mail adrese nije ispravan.")); //da li se prikazuje ispravan text?
            alert.Accept();  //prihvati alert

            Console.WriteLine("Tested");
            Console.WriteLine(errorText); //vracam text iz alerta

        }
        [Test]
        public void Test3()
        {
            //ako kliknem na button više hoce li se prikazat tekst "Što radimo".
            //hoce li se prikazat second page što radimo?

            GPageObject gp = new GPageObject();



            gp.btnMore.Click();

            string a = Properties.driver.FindElement(By.XPath("//h1[@class='WhatWeDoHeading']")).Text;
            bool b=Properties.driver.FindElement(By.XPath("//div[@id='SecondPage']")).Displayed;
            Console.WriteLine("Tested");
            Console.WriteLine(a);
            Console.WriteLine(b);


        }
        [Test]
        public void Test4()
        {   //mjenja li se jezik
            //ako promjenim jezik na engleski hoce li se main title heading promjenit na eng jezik?
            
            GPageObject gp = new GPageObject();

            Properties.driver.FindElement(By.XPath("//a[contains(text(),'EN')]")).Click();
            //bool a=Properties.driver.PageSource.Contains("SOFTWARE TEST AUTOMATION EXPERTS");
            string actualString = Properties.driver.FindElement(By.XPath("//span[@id='MainPageHeading']")).Text;

            string expectedString = "SOFTWARE TEST AUTOMATION EXPERTS";

            Assert.IsTrue(actualString.Contains(expectedString));
            Console.WriteLine("Tested");
            Console.WriteLine(actualString);
            //Console.WriteLine(a);

        }


        [TearDown]
        public void Cleanup()
        {

            Properties.driver.Close();   //zatvori browser
            Console.WriteLine("Closed");    //ispisi da je zatvoreno
        }
    }
}
