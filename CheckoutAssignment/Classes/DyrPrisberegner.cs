namespace CheckoutAssignment.Classes;

using System.Linq;
public class DyrPrisberegner : Prisberegner
{
    // Udvid funktionaliteten til at gruppere og sortere varer
    public override void UdregnOgVisPris()
    {
        base.UdregnOgVisPris();

        var grupperedeVarer = scannedeVarer
            .GroupBy(v => v.Varegruppe)
            .Select(grp => new
            {
                Varegruppe = grp.Key,
                AntalStyk = grp.Sum(v => v.MultipackAntal),
            })
            .OrderBy(v => v.Varegruppe);

        Console.WriteLine("\nDyre Prisberegner - Grupperede Varer:");
        foreach (var gruppe in grupperedeVarer)
        {
            Console.WriteLine($"Varegruppe {gruppe.Varegruppe}: {gruppe.AntalStyk} stk");
        }
    }
}