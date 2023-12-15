using System.Diagnostics;

namespace CheckoutAssignment.Classes;

public class Scanner
{
    public delegate void VareScannetEventHandler(object sender, char varekode);
    public event VareScannetEventHandler VareScannetEvent;
    
    public void StartScanning()
    {
        Console.WriteLine("Indtast varekoder ('Q' for at afslutte): ");
        while (true)
        {
            char varekode = char.ToUpper(Console.ReadKey().KeyChar);
            
            
            // Quits the program
            if (varekode == 'Q')
            {
                Console.WriteLine("Scanning afsluttet.");
                break;
            }
            
            // Delay for scanning
                        Thread.Sleep(500);
            // For input cleanness 
            
            
            // Sends an event to prisberegner or other event reciever
            OnVareScannet(varekode);
            Console.WriteLine();
            Console.WriteLine("Scan ny vare:");
        }
    }

    private void OnVareScannet(char varekode)
    {
        VareScannetEvent?.Invoke(this, varekode);
    }
}