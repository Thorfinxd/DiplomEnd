using System;
using System.Collections.Generic;

namespace Diplom1
{
    public partial class Klienti
    {
        public Klienti()
        {
            Orders = new HashSet<Order>();
        }

        public int KlientId { get; set; }
        public string KlientName { get; set; } = null!;
        public string KlientSurname { get; set; } = null!;
        public string KlientSecondName { get; set; } = null!;
        public string? KlientCompany { get; set; }
        public string? KlientAdres { get; set; }
        public long? KlientPhone { get; set; }
        public string kilentFIO { get
            {
                return KlientSurname + " " + KlientName + " " + KlientSecondName;
            } }
        public virtual ICollection<Order> Orders { get; set; }
        public override string ToString()
        {
            return kilentFIO;
        }
    }
}
