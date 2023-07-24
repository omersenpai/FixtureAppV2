using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var teams = new List<string>
        {
            "Fenerbahçe", "Galatasaray", "Beşiktaş", "Trabzonspor",
            "Sivasspor", "Alanyaspor", "Gaziantep FK", "Kasımpaşa",
            "Konyaspor", "Antalyaspor", "Malatyaspor","Samsunspor",
            "Kayserispor", "Hatayspor", "Karagümrük", "Başakşehir",
            "Pendikspor","Adana DemirSspor", "Ç.Rizespor ","Ankaragücü"
        };


        Console.Write("Lütfen takım ismi giriniz: ");
        var team = Console.ReadLine().Trim().ToLower();

        Random random = new Random();
        List<string> randomFiksturler = new List<string>();
        List<string> konumlar = new List<string>();

        while (randomFiksturler.Count < 19)
        {
            //rastgele takım indexi seçme
            int randomIndex = random.Next(teams.Count);
            //Rastgele seçilen indeksteki takım adını  alma 
            string randomFikstur = teams[randomIndex].ToLower();


            //Fikstürün daha önce eklenip eklenmediği ve girilen takım olup olmadığı kontrolü
            if (!randomFiksturler.Contains(randomFikstur) && randomFikstur != team)
            {
                randomFiksturler.Add(randomFikstur);
                var konum = randomFiksturler.Count % 2 == 0 ? "Ev" : "Deplasman";
                konumlar.Add(konum);
            }
        }

        static bool Fikstur(string team)
        {
            return team.ToLower() == "fenerbahçe";
        }


        static void YazdirFikstur(string takim, int devre, List<string> takimlar, List<string> konumlar)
        {
            Console.WriteLine($"\n{takim} {devre}.DEVRE FİKSTÜRÜ:");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("|        RAKİP        |        KONUM        |");
            Console.WriteLine("-------------------------------------------- ");

            for (int i = 0; i < takimlar.Count; i++)
            {
                Console.WriteLine($"{takimlar[i],-21} | {konumlar[i],-19} |");

            }
        }

        if (Fikstur(team))
        {
            YazdirFikstur(team.ToUpper(), 1, randomFiksturler, konumlar);
            YazdirFikstur(team.ToUpper(), 2, randomFiksturler, konumlar.ConvertAll(k => k == "Ev" ? "Deplasman" : "Ev"));
        }
        else if (teams.Contains(team))
        {
            Console.WriteLine("Bu takım için bir fikstür mevcut değil.");
        }
        else
        {
            Console.WriteLine("Geçersiz takım adı.");
        }
    }

}
