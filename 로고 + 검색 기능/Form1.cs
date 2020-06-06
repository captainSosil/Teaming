using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Logo
{

    public partial class Form1 : Form
    {
        Thread Search_1 = null;
        Thread Upload_1 = null;

        IWebDriver driver = null;
        String[,] str = null;

        int num1 = 0;
        int num2 = 0;

        int eCount = 0;
        int Forcount=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://search.naver.com/search.naver?sm=tab_hty.top&where=nexearch&query="+textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Search_1 = new Thread(Search1);
            lock (this)
            { 
                Search_1.Start();
            }

        }
        private void Search1()
        {
            driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Url = "https://www.google.com/search?q=" + this.textBox1.Text;

            for (int BTNcounT = 1; BTNcounT < 5; BTNcounT++) //총 4페이지까지의 데이터를 수집합니다.
            {
                Thread.Sleep(10);

                IList<IWebElement> e1 = driver.FindElements(By.ClassName("r"));
                IList<IWebElement> e2 = driver.FindElements(By.ClassName("s"));
                IList<IWebElement> e3 = driver.FindElements(By.ClassName("TbwUpd"));


                if (BTNcounT == 1)
                {
                    eCount = e1.Count * 10;

                    str = new string[e1.Count * 10, 3];
                }

                Forcount = 0;
                foreach (IWebElement i in e1)
                {
                    str[num1, num2] = i.FindElement(By.TagName("h3")).Text;
                    str[num1, num2+1] = e2[Forcount].FindElement(By.TagName("span")).Text;
                    str[num1, num2 + 2] = e3[Forcount].FindElement(By.TagName("cite")).Text;

                    Forcount++;
                    num1++;
                }

                string xpath= "/html/body/div[6]/div[2]/div[9]/div[1]/div[2]/div/div[5]/div[2]/span[1]/div/table/tbody/tr/td["+(BTNcounT+2).ToString()+"]/a/span";

                driver.FindElement(By.XPath(xpath)).Click();
            }

            Upload_1 = new Thread(Upload1);
            lock (this)
            {
                Upload_1.Start();

            }

        }
        private void Upload1()
        {
            ListViewItem item = null;

            for (int i = 0; i < eCount; i++)
            {
                if (str[i, 0] == null)
                    break;

                item = new ListViewItem(new string[] { str[i, 0], str[i, 1],str[i,2] });

                listView1.Items.Add(item);
            }


        }
    }
}
