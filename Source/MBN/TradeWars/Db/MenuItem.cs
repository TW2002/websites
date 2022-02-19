using System;
using System.Collections.Generic;

namespace TradeWars.Db
{
    public partial class MenuItem
    {
        public int MenuItemId { get; set; }
        public int? MenuId { get; set; }
        public string? Topic { get; set; }
        public string? Name { get; set; }
        public string? Target { get; set; }
        public string? PageData { get; set; }

        public virtual Menu? Menu { get; set; }
    }
}
