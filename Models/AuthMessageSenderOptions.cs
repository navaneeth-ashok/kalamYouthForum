using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser = "Kalam Youth Forum";
        public string SendGridKey = "<receive_key_from_env>";
    }

    
}
