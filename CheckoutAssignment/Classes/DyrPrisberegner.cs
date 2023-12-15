namespace CheckoutAssignment.Classes;

using System.Linq;
public class DyrPrisberegner : Prisberegner
{
    // Udvid funktionaliteten til at gruppere og sortere varer
    
    public override decimal BeregnTotalPris()
    {
        decimal totalPris = 0;
        Console.Clear();

        // Group items by their Varegruppe with LINQ
        var groupedVarerByVaregruppe = SolgteVarer.GroupBy(v => v.Varegruppe).OrderBy(group => group.First().Varegruppe );
        
        
        
        foreach (var varegruppe in groupedVarerByVaregruppe)
        {
            var groupedVarerByKode = varegruppe.GroupBy(v => v.Kode); // Group by Kode within each Varegruppe
                 
            Console.WriteLine($"Varer fra varegruppe {varegruppe.Key}");
            foreach (var group in groupedVarerByKode.OrderBy(group => group.First().Kode))
            { 
                decimal varePris = 0;
                var vare = group.First();
                
                // Console.WriteLine(vare.Kode);
                
                // Apply discount logic based on item code or other criteria
                int discountPairs = 0;
                int nonDiscountItems = group.Count();
                if (vare.AntalForRabat > 0)
                {
                    discountPairs = group.Count() / vare.AntalForRabat; 
                    nonDiscountItems = group.Count() % vare.AntalForRabat;
                }
                    
                varePris += vare.Pris * nonDiscountItems;
                varePris += vare.Pris * vare.RabatProcentDecimal * vare.AntalForRabat * discountPairs;
                totalPris += varePris;
                Console.WriteLine($" - {group.First().Navn} x {group.Count()}: {varePris}");
            }
        } 
        Console.WriteLine("------------------------------------------------");
        return totalPris;
    }
    
    public override void BehandleVareScannetEvent(object sender, char varekode)
    {
        base.BehandleVareScannetEvent(sender, varekode);

        // Implementer logik for at vise detaljeret liste over solgte varer
        // ...
        
        Console.WriteLine($"Total pris: {BeregnTotalPris():C}");
    }
}