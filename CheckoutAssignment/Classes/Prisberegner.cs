namespace CheckoutAssignment.Classes;

using System.Linq;
public class Prisberegner
{
    public delegate void PrisBeregnetEventHandler(object sender, decimal totalPris);
    public event PrisBeregnetEventHandler PrisBeregnetEvent;
    
    
    protected List<Vare> SolgteVarer { get; set; } = new List<Vare>();
   
    
    public virtual void BehandleVareScannetEvent(object sender, char varekode)
    {
        // Implementer logik for at opdatere listen over solgte varer
        switch (varekode)
        {
            case 'A':
                SolgteVarer.Add(new Vare('A', "Ham Sandwich", 40, false, 1, 0, 1));
                break;
            case 'B':
                SolgteVarer.Add(new Vare('B', "Milk", 17.5m, false, 4, 0, 1));
                break;
            case 'C':
                SolgteVarer.Add(new Vare('C', "Iceberg Salad", 12, false, 3, 0, 1));
                break;
            case 'D':
                SolgteVarer.Add(new Vare('D', "Banana", 3, false, 2 , 4 , 0.9m));
                break;
            case 'E':
                SolgteVarer.Add(new Vare('D', "Banana", 3, false, 2, 4, 0.9m));
                SolgteVarer.Add(new Vare('D', "Banana", 3, false, 2, 4, 0.9m));
                SolgteVarer.Add(new Vare('D', "Banana", 3, false, 2, 4, 0.9m));
                SolgteVarer.Add(new Vare('D', "Banana", 3, false, 2, 4, 0.9m));
                break;
            case 'F':
                SolgteVarer.Add(new Vare('F', "Coca Cola", 7.5m,true, 6, 6, 0.8m));
                break;
            case 'G':
                SolgteVarer.Add(new Vare('G', "Frozen Pizza", 25,false, 7, 0, 1));
                break;
            case 'H':
                SolgteVarer.Add(new Vare('H', "Pineapple", 15,false, 2, 0, 1));
                break;
            case 'I':
                SolgteVarer.Add(new Vare('F', "Coca Cola", 7.5m,true, 6, 6, 0.8m));
                SolgteVarer.Add(new Vare('F', "Coca Cola", 7.5m,true, 6, 6, 0.8m));
                SolgteVarer.Add(new Vare('F', "Coca Cola", 7.5m,true, 6, 6, 0.8m));
                SolgteVarer.Add(new Vare('F', "Coca Cola", 7.5m,true, 6, 6, 0.8m));
                SolgteVarer.Add(new Vare('F', "Coca Cola", 7.5m,true, 6, 6, 0.8m));
                SolgteVarer.Add(new Vare('F', "Coca Cola", 7.5m,true, 6, 6, 0.8m));
                break;
        }
    }
    

    public virtual decimal BeregnTotalPris()
    {
        decimal totalPris = 0;
        
        // Group items by their Varekode with LINQ
        
        // var grouped
        
        var groupedVarer = SolgteVarer.GroupBy(v => v.Kode);
        //groupedVarer.OrderBy(g =>)
        Console.Clear();
        // Interating through all the groups 
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

    public void OnPrisBeregnet(decimal totalPris)
    {
        // Send event med den beregnede pris til alle subscribers
        PrisBeregnetEvent?.Invoke(this, totalPris);
    }
}