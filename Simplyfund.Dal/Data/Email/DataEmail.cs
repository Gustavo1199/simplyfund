using Newtonsoft.Json.Linq;
using Simplyfund.Dal.DataInterface.Email;
using Simplyfund.Dal.DataInterface.IBaseDatas;
using SimplyFund.Domain.Models.Client;
using SimplyFund.Domain.Models.Email.NotificationsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using SimplyFund.Domain.Models.Smtp;
using SimplyFund.Domain.Dto.Email;

namespace Simplyfund.Dal.Data.Email
{
    public class DataEmail : IDataEmail
    {

        IBaseDatas<Notification> dataNotification;
        IBaseDatas<Customer> dataCustomer;
        IBaseDatas<Smtp> dataSmtp;
        IBaseDatas<NotificationModule> dataNotificationModule;
        IBaseDatas<NotificationAction> dataNotificationAction;

        public DataEmail(IBaseDatas<Notification> dataNotification, IBaseDatas<Customer> dataCustomer, IBaseDatas<Smtp> dataSmtp, IBaseDatas<NotificationModule> dataNotificationModule, IBaseDatas<NotificationAction> dataNotificationAction)
        {
            this.dataNotification = dataNotification;
            this.dataCustomer = dataCustomer;
            this.dataSmtp = dataSmtp;
            this.dataNotificationModule = dataNotificationModule;
            this.dataNotificationAction = dataNotificationAction;
        }

        public async Task SendMail(RequestEmail request)
        {
            try
            {
                if (request != null)
                {
                   request = await CreateBody(request);
                    if (request != null)
                    {
                        await Main(request);
                    }
                }
                else
                {
                    throw new Exception("Modelo Esta null");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

         async Task<RequestEmail> CreateBody(RequestEmail request)
        {
			try
			{

                var module = await dataNotificationModule.GetAsync(x => x.Name == request.Module);
                if (module != null)
                {
                    var action = await dataNotificationAction.GetAsync(x=>x.Name == request.Action);
                    if (action != null)
                    {

                        var notificacion = await dataNotification.GetAsync(x => x.NotificationActionId == action.Id && x.NotificationModuleId == module.Id);
                        if (notificacion != null)
                        {
                            var body = ReplaceValuesInHtml(notificacion.Body, request.Entity);
                            request.Subject = notificacion.NotificationSubject;
                            request.Body = body;
                           
                            return request;
                        }
                        else
                        {
                            throw new Exception("Notificacion no encontrada");

                        }
                    }
                    else
                    {
                        throw new Exception("Accion no encontrada");
                    }
                }
                else
                {
                    throw new Exception("Modulo no econtrado");
                }

			}
			catch (Exception)
			{

				throw;
			}
        }

         string ReplaceValuesInHtml(string html, Dictionary<string, string> mapeo)
        {
            foreach (var kvp in mapeo)
            {
                string clave = "{" + kvp.Key + "}";
                string valor = kvp.Value;
                html = html.Replace(clave, valor);
            }

            return html;
        }


        async Task Main(RequestEmail requestEmail)
        {
            var smtpConfig = await dataSmtp.GetAsync(x => x.IsActive == true);

            if (smtpConfig != null)
            {
                SmtpClient smtpClient = new SmtpClient(smtpConfig.Server);
                smtpClient.Port = smtpConfig.Port;
                smtpClient.Credentials = new NetworkCredential(smtpConfig.EmailAddress, smtpConfig.Password);
                smtpClient.EnableSsl = true;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(smtpConfig.EmailAddress);

                if (requestEmail.Recipients != null)
                {
                    foreach (var toAddress in requestEmail.Recipients)
                    {
                        mailMessage.To.Add(toAddress);
                    }
                }

                mailMessage.Subject = requestEmail.Subject;
                mailMessage.Body = requestEmail.Body;
                mailMessage.IsBodyHtml = true;
                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error sending email: " + ex.Message);
                }
            }
            else
            {
                throw new Exception("No tenemos un servidor de correo configurado actualmente.");
            }
        }

        //private string ReplaceOnTemplate(string text, object values)
        //{
        //    string openTag = "{";
        //    string closeTag = "}";

        //    while (text.Contains(openTag) && text.Contains(closeTag))
        //    {
        //        int openTagIndex = text.IndexOf(openTag);
        //        int closeTagIndex = text.IndexOf(closeTag);

        //        if (closeTagIndex > openTagIndex)
        //        {
        //            string keyword = text.Substring(openTagIndex + 1, closeTagIndex - openTagIndex - 1);

        //            string? keywordValue = GetNestedPropertyValue(values, keyword);

        //            if (keywordValue != null)
        //            {
        //                string keywordWithTags = openTag + keyword + closeTag;
        //                text = text.Replace(keywordWithTags, keywordValue);
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Property '{keyword}' not found in '{values.GetType().Name}'.");
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Incorrect tag format.");
        //            break;
        //        }
        //    }

        //    return text;
        //}

        //private  string? GetNestedPropertyValue(object obj, string propertyPath)
        //{
        //    string[] properties = propertyPath.Split('.');

        //    foreach (string property in properties)
        //    {
        //        PropertyInfo? propInfo = obj.GetType().GetProperty(property);

        //        if (propInfo != null)
        //        {
        //            obj = propInfo.GetValue(obj);

        //            if (obj == null)
        //            {
        //                return null; // Property in the chain is null
        //            }
        //        }
        //        else
        //        {
        //            return null; // Property not found in the chain
        //        }
        //    }

        //    return obj.ToString();
        //}







        //private static string ReplaceOnTemplate(string text, object values)
        //{
        //    string openTag = "<";
        //    string closeTag = ">";
        //    while (text.Contains(openTag) && text.Contains(closeTag))
        //    {
        //        int openTagIndx = text.IndexOf(openTag);
        //        int closeTagIndx = text.IndexOf(closeTag);
        //        if (closeTagIndx > openTagIndx)
        //        {
        //            string keyword = text.Substring(openTagIndx + 1, closeTagIndx - openTagIndx - 1);
        //            string? keywordValue = "";

        //            PropertyInfo? propInfo = values.GetType().GetProperty(keyword);
        //            if (propInfo != null)
        //            {
                 
        //                keywordValue = propInfo.GetValue(values).ToString();
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Propiedad '{keyword}' no encontrada en '{values.GetType().Name}'.");
        //                break;
        //            }

        //            string keywordWithTags = openTag + keyword + closeTag;
        //            text = text.Replace(keywordWithTags, keywordValue);
        //        }
        //        else
        //        {
        //            Console.WriteLine("Formato de tag incorrecto.");
        //            break;
        //        }
        //    }

        //    return text;
        //}
    }
}
