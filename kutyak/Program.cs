using kutyak;
using System.Text;
namespace Kutyák
{
    class Program
    {
        public static List<Nevek> KutyaNevLista = new List<Nevek>();
        public static List<Fajtak> KutyaFajtaLista = new List<Fajtak>();
        public static List<Kutyak> KutyaLista = new List<Kutyak>();
        static void Main(string[] args)
        {
            Beolvasas();
            BeolvasNev();
            BrolvasFajta();
            AtlagEletkor();
            Legidossebb();
            Datum();

            Console.ReadLine();
        }
        static void BeolvasNev()
        {
            StreamReader read = new StreamReader("KutyaNevek.csv", Encoding.Default);
            string line = read.ReadLine();
            while (!read.EndOfStream)
            {
                KutyaNevLista.Add(new Nevek(read.ReadLine()));
            }
            Console.WriteLine($"nevek szama: {KutyaNevLista.Count}");

        }
        static void BrolvasFajta()
        {
            StreamReader read = new StreamReader("KutyaFajtak.csv", Encoding.Default);
            string line = read.ReadLine();
            while (!read.EndOfStream)
            {
                KutyaFajtaLista.Add(new Fajtak(read.ReadLine()));
            }
        }
        static void Beolvasas()
        {
            StreamReader read = new StreamReader("Kutyak.csv", Encoding.Default);
            string line = read.ReadLine();
            while (!read.EndOfStream)
            {
                KutyaLista.Add(new Kutyak(read.ReadLine()));
            }
        }
        static void AtlagEletkor()
        {
            Console.WriteLine($"atlageletkor: {Math.Round(Convert.ToDouble(KutyaLista.Average(x => x.Ev)), 2)}");
        }
            static void Legidossebb()
        {
            int legidosebb = 0;
            int kereses = 0;
            int keresett = 0;
            for (int i = 0; i < KutyaLista.Count; i++)
            {
                for (int j = 0; j < KutyaFajtaLista.Count; j++)
                {
                    for (int z = 0; z < KutyaNevLista.Count; z++)
                    {
                        if (KutyaLista[i].Ev > KutyaLista[legidosebb].Ev)
                        {
                            if (KutyaLista[i].Fajta == KutyaFajtaLista[j].Id && KutyaLista[i].NevID == KutyaNevLista[z].KutyaNevId)
                            {
                                legidosebb = i;
                                kereses = j;
                                keresett = z;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"legidossebb kutyanev/fajta:{KutyaNevLista[keresett].KutyaNev}, {KutyaFajtaLista[kereses].MagyarNev}");
        }
        static void Datum()
        {
            int[] linq = KutyaLista.Where(x => x.Ellenorzes == "2018.01.10").Select(y => y.Fajta).Distinct().ToArray();
            int[] db = new int[linq.Length];
            for (int i = 0; i < linq.Length; i++)
            {
                for (int j = 0; j < KutyaLista.Count; j++)
                {
                    if (KutyaLista[j].Fajta == linq[i] && KutyaLista[j].Ellenorzes == "2018.01.10")
                    {
                        db[i]++;
                    }
                }
            }
            Console.WriteLine("jan10:");
            for (int i = 0; i < linq.Length; i++)
            {
                Console.WriteLine($"\t{KutyaFajtaLista[KutyaFajtaLista.FindIndex(x => x.Id == linq[i])].MagyarNev},{db[i]} kutya");
            }
        }

    }
}