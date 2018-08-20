using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBTMessenger.Model;

namespace SBTMessenger.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
