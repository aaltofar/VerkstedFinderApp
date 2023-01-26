using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerkstedFinder;

internal class Verksted
{
    public string Bedriftsnavn { get; set; }
    public string Adresse { get; set; }
    public string Postnummer { get; set; }
    public string Poststed { get; set; }
    public string Godkjenningstyper { get; set; }
    public string Organisasjonsnummer { get; set; }
    public string Godkjenningsnummer { get; set; }

    public Verksted(string bedriftsnavn, string adresse, string postnummer, string poststed, string godkjenningstyper, string organisasjonsnummer, string godkjenningsnummer)
    {
        Bedriftsnavn = bedriftsnavn;
        Adresse = adresse;
        Postnummer = postnummer;
        Poststed = poststed;
        Godkjenningstyper = godkjenningstyper;
        Organisasjonsnummer = organisasjonsnummer;
        Godkjenningsnummer = godkjenningsnummer;
    }


}

