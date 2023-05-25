using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutyak
{
    internal class Kutyak
    {
        public Kutyak(string sor)
        {
            string[] line = sor.Split(';');
            this.Azon = Convert.ToInt32(line[0]);
            this.Fajta = Convert.ToInt32(line[1]);
            this.NevID = Convert.ToInt32(line[2]);
            this.Ev = Convert.ToInt32(line[3]);
            this.Ellenorzes = line[4];
        }
        public int Azon { get; set; }
        public int Fajta { get; set; }
        public int NevID { get; set; }
        public int Ev { get; set; }
        public string Ellenorzes { get; set; }
    }
    internal class Nevek
    {
        public Nevek(string sor)
        {
            string[] line = sor.Split(';');
            this.KutyaNevId = Convert.ToInt32(line[0]);
            this.KutyaNev = line[1];
        }
        public int KutyaNevId { get; set; }
        public string KutyaNev { get; set; }
    }

    public class TerheltNap
    {
        public string date;
        public int dognum;
        public TerheltNap(string dateadd, int dogadd)
        {
            date = dateadd;
            dognum = dogadd;
        }
    }
    public class Statisztika
    {
        public string Nev;
        public int Db;
        public Statisztika(string nameadd, int db)
        {
            Nev = nameadd;
            Db = db;
        }
    }

}
