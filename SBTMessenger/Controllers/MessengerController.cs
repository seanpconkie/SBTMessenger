using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SBTMessenger.Model;
using SBTMessenger.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SBTMessenger.Controllers
{
    [Route("api/[controller]")]
    public class MessengerController : Controller
    {

        #region Private Properties
        private readonly IEmailSender _emailSender;
        #endregion

        #region Constructor
        public MessengerController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        #endregion

        // GET: api/values
        [HttpGet]
        public string Get()
        {
            return DateTime.Today.ToShortDateString() + ' ' + DateTime.Now.ToLongTimeString();
        }


        // POST api/values
        [HttpPost(Name = "SendMessage")]
        public async Task<IActionResult> SendAsync([FromBody]Message message)
        {

            if (string.IsNullOrWhiteSpace(message.Email) || string.IsNullOrWhiteSpace(message.FromEmail) || string.IsNullOrWhiteSpace(message.MessageContent))
            {
                return NotFound();
            }

            await _emailSender.SendEmailAsync(message);

            return NoContent();

        }

    }
}
