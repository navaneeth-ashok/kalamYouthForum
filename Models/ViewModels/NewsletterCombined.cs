using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KalamYouthForumWebApp.Models.ViewModels
{
    public class NewsletterCombined
    {
        public IEnumerable<string> shgMembersEmail { get; set; }
        public string commaSeperatedMailingListSHG { get; set; }
        public IEnumerable<string> registeredMembersEmail { get; set; }
        public string commaSeperatedMailingListRegistered { get; set; }
        public IEnumerable<NewsletterList> newsletterUsersEmail { get; set; }
        public string commaSeperatedMailingListNewsLetter { get; set; }
        public string commaSeperatedMailingList { get; set; }
    }
}
