using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace ConsoleApp111
{
    class Program
    {
        private Thread m_thread;

        private void START()
        {

        }

            static void Main(string[] args)

            {

                try

                {

                    // Credentials

                    var credentials = new NetworkCredential("lionking6792@gmail.com", "tmxkzmf1!");



                    // Mail message

                    var mail = new MailMessage()

                    {

                        From = new MailAddress("lionking6792@gmail.com"),

                        Subject = "Test email.",

                        Body = "Test email body"

                    };



                    mail.To.Add(new MailAddress("q7896123@naver.com"));



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

                    Console.WriteLine("Error in sending email: " + ex.Message);

                    Console.ReadKey();

                    return;

                }



                Console.WriteLine("Email sccessfully sent");

                Console.ReadKey();

            }

        }

    }




//myThread = new Thread( new ThreadStart(SendMail));
//            myThread.Start();