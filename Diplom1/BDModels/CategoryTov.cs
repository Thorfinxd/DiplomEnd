using System;
using System.Collections.Generic;

namespace Diplom1
{
    public partial class CategoryTov
    {
        public CategoryTov()
        {
            TovarCategoryCategories = new HashSet<Tovar>();
            TovarTovarCategories = new HashSet<Tovar>();
        }

        public int CaterogyTovid { get; set; }
        public string Category { get; set; } = null!;
        public int TovarTovarId { get; set; }

        public virtual Tovar TovarTovar { get; set; } = null!;
        public virtual ICollection<Tovar> TovarCategoryCategories { get; set; }
        public virtual ICollection<Tovar> TovarTovarCategories { get; set; }
    }
}
