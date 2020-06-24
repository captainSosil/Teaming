using CoolSms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Teaming
{
    public partial class Form1 : Form
    {
        private void DBConnect()
        {
            string connectString = "server=(localdb)\\mssqllocaldb;database=teamingTest13;Integrated Security=True;";
            conn = new SqlConnection(connectString);
            if (conn == null)
                MessageBox.Show("DB Error");
            conn.Open();

        }

        SmsApi api = new SmsApi(new SmsApiOptions
        {
            ApiKey = "NCSK3W3PZBPG0DPZ",
            ApiSecret = "NMJOLOX9VISCFDFQCK5IFHRWEJQCLRQZ",
            DefaultSenderId = "발신자번호" // 문자 보내는 사람 번호, coolsms 홈페이지에서 발신자 등록한 번호 필수
        });

        private int goodCnt;
        private int badCnt;
        private SqlConnection conn;
        private SqlCommand comm;
        private string lIndex;
        private Thread myThread;
        private string Email;
        private string password;
        private string name;
        private string phone;
        private string mail2; // 실제 메일
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string head, string body, int num, string Email, string password, string name, string phone, string mail2, string lIndex)
        {
            InitializeComponent();

            this.lIndex = lIndex;
            this.Email = Email;
            this.password = password;
            this.name = name;
            this.phone = phone;
            this.mail2 = mail2;
            
            textBox1.Text = head;
            textBox2.Text = body;


            label2.Visible = false;
                // pictureBox1.Visible = false;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 715;
            this.Height = 674;
                // pictureBox1.Image = imageList1.Images[0];
                // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                DBConnect();
            string query = "select * from Answers where Id='" + lIndex + "'";
            comm = new SqlCommand(query, conn);
            SqlDataReader rdr = comm.ExecuteReader();
            if (rdr.Read())
            {
                this.UserID.Text = rdr[1] + "님";

                goodCnt = Int32.Parse(rdr[31].ToString());
                badCnt = Int32.Parse(rdr[32].ToString());

                good.Text = goodCnt.ToString();
                // good.Text = badCnt.ToString();
                //MessageBox.Show(goodCnt.ToString());
                //MessageBox.Show(badCnt.ToString());

                //selenium으로 파싱한 정보 TView ,LView에 다띄우는거
            }
            else
            {
                // MessageBox.Show("아이디 혹은 비밀번호를 확인하세요.");
            }
            rdr.Close();
            DBClose();

            if (goodCnt >= 3)
            {
                label2.Visible = true;
                // pictureBox1.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void DBClose()
        {
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        private void START()
        {
            try

            {

                // Credentials

                var credentials = new NetworkCredential("lionking6792@gmail.com", "tmxkzmf1!");



                // Mail message

                var mail = new MailMessage()

                {

                    From = new MailAddress("lionking6792@gmail.com"),

                    Subject = "티밍 알림 : 귀하의 아이디어에 팀원 신청이 들어왔습니다!",

                    Body = "귀하의 아이디어에 팀원 신청이 들어왔습니다. 다음의 연락처로 연락해 보시기 바랍니다!! < 이름 : " + name + "메일 주소 : " + Email + "연락처 : " + phone + " >"

                };



                mail.To.Add(new MailAddress(mail2));



                // Smtp client

                var client = new SmtpClient()

                {

                    Port = 587,

                    DeliveryMethod = SmtpDeliveryMethod.Network,

                    UseDefaultCredentials = false,

                    Host = "smtp.gmail.com",

                    EnableSsl = true,

                    Credentials = credentials

                };



                // Send it...         

                client.Send(mail);

                

            }

            catch (Exception ex)

            {
                // MessageBox.Show("메일이 발송이 실패하였습니다!");

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 newForm2 = new Form2(Email, password, name, phone);
            //newForm2.ShowDialog();
            myThread = new Thread(new ThreadStart(START));
            myThread.Start();
            MessageBox.Show("메일이 성공적으로 발송되었습니다!!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:4978/Answers/AnswerIndex#");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            /*
            if(button2.Text == "좋아요")
            {
                button2.Text = "좋아요 취소";

                goodCnt++;

                good.Text = goodCnt.ToString();
            }
            else
            {
                button2.Text = "좋아요";

                goodCnt--;

                good.Text = goodCnt.ToString();
            }

            */
            /*
            //db에 추가
            DBConnect();

            
            query = "select * from userTbl where userId='" + Email + "'";
            comm = new SqlCommand(query, conn);
            SqlDataReader rdr = comm.ExecuteReader();

            if (rdr.Read())
            {
                MessageBox.Show("ID 중복");
            }
            else
            {
                rdr.Close();

                query = "Insert into userTbl(userId,password,name,phone) Values('" + Email + "','" + password + "',N'" + name + "','" + phone + "')";
                // MessageBox.Show(query);
                comm = new SqlCommand(query, conn);


                comm.ExecuteNonQuery();

                MessageBox.Show("회원 가입 완료.!");
            }

            DBClose();
            */
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DBConnect();

                string query = "update Answers set good='" + goodCnt+ "'where Id='" + lIndex + "'";
                // MessageBox.Show(query);
                comm = new SqlCommand(query, conn);


                comm.ExecuteNonQuery();

                // MessageBox.Show("회원 가입 완료.!");
            

            DBClose();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (tempLabel.Text == "* 추천을 하시려면 아이콘을 클릭해주세요!")
            {
                goodCnt++;
                good.Text = goodCnt.ToString();
                tempLabel.Text = "* 추천을 취소하시려면 아이콘을 클릭해주세요!";
            }
            else
            {
                goodCnt--;
                good.Text = goodCnt.ToString();
                tempLabel.Text = "* 추천을 하시려면 아이콘을 클릭해주세요!";
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = Teaming.Properties.Resources.button_on10;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackgroundImage = Teaming.Properties.Resources.button_off10;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.button3.BackgroundImage = Teaming.Properties.Resources.button_on10;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.button3.BackgroundImage = Teaming.Properties.Resources.button_off10;
        }

        private void UserID_Click(object sender, EventArgs e)
        {

        }
    }
}
