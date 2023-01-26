

//Lag en C# konsollapp som leser inn JSON-filen som en liste av objekter - hvor du lager klassen som trengs (Tips til google søk: deserialize json C#)
//Lag en meny - brukeren skal kunne velge et fylke
//(se no.wikipedia.org/wiki/Norges_postnumre for mapping av postnr til fylke) og en eller flere godkjenninger.
//Programmet skal liste opp alle verkstedene i valgte fylket som har de valgte godkjenningene. (edited)

using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using VerkstedFinder;

Console.OutputEncoding = System.Text.Encoding.UTF8;
string jsonString = File.ReadAllText("verksteder2.json");

var list = JsonSerializer.Deserialize<List<Verksted>>(jsonString);

foreach (var v in list)
{
    Console.WriteLine(v.Bedriftsnavn);
    Console.WriteLine(v.Godkjenningsnummer);
    Console.WriteLine(v.Adresse);
    Console.WriteLine(v.Godkjenningstyper);
    Console.WriteLine(v.Postnummer);
    Console.WriteLine(v.Poststed);
    Console.WriteLine(v.Organisasjonsnummer);
}
//var verksteder = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Verksted>>(jsonString);


//var verksteder = JsonSerializer.Deserialize<List<Verksted>>(jsonString);
var fylkeListe = new List<(string, int, int)>
{
    ("Oslo",00,12),
    ("Akershus", 13, 15),
    ("Akershus", 19, 21),
    ("Østfold", 15, 18),
    ("Hedmark", 21, 26),
    ("Oppland", 26, 29),
    ("Oppland", 35, 35),
    ("Buskerud", 30, 30),
    ("Aust-Agder", 47, 49),
    ("Vest-Agder", 44, 47),
    ("Møre og Romsdal", 60, 66),
    ("Vestfold", 30, 32),
    ("Buskerud", 33, 36),
    ("Telemark", 36, 39),
    ("Hordaland", 50, 59),
    ("Sør-Trønderlag", 70, 75),
    ("Sør-Trønderlag", 77, 77),
    ("Nord-Trønderlag", 75, 76),
    ("Nord-Trønderlag", 77, 79),
    ("Troms", 84, 84),
    ("Troms", 90, 94),
    ("Nordland", 79, 89),
    ("Finnmark", 91, 91),
    ("Finnmark", 95, 99),
    ("Sogn og Fjordane", 57, 59),
    ("Sogn og Fjordane", 67, 69),
    ("Rogaland", 40, 44),
    ("Rogaland", 55, 55),
};

//var init = new VerkstedInit();
//init.InitializeVerksted(verksteder, fylkeListe);

//for (int i = 0; i < 20; i++)
//{
//    Console.WriteLine(verksteder[i].Bedriftsnavn);
//    Console.WriteLine(verksteder[i].Postnummer);
//}
//foreach (var v in verksteder)
//{
//    Console.WriteLine(v.Postnummer);
//}

while (true)
{
    Console.WriteLine();
    Console.WriteLine("Skriv inn ditt postnummer for å finne verksteder i ditt fylke.");
    Console.Write("Postnummer: ");
    var isNum = int.TryParse(Console.ReadLine(), out int cmdNum);
    while (!isNum)
    {
        do
        {
            Console.WriteLine();
            Console.WriteLine("Jeg kjente ikke igjen postnummeret ditt, prøv igjen.");
            Console.Write("Skriv inn et postnummer: ");
            isNum = int.TryParse(Console.ReadLine(), out cmdNum);
        } while (cmdNum.ToString().Length < 4);
    }

    var postNummerID = cmdNum / 100;

    int fylkeCount = 0;
    var fylkeSearch = new List<string>();
    for (int i = 0; i < fylkeListe.Count; i++)
    {
        if (postNummerID >= fylkeListe[i].Item2 && postNummerID <= fylkeListe[i].Item3)
        {
            fylkeCount++;
            fylkeSearch.Add(fylkeListe[i].Item1);
        }
    }

    if (fylkeCount > 1)
    {
        Console.WriteLine();
        Console.WriteLine("Dette postnummeret er delt mellom begge disse fylkene: ");
        foreach (var fylke in fylkeSearch)
        {
            Console.WriteLine(fylke); ;
        }
    }
    else
    {
        Console.WriteLine();
        Console.WriteLine("Søket ditt matchet dette fylket: ");
        Console.WriteLine(fylkeSearch[0]);
    }




}