namespace Legszennyezes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Day> days = new();
            using StreamReader sr = new(
                path: @"..\..\..\src\SO2.txt",
                encoding: System.Text.Encoding.UTF8);
            while (!sr.EndOfStream) days.Add(new(sr.ReadLine()));
            foreach (Day day in days) Console.WriteLine(day.ToString());

            Console.WriteLine("\n3. feladat:");
            List<int> f3 = new();
            int f3Counter = 1;
            foreach (var day in days)
            {
                for (int i = 0; i < day._orak.Count; i++)
                {
                    if (day._orak[i] > 250 && !f3.Contains(f3Counter)) f3.Add(f3Counter);
                }
                f3Counter++;
            }
            foreach (var f in f3) Console.WriteLine($"\tmárcius {f}.");

            Console.WriteLine("\n4. feladat:");
            int f4 = days[0]._orak[0];
            int nap = 0;
            int ora = 0;
            for (int i = 1; i <= days.Count; i++)
            {
                for (int j  = 1; j <= days[i-1]._orak.Count; j++)
                {
                    if (days[i - 1]._orak[j-1] > f4)
                    {
                        f4 = days[i - 1]._orak[j - 1];
                        nap = i;
                        ora = j;
                    }
                }
            }
            Console.WriteLine($"\t{nap}. nap {ora}. órájában volt a legmagasabb: {f4}");

            Console.WriteLine($"\n5. feladat:");
            int f5 = 0;
            for (int i = 1; i <= days.Count; i++)
            {
                for (int j = 1; j <= days[i - 1]._orak.Count; j++)
                {
                    if (days[i - 1]._orak[j - 1] < 100) f5++;
                }
            }
            Console.WriteLine($"\t{f5} alkalommal esett a koncentrácaió 100 alá");

            Console.WriteLine($"\n6. feladat:");
            double f6 = 0;
            int f6Counter = 0;
            for (int i = 1; i <= days.Count; i++)
            {
                for (int j = 1; j <= days[i - 1]._orak.Count; j++)
                {
                    f6 += days[i - 1]._orak[j - 1];
                    f6Counter++;
                }
            }
            f6 = f6 / f6Counter;
            Console.WriteLine($"\tAz átlag érték a hónapban: {f6}");

            Console.WriteLine($"\n7.feladat:");
            int f7Counter = 0;
            nap = 0;
            for (int i = 1; i <= days.Count; i++)
            {
                for (int j = 1; j <= days[i - 1]._orak.Count; j++)
                {
                    f7Counter += days[i - 1]._orak[j-1];
                }
                if (f7Counter / days[i-1]._orak.Count < 60 && nap == 0)
                {
                    nap = i;
                }
                f7Counter = 0;
            }
            if(nap != 0) Console.WriteLine($"\tA {nap}. napon volt az átlag kevesebb mint 60");
            else Console.WriteLine("\tNincs ilyen nap");

            Console.WriteLine("\n8. feladat:");
            var f8 = days[0]._orak;
            for (int i = 1; i <= f8.Count; i++) if (f8[i-1] == f8.Max()) Console.WriteLine($"\tA {i}. órában volt a legmagasabb az érték");

            Console.WriteLine("\n9. feladat:");
            double f9 = 0;
            foreach (var day in days) f9 += day._orak[11];
            f9 /= days.Count;
            Console.WriteLine($"\t A márciusi déli órák átlaga: {f9}");

            Console.WriteLine("\n10. feladat:");
            int f10_1 = 0;
            int f10_2 = 0;
            for (int i = 1; i <= days.Count; i++)
            {
                if (i < days.Count / 2) f10_1 += days[i - 1]._orak.Sum();
                else f10_2 += days[i - 1]._orak.Sum();
            }
            if (f10_1 > f10_2) Console.WriteLine("\tAz első felében volt nagyobb");
            else Console.WriteLine("\tA második felében volt nagyobb");

            Console.ReadLine();
        }
    }
}
