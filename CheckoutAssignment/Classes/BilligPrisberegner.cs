namespace CheckoutAssignment.Classes;

using System.Linq;
public class BilligPrisberegner : Prisberegner
{
    
    public override decimal BeregnTotalPris()
    {
        // Implementation of cheaper price calculator via an method override
        
        decimal totalPris = 0;
        
        // Group items by their Varekode with LINQ

        var groupedVarer = SolgteVarer.GroupBy(v => v.Kode);
        //groupedVarer.OrderBy(g =>)
        Console.Clear();
        foreach (var group in groupedVarer.OrderBy(group => group.First().Kode))
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
            Console.WriteLine($"Total price for {group.Count()} item(s) with Varekode {group.Key}: {varePris}");
        }
        return totalPris;
    }
    
    public override void BehandleVareScannetEvent(object sender, char varekode)
    {
        base.BehandleVareScannetEvent(sender, varekode);

        Console.WriteLine($"Total pris: {BeregnTotalPris():C}");
    }
}