using System;
using System.Collections.Generic;

namespace Diplom1.BDModels
{
    public partial class Order
    {
        public Order()
        {
            OrdersProducts = new HashSet<OrdersProduct>();
        }

        public int OrdersId { get; set; }
        public DateTime OrdersDate { get; set; }
        public int KlientiKlientId { get; set; }

        public virtual Klienti KlientiKlient { get; set; } = null!;
        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
    }
}
