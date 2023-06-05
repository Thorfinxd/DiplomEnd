using System;
using System.Collections.Generic;

namespace Diplom1
{
    public partial class Sotrudniki
    {
        public int Sotrudnikiid { get; set; }
        public string SotrudnikiName { get; set; } = null!;
        public string SotrudnikiSurname { get; set; } = null!;
        public string SotrudnikiSecondName { get; set; } = null!;
        public string SotrudnikiAdres { get; set; } = null!;
        public long SotrudnikiPhone { get; set; }
    }
}
