using System;
using System.Collections.Generic;

namespace TradeWars.Db
{
    public partial class Contact
    {
        public int ContactId { get; set; }
        public string? SenderName { get; set; }
        public string? SenderEmail { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
