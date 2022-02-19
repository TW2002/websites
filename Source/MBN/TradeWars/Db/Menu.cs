using System;
using System.Collections.Generic;

namespace TradeWars.Db
{
    public partial class Menu
    {
        public Menu()
        {
            MenuItems = new HashSet<MenuItem>();
        }

        public int MenuId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
