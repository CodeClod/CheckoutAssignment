namespace CheckoutAssignment.Classes;

public class Vare
{
    public char Kode { get; set; }
    public string Navn { get; set; }
    public decimal Pris { get; set; }
    public bool Pant { get; set; }
    public int Varegruppe { get; set; }
    public int AntalForRabat { get; set; }
    public decimal RabatProcentDecimal { get; set; }

    //public int Antal { get; set; }

    public Vare(char kode, string navn, decimal pris, bool pant, int varegruppe, int antalForRabat, decimal rabatProcentDecimal)
    {
        this.Kode = kode;
        this.Navn = navn;
        this.Pris = pris;
        this.Pant = pant;
        this.Varegruppe = varegruppe;
        this.AntalForRabat = antalForRabat;
        this.RabatProcentDecimal = rabatProcentDecimal;
    }
}