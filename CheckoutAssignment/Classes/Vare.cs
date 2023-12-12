namespace CheckoutAssignment.Classes;

public class Vare
{
    public char Kode { get; set; }
    public string Navn { get; set; }
    public decimal Pris { get; set; }
    public int MultipackAntal { get; set; }
    public int RabatAntal { get; set; }
    public decimal RabatPris { get; set; }
    public bool Pant { get; set; }
    public int Varegruppe { get; set; }
}