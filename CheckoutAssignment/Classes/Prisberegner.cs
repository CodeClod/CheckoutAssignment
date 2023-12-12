namespace CheckoutAssignment.Classes;

public class Prisberegner
{
    // Definér en delegate til at håndtere events fra scanneren
    public delegate void VareScannetHandler(Vare vare);

    // Definér eventet
    public event VareScannetHandler VareScannet;

    // Gem scannede varer i en liste
    public List<Vare> scannedeVarer = new List<Vare>();

    // Metode til at håndtere når en vare bliver scannet
    public void HandleVareScannet(Vare vare)
    {
        scannedeVarer.Add(vare);
        VareScannet?.Invoke(vare);
    }

    // Udregne og vise prisen baseret på scannede varer
    public virtual void UdregnOgVisPris()
    {
        decimal totalPris = 0;

        foreach (var vare in scannedeVarer)
        {
            totalPris += BeregnVarePris(vare);
        }

        Console.WriteLine($"Total pris: {totalPris:C}");
    }

    // Hjælpefunktion til at beregne prisen for en enkelt vare
    protected virtual decimal BeregnVarePris(Vare vare)
    {
        // Implementer logik for prisberegning baseret på regler
        // ...

        return vare.Pris;
    }
}