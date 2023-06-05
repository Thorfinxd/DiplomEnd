using System;
using System.Collections.Generic;

namespace Diplom1.BDModels
{
    public partial class Postavka
    {
        public int PostavkaId { get; set; }
        public string PostavkaNameTov { get; set; } = null!;
        public string PostavkaNamePost { get; set; } = null!;
        public int PostavkaKolvo { get; set; }
        public decimal PostavkaCena { get; set; }
        public DateOnly PostavkaDate { get; set; }
        public string? PostavkaDesc { get; set; }
    }
}
