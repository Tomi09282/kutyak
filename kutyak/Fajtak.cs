using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutyak
{
    internal class Fajtak
    {
        public Fajtak(string sor)
        {
            string[] sorelemek = sor.Split(';');
            this.Id = Convert.ToInt32(sorelemek[0]);
            this.MagyarNev = sorelemek[1];
            this.Eredeti = sorelemek[2];
        }
        public int Id { get; set; }
        public string MagyarNev { get; set; }
        public string Eredeti { get; set; }
    }
}
