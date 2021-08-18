using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows.Forms;

namespace Excel
{
    public class Exectests
    {
        TestRec testrec = new TestRec();

        public ResultRec runTest(IWebDriver IWDriver, TestRec inTestrec)
        {
            ResultRec restultRec = new ResultRec();
            restultRec.setResult("OK");

            //============================================================== URL
            //============================================================== URL
            //============================================================== URL

            if ((inTestrec.CMD.ToString() == "URL") && (inTestrec.SUBCMD.ToString() == "OPEN"))
            {
                IWDriver.Url = inTestrec.ITEMURL;
                IWDriver.Manage().Window.Maximize();
                return restultRec;
            }

            if ((inTestrec.CMD.ToString() == "URL") && (inTestrec.SUBCMD.ToString() == "ASSERT"))
            {
                IWDriver.Url = inTestrec.ITEMURL;
                String URL = IWDriver.Url;
                if (URL != inTestrec.ITEMURL)
                {
                    restultRec.setResult("ERROR");
                    return restultRec;
                }
                return restultRec;
            }

            //============================================================= LINK
            //============================================================= LINK
            //============================================================= LINK

            if ((inTestrec.CMD.ToString() == "LINK") && (inTestrec.SUBCMD.ToString() == "CLICK"))
            {
                var elementPresent = true;
                String link;
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "TEXT") &&
                    (!(inTestrec.ITEMURL == null))
                    )
                {
                    String actualString = "";
                    try
                    {
                        link = IWDriver.FindElement(By.LinkText(inTestrec.ITEMURL)).GetAttribute("href");
                        IWDriver.FindElement(By.LinkText(inTestrec.ITEMURL)).Click();
                        var navigate = IWDriver.Navigate();
                        navigate.GoToUrl(link);
                    }
                    catch (NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());
                        return restultRec;
                    }
                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    IWDriver.Url = link;
                    return restultRec;
                }


                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "ID") &&
                    (!(inTestrec.ITEMURL == null))
                )
                {
                    String actualString = "";
                    try
                    {
                        link = IWDriver.FindElement(By.LinkText(inTestrec.ITEMURL)).GetAttribute("href");
                        IWDriver.FindElement(By.Id(inTestrec.ITEMURL)).Click();
                        var navigate = IWDriver.Navigate();
                        navigate.GoToUrl(link);

                    }
                    catch (NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());
                        return restultRec;
                    }
                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    return restultRec;
                }


                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "XPATH") &&
                    (!(inTestrec.ITEMURL == null))
)
                {
                    String actualString = "";
                    try
                    {
                        link = IWDriver.FindElement(By.LinkText(inTestrec.ITEMURL)).GetAttribute("href");
                        IWDriver.FindElement(By.XPath(inTestrec.ITEMURL)).Click();
                        var navigate = IWDriver.Navigate();
                        navigate.GoToUrl(link);
                    }
                    catch (NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());
                        return restultRec;
                    }
                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    return restultRec;
                }


                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "PARTOFTEXT") &&
                    (!(inTestrec.ITEMURL == null))
)
                {
                    String actualString = "";
                    try
                    {
                        link = IWDriver.FindElement(By.LinkText(inTestrec.ITEMURL)).GetAttribute("href");
                        IWDriver.FindElement(By.PartialLinkText(inTestrec.ITEMURL)).Click();
                        var navigate = IWDriver.Navigate();
                        navigate.GoToUrl(link);
                    }
                    catch (NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());
                        return restultRec;
                    }
                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    return restultRec;
                }


                return restultRec;
            }

            //======================================================================== LABEL
            //======================================================================== LABEL
            //======================================================================== LABEL

            if ((inTestrec.CMD.ToString() == "LABEL") && (inTestrec.SUBCMD.ToString() == "ASSERT" && inTestrec.ITEM_URLTYPE.ToString() == "XPATH"))
            {
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "XPATH") &&
                    (!(inTestrec.ITEMURL == null))
                    )
                {
                    String actualString = "";
                    try
                    {
                        actualString = IWDriver.FindElement(By.XPath(inTestrec.ITEMURL)).Text;
                    }
                    catch (NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());
                        return restultRec;
                    }

                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    if (actualString != inTestrec.SPARM1)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE(actualString);
                    }
                    return restultRec;
                }
                return restultRec;
            }


            if ((inTestrec.CMD.ToString() == "LABEL") && (inTestrec.SUBCMD.ToString() == "ASSERT" && inTestrec.ITEM_URLTYPE.ToString() == "ID"))
            {
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "ID") &&
                    (!(inTestrec.ITEMURL == null))
                    )
                {
                    String actualString = "";
                    try
                    {
                        actualString = IWDriver.FindElement(By.Id(inTestrec.ITEMURL)).Text;
                    }
                    catch (NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());
                        return restultRec;
                    }

                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    if (actualString != inTestrec.SPARM1)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE(actualString);
                    }
                    return restultRec;
                }
                return restultRec;
            }

            if ((inTestrec.CMD.ToString() == "LABEL") && (inTestrec.SUBCMD.ToString() == "ASSERT" && inTestrec.ITEM_URLTYPE.ToString() == "NAME"))
            {
                var elementPresent = true;
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "NAME") &&
                    (!(inTestrec.ITEMURL == null))
                    )
                {
                    String actualString = "";
                    try
                    {
                        actualString = IWDriver.FindElement(By.Name(inTestrec.ITEMURL)).Text;
                    }
                    catch (NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());
                        return restultRec;
                    }

                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    if (actualString != inTestrec.SPARM1)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE(actualString);
                    }
                    return restultRec;
                }
                return restultRec;
            }

            //=================================================================== SELECT LIST ELEMENT
            //=================================================================== SELECT LIST ELEMENT
            //=================================================================== SELECT LIST ELEMENT

            if ((inTestrec.CMD.ToString() == "SELECTLIST") && (inTestrec.SUBCMD.ToString() == "ASSERT"))
            {
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "NAME") &&
                    (!(inTestrec.ITEMURL == null))
                    )
                {
                    string actualString = "";
                    try
                    {
                        actualString = IWDriver.FindElement(By.Name(inTestrec.ITEMURL)).Text;
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());//selectcarsname
                        return restultRec;
                    }

                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }


                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "ID") &&
                    (!(inTestrec.ITEMURL == null))
                    )
                {
                    String actualString = "";
                    try
                    {
                        actualString = IWDriver.FindElement(By.Id(inTestrec.ITEMURL)).Text;
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());
                        return restultRec;
                    }
                    restultRec.setResult("OK");
                    return restultRec;
                }
                return restultRec;
            }

            //=================================================================== SELECT LIST ITEM COUNT
            //=================================================================== SELECT LIST ITEM COUNT
            //=================================================================== SELECT LIST ITEM COUNT

            if ((inTestrec.CMD.ToString() == "SELECTLISTCOUNT") && (inTestrec.SUBCMD.ToString() == "ASSERT"))
            {
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "NAME") &&
                    (!(inTestrec.ITEMURL == null)) &&
                    (!(inTestrec.IPARM1 == null))
                    )
                {
                    Int32? NumberOfItems = 0;
                    try
                    {
                        string options = IWDriver.FindElement(By.Name(inTestrec.ITEMURL)).Text;
                        string[] myArray = options.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        NumberOfItems = myArray.Length;
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());//selectcarsname
                        return restultRec;
                    }

                    if (!(NumberOfItems -1 == inTestrec.IPARM1)) {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("Wrong Options Count:" + NumberOfItems + " Expecting: " + inTestrec.IPARM1.ToString());
                        return restultRec;
                    }

                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }



                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "ID") &&
                    (!(inTestrec.ITEMURL == null)) &&
                    (!(inTestrec.IPARM1 == null))
                    )
                {
                    Int32? NumberOfItems = 0;
                    try
                    {
                        string options = IWDriver.FindElement(By.Id(inTestrec.ITEMURL)).Text;
                        string[] myArray = options.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        NumberOfItems = myArray.Length;
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());//selectcarsname
                        return restultRec;
                    }

                    if (!(NumberOfItems -1 == inTestrec.IPARM1)) {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("Wrong Options Count:" + NumberOfItems + " Expecting: " + inTestrec.IPARM1.ToString());
                        return restultRec;
                    }

                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }

            }


            //=================================================================== SELECT LIST ITEM OPTION
            //=================================================================== SELECT LIST ITEM OPTION
            //=================================================================== SELECT LIST ITEM OPTION
            if ((inTestrec.CMD.ToString() == "SELECTLISTOPTION") && (inTestrec.SUBCMD.ToString() == "ASSERT"))
            {
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "NAME") &&
                    (!(inTestrec.ITEMURL == null)) &&
                    (!(inTestrec.IPARM1 == null)) &&
                    (!(inTestrec.SPARM1 == null))
                    )
                {
                    Int32? NumberOfItems = 0;
                    string[] myArray;
                    try
                    {
                        string options = IWDriver.FindElement(By.Name(inTestrec.ITEMURL)).Text;
                        myArray = options.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        NumberOfItems = myArray.Length;
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());//selectcarsname
                        return restultRec;
                    }
                    if (!(myArray[(Int32)inTestrec.IPARM1 - 1].Trim() == inTestrec.SPARM1.Trim()))
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("Wrong Option is select list location:" + myArray[(Int32)inTestrec.IPARM1-1] + " Expecting: " + inTestrec.SPARM1);
                        return restultRec;
                    }

                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }



                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                                (inTestrec.ITEM_URLTYPE.ToString() == "ID") &&
                                (!(inTestrec.ITEMURL == null)) &&
                                (!(inTestrec.IPARM1 == null)) &&
                                (!(inTestrec.SPARM1 == null))
                                )
                {
                    Int32? NumberOfItems = 0;
                    string[] myArray;
                    try
                    {
                        string options = IWDriver.FindElement(By.Id(inTestrec.ITEMURL)).Text;
                        myArray = options.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                        NumberOfItems = myArray.Length;
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL.ToString());//selectcarsname
                        return restultRec;
                    }

               
                    if (!(myArray[(Int32)inTestrec.IPARM1 -1].Trim() == inTestrec.SPARM1.Trim()))
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("Wrong Option is select list location:" + myArray[(Int32)inTestrec.IPARM1-1] + " Expecting: " + inTestrec.SPARM1);
                        return restultRec;
                    }

                    //assertTrue(actualString.contains("specific text"));
                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }

                //assertTrue(actualString.contains("specific text"));
                restultRec.setResult("OK");
                restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                return restultRec;
            }


            //=================================================================== INPUT CONTROL TEXT
            //=================================================================== INPUT CONTROL TEXT
            //=================================================================== INPUT CONTROL TEXT

            //driver.findElement(By.xpath("//input[@id='invoice_supplier_id'])).sendKeys("your value");

            //< input type = "search" id = "gsearch" name = "gsearch" >



            if ((inTestrec.CMD.ToString() == "INPUTCONTROLTEXT") && (inTestrec.SUBCMD.ToString() == "CHANGE"))
            {
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "NAME") &&
                    (!(inTestrec.ITEMURL == null)) &&
                    // (!(inTestrec.IPARM1 == null)) &&
                    (!(inTestrec.SPARM1 == null))
                    )
                {
                    try
                    {
                        IWDriver.FindElement(By.Name(inTestrec.ITEMURL)).SendKeys(inTestrec.SPARM1);
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL);
                        return restultRec;
                    }
                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }
            


                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "ID") &&
                    (!(inTestrec.ITEMURL == null)) &&
                    // (!(inTestrec.IPARM1 == null)) &&
                    (!(inTestrec.SPARM1 == null))
                    )
                {
                    try
                    {
                        IWDriver.FindElement(By.Id(inTestrec.ITEMURL)).SendKeys(inTestrec.SPARM1);
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL);
                        return restultRec;
                    }
                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }
            
                //assertTrue(actualString.contains("specific text"));
                restultRec.setResult("OK");
                restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                return restultRec;
            }


            if ((inTestrec.CMD.ToString() == "INPUTCONTROLTEXT") && (inTestrec.SUBCMD.ToString() == "ASSERT"))
            {
                restultRec.setResult("PARMS");
                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "NAME") &&
                    (!(inTestrec.ITEMURL == null)) &&
                    // (!(inTestrec.IPARM1 == null)) &&
                    (!(inTestrec.SPARM1 == null))
                    )
                {
                    string tempStr; 
                    try
                    {
                        tempStr = IWDriver.FindElement(By.Name(inTestrec.ITEMURL)).GetAttribute("value"); // SendKeys(inTestrec.SPARM1);
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL);
                        return restultRec;
                    }
                    if (!(tempStr.Trim() == inTestrec.SPARM1.Trim()))
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("Wrong Option is select list location:" + tempStr.Trim() + " Expecting: " + inTestrec.SPARM1);
                        return restultRec;
                    }

                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }



                if ((inTestrec.ITEM_TYPE.ToString() == "TEXT") &&
                    (inTestrec.ITEM_URLTYPE.ToString() == "ID") &&
                    (!(inTestrec.ITEMURL == null)) &&
                    // (!(inTestrec.IPARM1 == null)) &&
                    (!(inTestrec.SPARM1 == null))
                    )
                {
                    string tempStr;
                    try
                    {
                        tempStr = IWDriver.FindElement(By.Id(inTestrec.ITEMURL)).GetAttribute("value");
                    }
                    catch (OpenQA.Selenium.NoSuchElementException)
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("No Element Name:" + inTestrec.ITEMURL);
                        return restultRec;
                    }
                    if (!(tempStr.Trim() == inTestrec.SPARM1.Trim()))
                    {
                        restultRec.setResult("ERROR");
                        restultRec.setRESULTMESSAGE("Wrong Option is select list location:" + tempStr.Trim() + " Expecting: " + inTestrec.SPARM1);
                        return restultRec;
                    }

                    restultRec.setResult("OK");
                    restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                    return restultRec;
                }

                //assertTrue(actualString.contains("specific text"));
                restultRec.setResult("OK");
                restultRec.setRESULTMESSAGE(inTestrec.ITEMURL.ToString());
                return restultRec;
            }

            //================================================================= END TESTS
            //================================================================= END TESTS
            //================================================================= END TESTS

            if ((inTestrec.CMD.ToString() == "KILL"))
            {
                try
                {
                    IWDriver.Close();
                    IWDriver.Quit();
                    IWDriver.Dispose();
                }
                catch {
                    MessageBox.Show("Closed", "Closed");
                }
            }

            return restultRec;
        }
                /*
                 * By Xpath:

                 button[@type = 'submit']
                 button[@class = 'btn btn-success']
                 button[@type = 'submit'][@class = 'btn btn-success']
                 By css selector:

                 button[type = 'submit']
                 button[class='btn btn-success']
                 button[type = 'submit'][class='btn btn-success']
                
                //By Partial link text


                 IWDriver.Url = inTestrec.ITEMURL;
                 String URL = IWDriver.Url;  //IWDriver.getCurrentUrl();
                 if (URL != inTestrec.ITEMURL)
                 {
                     restultRec.setResult("ERROR");
                     return restultRec;
                 }

                 // List<WebElement> list = driver.findElements(By.xpath("//span[@class = 'required']//..//..//label"));
                 // By.xpath("//h4[contains(text(),'Some regular text ')]" +
                 // "/descendant::strong[contains(text(), 'followed by strong text')]"
                 //h2[text()[contains(.,'===Radio Buttons')]]

                 for (int i = 0; i < list.size(); i++)
                 {
                     Thread.sleep(2000);
                     String name = list.get(i).getText();

                     System.out.println(name);

                 }

                 return restultRec;
             }




             return restultRec;
         }
                */

         /*
         public String ExplicitWait(String Item)
         {
             //WebDriverWait wait = new WebDriverWait(this.gdriver, 40);
             //WebElement element = wait.until(ExpectedConditions.elementToBeClickable(By.id("someid")));

             //this.gdriver.wait(this.gdriver.executeScript("return document.readyState").then(state => {
             //    return state == 'complete';
             }
         }
         */

                /*  public String AssertCurrentUrl(IWebDriver IWDriver, String testURL) {
                  TestHelper.Pause(3000);
                  String URL = IWDriver.getCurrentUrl(); 
                      if (!(URL == testURL)) {
                          return URL;
                      }
                      return "FAIL";
                  }
                  */
                /*

                [Fact]
                [Trait("Category", "Smoke")]
                public void LoadURLPage()
                {
                    using (IWebDriver driver = new ChromeDriver())
                    {
                        driver.Url = testrec.ITEMURL;
                  //      TestHelper.Pause(3000);
                //        driver.Url = "http://demo.guru99.com/test/guru99home/";
                        driver.Manage().Window.Maximize();
                    }
                }  

                */


            }
        }