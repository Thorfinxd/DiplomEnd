using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diplom1
{
    public partial class Tovar
    {
        public Tovar()
        {
            CategoryTovs = new HashSet<CategoryTov>();
            OrdersProducts = new HashSet<OrdersProduct>();
            Sklads = new HashSet<Sklad>();
        }

        public int TovarId { get; set; }
        public string NaimTov { get; set; } = null!;
        public decimal CenaEdinica { get; set; }
        public string? DescTov { get; set; }
        public byte[]? Image { get; set; }
        public int PostavkaPostavkaId { get; set; }
        public int? TovarCategoryid { get; set; }
        public int? CategoryCategoryId { get; set; }
        [NotMapped]
        public int TovarsCount { get; set; }

        public virtual CategoryTov? CategoryCategory { get; set; }
        public virtual Postavka PostavkaPostavka { get; set; } = null!;
        public virtual CategoryTov? TovarCategory { get; set; }
        public virtual ICollection<CategoryTov> CategoryTovs { get; set; }
        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
        public virtual ICollection<Sklad> Sklads { get; set; }
        public override string ToString()
        {
            return NaimTov;
        }
    }
}
