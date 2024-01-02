using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Net.Mail;
using System.Net;
using Simplyfund.Bll.ServicesInterface.Email;

namespace SimplyFund.Mail.Controllers.Email
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        IServicesEmail servicesEmail;
        public EmailController(IServicesEmail servicesEmail)
        {
            this.servicesEmail = servicesEmail;
        }


        [HttpGet]
        public async Task<ActionResult> SendEmail(string json)
        {

            return Ok(await servicesEmail.SendMail(json));

        }

        [NonAction]
        private void ListenToRabbitMQ()
        {

            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();

            using
            var channel = connection.CreateModel();

            channel.QueueDeclarePassive("emailQueue");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                servicesEmail.SendMail(message);
            };

            channel.BasicConsume(queue: "emailQueue", autoAck: true, consumer: consumer);

            while (true)
            {
                Thread.Sleep(1000); 
            }

        }

        [NonAction]
        public void InitializeConsumerEmail()
        {
            Task.Run(() => ListenToRabbitMQ());
        }


        void Main()
        {
            // Sender's email address and credentials
            string fromAddress = "notificaciones@simplyfund.com.do";
            string password = "CrowdSimply2022"; // Use an App Password if using Gmail

            // Recipient's email address
            string toAddress = "ernestosimetricaprueba@gmail.com";

            // Mail server settings
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;

            // Create and configure the SmtpClient
            SmtpClient smtpClient = new SmtpClient(smtpServer);
            smtpClient.Port = smtpPort;
            smtpClient.Credentials = new NetworkCredential(fromAddress, password);
            smtpClient.EnableSsl = true;

            // Create the MailMessage object
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(fromAddress);
            mailMessage.To.Add(toAddress);
            mailMessage.Subject = "Test Email";
            mailMessage.Body = "This is a test email sent from C#.";

            try
            {
                // Send the email
                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }




    }
}
