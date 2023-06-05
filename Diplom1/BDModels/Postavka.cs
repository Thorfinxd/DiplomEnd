using System;
using System.Collections.Generic;

namespace Diplom1
{
    public partial class Postavka
    {
        public Postavka()
        {
            Tovars = new HashSet<Tovar>();
        }

        public int PostavkaId { get; set; }
        public string PostavkaNameTov { get; set; } = null!;
        public string PostavkaNamePost { get; set; } = null!;
        public int PostavkaKolvo { get; set; }
        public decimal PostavkaCena { get; set; }
        public DateOnly PostavkaDate { get; set; }
        public string? PostavkaDesc { get; set; }
        public int PostavshikPostavshikid { get; set; }

        public virtual Postavshik PostavshikPostavshik { get; set; } = null!;
        public virtual ICollection<Tovar> Tovars { get; set; }
    }
}
