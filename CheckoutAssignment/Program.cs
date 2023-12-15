// See https://aka.ms/new-console-template for more information

using CheckoutAssignment.Classes;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Scanner instansiation 
        Scanner scanner = new Scanner();
        
        // Based on user choice, instantiate the appropriate PrisBeregner
        Console.WriteLine("Vælg prisberegner: 1 (BilligPrisberegner) eller 2 (DyrPrisberegner)");
        Console.WriteLine("Tryk enter når du har indtastet dit valg");
        int choice = int.Parse(Console.ReadLine());
        Prisberegner prisBeregner;

        
        switch (choice)
        {
            case 1:
                Console.WriteLine("Du har valgt 1.  BilligPrisberegner bruges.");
                prisBeregner = new BilligPrisberegner();
                break;
            case 2:
                Console.WriteLine("Du har valgt 2.  DyrPrisberegner bruges.");
                prisBeregner = new DyrPrisberegner();
                break;
            default:
                Console.WriteLine("Ugyldigt valg. Standardprisberegner (DyrPrisberegner) bruges.");
                prisBeregner = new DyrPrisberegner();
                break;
        }
        
        //BilligPrisberegner billigPrisBeregner = new BilligPrisberegner();
        //DyrPrisberegner dyrPrisBeregner = new DyrPrisberegner();
        
        // Subscribe to the item scanned event
        scanner.VareScannetEvent += prisBeregner.BehandleVareScannetEvent;
        
        
        Console.WriteLine("Hej! Velkommen til terminalen, scan dine varer her.");
        // Start scanning from the console
        scanner.StartScanning();
    }
}