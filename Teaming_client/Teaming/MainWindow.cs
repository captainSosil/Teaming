using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Data.SqlTypes;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Teaming
{
    public partial class MainWindow : Form
    {
        private SqlConnection conn;
        private SqlCommand comm;
        public ChromeOptions options;
        public ChromeDriverService driverService;
        public IWebDriver driver;
        private int nowIndex=0;

        public string Email { get; set; }
        public string password { get; set; }

        public string phone { get; set; }

        public string name { get; set; }

        private void DBConnect()
        {
            string connectString = "server=(localdb)\\mssqllocaldb;database=teamingTest12;Integrated Security=True;";
            conn = new SqlConnection(connectString);
            if (conn == null)
                MessageBox.Show("DB Error");
            conn.Open();
        
        }
        private void DBClose()
        {
            if(conn.State!=ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnSign_Click(object sender, EventArgs e)
        {

            SignWindow sign = new SignWindow();
            sign.Owner = this;
            sign.ShowDialog();

            //db에서 검색 후 통과
            DBConnect();
            string query = "select * from userTBL where userId='" + Email + "' and password='" + password + "'";
            comm = new SqlCommand(query, conn);
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.Read())
            {
                
                MenuPanel.Visible = false;
                MainPanel.Visible = true;

                UserID.Text = Email + "님 환영합니다.";

                // MessageBox.Show(rdr.GetString(3));

                name = rdr.GetString(2);
                phone = rdr.GetString(3);

                //selenium으로 파싱한 정보 TView ,LView에 다띄우는거
            }
            else
            {
                MessageBox.Show("아이디 혹은 비밀번호를 확인하세요.");
            }
            rdr.Close();
            DBClose();  
        }


        private void BtnRegister_Click(object sender, EventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.Owner = this;
            register.ShowDialog();

            //db에 추가
            DBConnect();
            
            
            string query = "select * from userTbl where userId='" + Email + "'";
            comm = new SqlCommand(query, conn);
            SqlDataReader rdr=comm.ExecuteReader();

            if(rdr.Read())
            {
                MessageBox.Show("ID 중복");
            }
            else{
                rdr.Close();

                query = "Insert into userTbl(userId,password,name,phone) Values('" + Email + "','" + password + "',N'" + name + "','" + phone + "')";
                // MessageBox.Show(query);
                comm = new SqlCommand(query, conn);


                comm.ExecuteNonQuery();
         
                MessageBox.Show("회원 가입 완료.!");
            }
            
            DBClose();
        }
        private void trv_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            ListViewItem item;
            try
            {
                LView.Items.Clear();

                string PageIndex = e.Node.FullPath.Substring(0,1);
                // MessageBox.Show(PageIndex);

                driver.Navigate().GoToUrl("http://localhost:4978/Answers/AnswerIndex?BoardName=&Page="+nowIndex.ToString());

                //LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                int i, cnt = 0;
                for (i = 0; i < 10; i++)
                {
                    try
                    {
                        string sss6 = driver.FindElement(By.XPath("/html/body/form/div[3]/main/div/div/div/div/div/div/table/tbody/tr[1]/td/div[2]/div/table/tbody/tr["+(i+2).ToString()+"]/td[1]")).Text;
                        string sss = (cnt + 1).ToString();
                        string sss2 = driver.FindElement(By.XPath("/html/body/form/div[3]/main/div/div/div/div/div/div/table/tbody/tr[1]/td/div[2]/div/table/tbody/tr[" + (i + 2).ToString() + "]/td[2]")).Text;
                        string sss3 = driver.FindElement(By.XPath("//*[@id=\"MainContent_ctlBoardList_lnkTitle_" + i.ToString() + "\"]")).Text;
                        string sss4 = driver.FindElement(By.XPath("/html/body/form/div[3]/main/div/div/div/div/div/div/table/tbody/tr[1]/td/div[2]/div/table/tbody/tr[" + (i + 2).ToString() + "]/td[5]")).Text;
                        string sss5 = driver.FindElement(By.XPath("/html/body/form/div[3]/main/div/div/div/div/div/div/table/tbody/tr[1]/td/div[2]/div/table/tbody/tr[" + (i + 2).ToString() + "]/td[7]")).Text;
                        item = LView.Items.Add(sss);
                        item.SubItems.Add(sss2);
                        item.SubItems.Add(sss3);
                        item.SubItems.Add(sss4);
                        item.SubItems.Add(sss5);
                        item.SubItems.Add(sss6);

                        cnt++;

                    }
                    catch
                    {
                        continue;
                    }
                }

            }catch(Exception ex)
            {

            }
        }

        public void OpenItem(ListViewItem item)
        {

            int now = LView.SelectedIndices[0];

            //MessageBox.Show(now.ToString());

            string lIndex = LView.Items[now].SubItems[5].Text;
            // MessageBox.Show(LView.Items[now].SubItems[1].Text);

            int numberIndex = Int32.Parse(LView.Items[now].SubItems[4].Text);



            driver.Navigate().GoToUrl("http://localhost:4978/Answers/AnswerDetails?Id=" +lIndex.ToString()) ;

            string title = driver.FindElement(By.XPath("//*[@id=\"MainContent_lblTitle\"]")).Text;
            string body = driver.FindElement(By.XPath("//*[@id=\"MainContent_lblContent\"]")).Text;
            string mail = driver.FindElement(By.XPath("/html/body/form/div[3]/main/div/div/div/div/div/div/table/tbody/tr[2]/td[4]/span/a")).Text;

            Form1 newForm = new Form1(title, body, numberIndex, Email, password, name, phone, mail);
            newForm.ShowDialog();
        }

        public void OpenFiles()
        {
            ListView.SelectedListViewItemCollection siList;
            siList = LView.SelectedItems;

            foreach(ListViewItem item in siList)
            {
                OpenItem(item);
            }

        }

        private void lvw_DoubleClick(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tview.Nodes.Clear();
            driver.Navigate().GoToUrl("http://localhost:4978/Answers/AnswerIndex?BoardName=&Page=1");
            string sss;
            int sub;

                try
                {
                    sss = driver.FindElement(By.XPath("/html/body/form/div[3]/main/div/div/div/div/div/div/table/tbody/tr[1]/td/div[1]")).Text;

                    sub = Int32.Parse(sss.Substring(14));
                   // MessageBox.Show(sub.ToString());

                int tmpCnt = sub / 10 + 1;

                nowIndex = tmpCnt;

                TreeNode root;
                int i;
                for(i = 1; i <= tmpCnt; i++)
                {
                    root = Tview.Nodes.Add(i.ToString() + "번 페이지");
                    root.ImageIndex = 0;
                }
            }
                catch (Exception ex)
                {
                    
                }

            
            

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LView.View = View.Details;
            LView.Columns.Add("글 번호", "글 번호");
            LView.Columns.Add("분류", "분류");
            LView.Columns.Add("제목", "제목");
            LView.Columns.Add("작성자", "작성자");
            LView.Columns.Add("조회수", "조회수");

            options = new ChromeOptions();
            driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;
            options.AddArgument("--headless");

            driver = new ChromeDriver(driverService, options);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            driver.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 newForm2 = new Form2(driver);
            newForm2.ShowDialog();
        }

        private void Tview_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void 창닫기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void 창닫기ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:4978/Answers/AnswerIndex#");
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
