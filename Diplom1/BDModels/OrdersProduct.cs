using System;
using System.Collections.Generic;

namespace Diplom1.BDModels
{
    public partial class OrdersProduct
    {
        public int OrdersId { get; set; }
        public int ProductsId { get; set; }
        public int ProductsCount { get; set; }

        public virtual Order Orders { get; set; } = null!;
        public virtual Tovar Products { get; set; } = null!;
    }
}
