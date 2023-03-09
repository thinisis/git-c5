namespace KiemThuTuDong
{
    [TestFixture]
    public class Tests
    {
        List<Account> lstAcc = ExcelData.ExcelDataToList(@"TestCase\\TestCase.xlsx");
        [Test]
        public void TestLogin()
        {
            for(int i = 0; i < lstAcc.Count; i++)
            {
                ChromeDriverService csv = ChromeDriverService.CreateDefaultService();
                csv.HideCommandPromptWindow = true;
                IWebDriver driver = new ChromeDriver(csv);
                driver.Manage().Window.Maximize();
                driver.Url = "http://thinnguyenvn-001-site1.btempurl.com/Account/Login";
                driver.Navigate();
                var usernameText = driver.FindElement(By.Id("username"));
                var passwordText = driver.FindElement(By.Id("password"));
                usernameText.SendKeys(lstAcc[i].username);
                passwordText.SendKeys(lstAcc[i].password);
                driver.FindElement(By.Id("password")).Submit();
                Thread.Sleep(2000);
                try
                {
                    Console.WriteLine("Test case " + i + " result: ");
                    var msg = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div/div/form/div[1]/div[1]"));
                    if(msg == null)
                    {
                        Console.WriteLine("fail\n");
                    }
                    else
                    {
                        Console.WriteLine("pass\n");
                    }
                }
                catch
                {

                }
                driver.Close();
            }
        }
    }
}