using System;
using System.Collections.Generic;

namespace Diplom1
{
    public partial class Postavshik
    {
        public Postavshik()
        {
            Postavkas = new HashSet<Postavka>();
        }

        public int Postavshikid { get; set; }
        public string? PostavshikName { get; set; }

        public virtual ICollection<Postavka> Postavkas { get; set; }
    }
}
