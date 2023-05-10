using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace FinalProject.Models 
{
    public class LoginViewModel
    {
        public string RecipientEmail { get; set; }
        public void PassReset(string recipientEmail)
        {
            // Replace these values with your SMTP settings
            const string SmtpHost = "smtp-relay.sendinblue.com";
            const int SmtpPort = 587;
            const string SmtpUsername = "kieferjacob@hotmail.com";
            const string SmtpPassword = "hdcHQTYz4gPjGWpk";

            // Replace these values with your email content
            string subject = "Password Reset";
            string body = "Click the following link to reset your password: http://localhost:1234/resetpassword?token=abcdef123456";

            // Create a new SMTP client
            SmtpClient client = new SmtpClient(SmtpHost, SmtpPort);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(SmtpUsername, SmtpPassword);
            client.EnableSsl = true;

            // Create a new email message
            MailMessage message = new MailMessage();
            message.To.Add(recipientEmail);
            message.Subject = subject;
            message.Body = body;

            // Send the email
            client.Send(message);
        }

    }
}
