using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace CustomExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] ints = { 1, 2, 3 };
                arrayTest(ints);

                MathsTest(5,0); 

                string StudentName = "Sagar";

                ValidateStudent(StudentName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                string HtmlBody = "<h1>"+ ex.Message +"</h1><br/>";
                HtmlBody += "Time:- " + DateTime.Now.ToString() + "<br/>";
                HtmlBody += "Method Path:- " + ex.StackTrace + "<br/>";
                HtmlBody += "<br/><br/><br/><br/><br/><br/><br/><br/><br/>";
                HtmlBody += "This is Computer Generated Mail.No Reply<br/><br/><hr>";
                HtmlBody += "Please Solve the bug soon tech Team<br/>";
                HtmlBody += "O.S.<br/>";
                HtmlBody += "PiTech<br/>";
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress("sagartestuser@hotmail.com");
                    mailMessage.To.Add("owais.sayed@pitechniques.com");
                    mailMessage.Subject = "Sent from Catch Block";
                    mailMessage.Body = HtmlBody;
                    mailMessage.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "smtp.Office365.com";
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("sagartestuser@hotmail.com", "Idontwant@123");
                    smtpClient.EnableSsl = true;

                    try
                    {
                        smtpClient.Send(mailMessage);
                        Console.WriteLine("Email Sent Successfully.");
                    }
                    catch (Exception x)
                    {
                        Console.WriteLine("Error: " + x.Message);
                    }
                    Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
        private static void ValidateStudent(string name)
        {
            name.ToLower();
            if (name != "owais")
                throw new NaamMesabKuchRakhaHaiException();

        }
        private static void MathsTest(int a, int b)
        {
            if (b == 0)
            {
                throw new MathsMeZeroException();
            }
            int c = a / b;
        }

        private static void arrayTest(int[] ints)
        {
            for (int i = 0; i <= ints.Length; i++)
            {
                if (i >= ints.Length)
                {
                    throw new ChotaArrayException();
                }
                Console.WriteLine(ints[i]);
            }
        }
    }
    [Serializable]
    class ChotaArrayException : Exception
    {
        public ChotaArrayException() : base(String.Format("Array Chota Pad Raha")) { }
    }
    [Serializable]
    class MathsMeZeroException : Exception
    {
        public MathsMeZeroException(): base(string.Format("Tera maths kamzor hai")) { }
    }
    [Serializable]
    class NaamMesabKuchRakhaHaiException : Exception
    {
        public NaamMesabKuchRakhaHaiException(): base(string.Format("Khudka naam bhul gaye bitwa")) { }
    }
}
