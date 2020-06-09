using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        public Form1(string head, string body, int num, string Email, string password, string name, string phone, string mail2)
        {
            InitializeComponent();

            this.Email = Email;
            this.password = password;
            this.name = name;
            this.phone = phone;
            this.mail2 = mail2;
            
            textBox1.Text = head;
            textBox2.Text = body;

            if(num >= 10)
            {
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form2 newForm2 = new Form2(Email, password, name, phone);
            //newForm2.ShowDialog();
            myThread = new Thread(new ThreadStart(START));
            myThread.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:4978/Answers/AnswerIndex#");
        }
    }
}
