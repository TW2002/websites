using System;
using System.Collections.Generic;

namespace TradeWars.Db
{
    public partial class Screen
    {
        public int ScreenId { get; set; }
        public string? Name { get; set; }
        public string? Target { get; set; }
        public string? Image { get; set; }
    }
}
