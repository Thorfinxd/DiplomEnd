using System;
using System.Collections.Generic;

namespace Diplom1
{
    public partial class Sklad
    {
        public int Skladid { get; set; }
        public string NameTov { get; set; } = null!;
        public int Ostatok { get; set; }
        public int TovarTovarId { get; set; }

        public virtual Tovar TovarTovar { get; set; } = null!;
    }
}
