Console.WriteLine("OBJEKTI\n");

Slika Slika = new Slika { Tip = Lastnosti.Olje, Visina = 12, Ime = "test", Cena = 50, Podokvir = true, Avtor = "daniel"};

string slika = Slika.ToString();
Console.WriteLine("Objekt -> SLIKA");
Console.WriteLine(slika);


Okvir Okvir = new Okvir { Ime = "zlati les", Material = Lastnosti.Les, Cena = 21 };

string okvir = Okvir.ToString();
Console.WriteLine("\nObjekt -> OKVIR");
Console.WriteLine(okvir);


Zascita Zascita = new Zascita { Ime = "navaden les", Material = Lastnosti.Steklo, Cena = 18 };

string zascita = Zascita.ToString();
Console.WriteLine("\nObjekt -> ZASCITA");
Console.WriteLine(zascita);

Console.WriteLine("\nMetoda -> JE UNIKAT"); // if true -> je unikat, else (false) -> reprodukcija
Slika.jeUnikat(false);


Console.WriteLine("\n\nLASTNOSTI ARTIKLA IN DATUM\n");

List<Artikel> artikli = new List<Artikel>();
Artikel artikel1 = new Artikel { Slika = Slika, Okvir = Okvir, Zascita = Zascita, IzDatum = "7.3.2023" /*tipZascite="test", tveganostZascite="primer"*/  }; // tip & tveganost zascite = null -> DEFAULT VREDNOST
artikli.Add(artikel1);

Console.WriteLine("Izracun za datum: ");
Artikel preveri = new Artikel();
preveri.skrajniDatum(artikel1.IzDatum, artikel1.TipZascite, artikel1.TveganostZascite); // tipZascite & tveganostZascite DEFAULT -> standardno & nekontrolirano okolje

Console.WriteLine("\nRok Poteka: ");
preveri.rokZascite(preveri.TveganostZascite); // tveganost DEFAULT -> nekontrolirano (1.0X)

foreach (Artikel artikel in artikli) // optional: ToString izpis
{
    Console.WriteLine("\nArtikel: ");

    Console.WriteLine("Slika: " + artikel1.Slika + "\n" + "Okvir: " + artikel1.Okvir + "\n" + "Zascita: " + artikel1.Zascita + "\n" + artikel1.IzDatum + "\n" + artikel1.TipZascite + "\n" + artikel1.TveganostZascite);
}

Console.WriteLine("Tip & tveganost zascite: ");
Console.WriteLine(preveri.TipZascite);
Console.WriteLine(preveri.TveganostZascite);

Console.WriteLine("\n\nNAROCILO IZPIS");

List<Narocilo> narocila = new List<Narocilo>();
Narocilo narocilo1 = new Narocilo { Slika = Slika, Okvir = Okvir, Zascita = Zascita, Datum = "19.03.2023", Dobava = 14, Izdano = true };
narocila.Add(narocilo1);

foreach (Narocilo narocilo in narocila) // optional: ToString izpis
{
    Console.WriteLine("\nNarocilo");
    Console.WriteLine("Slika: " + narocilo1.Slika + "\n" + "Okvir: " + narocilo1.Okvir + "\n" + "Zascita: " + narocilo1.Zascita + "\n" + "Datum narocila: " + narocilo1.Datum + "\n" + "Dobava dni: " + narocilo1.Dobava + "\n" + "Izdano: " + narocilo1.Izdano);
}

public enum Lastnosti 
{
    Olje,  // za -> tip slike
    Les,   // za -> material okvirja
    Steklo // za -> material zascite
}

abstract class UnikatSlika
{
    public dynamic Opis { get; set; }
    public abstract void jeUnikat(bool unikat);

    public void IzpisOpisa()
    {
        Console.WriteLine(Opis);
    }

}

class Slika : UnikatSlika
{
    public Lastnosti Tip { get; set; }
    public int Sirina { get; set; }
    public int Visina { get; set; }
    public string Ime { get; set; }
    public int Cena { get; set; }
    public bool Podokvir { get; set; }
    public string Avtor { get; set; }

    public Slika(Lastnosti tip = Lastnosti.Olje, int sirina = 0, int visina = 0, string ime = "", int cena = 0, bool podokvir = false, string avtor = "")
    {
        this.Tip = tip;
        this.Sirina = sirina;
        this.Visina = visina;
        this.Ime = ime;
        this.Cena = cena;
        this.Podokvir = podokvir;
        this.Avtor = avtor;
    }

    public override void jeUnikat(bool unikat)
    {
        if (unikat)
        {
            Console.WriteLine("Unikat (return true).");
        }
        else
        {
            Console.WriteLine("Reprodukcija (return false).");
        }
    }

    public override string ToString()
    {
        return string.Format("tip: {0}, sirina: {1}, visina: {2}, ime: {3}, cena: {4}, podokvir: {5}, avtor: {6}", Tip, Sirina, Visina, Ime, Cena, Podokvir, Avtor);
    }


}

class Okvir
{
    public string Ime { get; set; }
    public int Cena { get; set; }
    public Lastnosti Material { get; set; } // Material Okvirja

    public Okvir(string ime = "", int cena = 0, Lastnosti material = Lastnosti.Les)
    {
        this.Ime = ime;
        this.Cena = cena;
        this.Material = material; // Material Okvirja
    }

    public override string ToString()
    {
        return string.Format("ime: {0}, cena: {1}, material: {2}", Ime, Cena, Material);
    }
}

class Zascita : Okvir
{
    public Lastnosti Material { get; set; } // Material Zascite

    public Zascita(string ime = "", int cena = 0, Lastnosti material = Lastnosti.Steklo) : base(ime, cena, material)
    {
        this.Ime = ime;
        this.Cena = cena;
        this.Material = material; // Material Zascite
    }

    public override string ToString()
    {
        return string.Format("ime: {0}, cena: {1}, material: {2}", Ime, Cena, Material);
    }
}

class Artikel
{
    public Slika Slika { get; set; }
    public Okvir Okvir { get; set; }
    public Zascita Zascita { get; set; }
    public string IzDatum { get; set; }
    public string TipZascite { get; set; }
    public string TveganostZascite { get; set; }

    public void setZascita(string zascita = "standardno")
    {
        this.TipZascite = zascita;
    }

    public void setTveganost(string tveganost = "nekontrolirano okolje") //kontrolirano okolje -> 2.5X
    {
        this.TveganostZascite = tveganost;
    }

    public void skrajniDatum(string datum, string zascita, string tveganost)
    {

        if (datum != null && zascita == null && tveganost == null)
        {
            setZascita();
            Console.WriteLine("Nastavljeno privzeto -> STANDARDNO");

            setTveganost();
            Console.WriteLine("Nastavljeno privzeto -> NEKONTROLIRANO OKOLJE");
        }
        if (datum != null && zascita != null && tveganost == null)
        {
            setTveganost();
            Console.WriteLine("Nastavljeno privzeto -> NEKONTROLIRANO OKOLJE");
        }

    }

    public void rokZascite(string tveganost)
    {
        if (tveganost == "slabe razmere")
        {
            Console.WriteLine("0.5X");
        }
        if (tveganost == "nekontrolirano okolje")
        {
            Console.WriteLine("1.0X");
        }
        if (tveganost == "kontrolirano okolje")
        {
            Console.WriteLine("2.5X");
        }
    }


}

class Narocilo : Artikel
{
    public string Datum { get; set; }
    public int Dobava { get; set; }
    public bool Izdano { get; set; }

}



