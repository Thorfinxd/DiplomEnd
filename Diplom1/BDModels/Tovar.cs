using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom1.BDModels
{
    public partial class Tovar
    {
        public Tovar()
        {
            OrdersProducts = new HashSet<OrdersProduct>();
        }

        public int TovarId { get; set; }
        public string NaimTov { get; set; } = null!;
        public decimal CenaEdinica { get; set; }
        public string? DescTov { get; set; }
        public byte[]? Image { get; set; }
        public int? TovarCategoryid { get; set; }
        public int? CategoryCategoryId { get; set; }
        [NotMapped]
        public int TovarsCount { get; set; }

        public virtual CategoryTov? CategoryCategory { get; set; }
        public virtual CategoryTov? TovarCategory { get; set; }
        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
        public override string ToString()
        {
            return NaimTov;
        }
    }
}
