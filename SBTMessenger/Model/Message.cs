using System;
namespace SBTMessenger.Model
{
    public class Message
    {
        #region Poperties
        public string Email { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        #endregion
    }
}
