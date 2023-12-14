// See https://aka.ms/new-console-template for more information

using CheckoutAssignment.Classes;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        
        Scanner scanner = new Scanner();
        BilligPrisberegner billigPrisBeregner = new BilligPrisberegner();
        //DyrPrisberegner dyrPrisBeregner = new DyrPrisberegner();

        // Subscribe to the item scanned event
        
        scanner.VareScannetEvent += billigPrisBeregner.BehandleVareScannetEvent;
        // scanner.VareScannetEvent += dyrPrisBeregner.BehandleVareScannetEvent;
        

        Console.WriteLine("Hello! Please scan all your wares here.");
        // Start scanning from the console
        scanner.StartScanning();
    }
}