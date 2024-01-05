using Reservation.Shared.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.Service.MailServices
{
    public class MailService : IMailService
    {
        public Task SendMail(string recipient, string subject, string message)
        {
            //Mail burda gönderilecektir

            return Task.CompletedTask;

        }
    }
}
