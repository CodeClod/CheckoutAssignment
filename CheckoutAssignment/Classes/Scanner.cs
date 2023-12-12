namespace CheckoutAssignment.Classes;

public class Scanner
{
    public delegate void VareScannetEventHandler(object sender, char varekode);
    public event VareScannetEventHandler VareScannetEvent;

    public void StartScanning()
    {
        while (true)
        {
            Console.WriteLine("Indtast varekode ('Q' for at afslutte): ");
            char varekode = char.ToUpper(Console.ReadKey().KeyChar);
            
            // Delay for scanning
            Thread.Sleep(500);

            if (varekode == 'Q')
            {
                Console.WriteLine("Scanning afsluttet");
                break;
            }
                

            Console.WriteLine("Scan another item");
            OnVareScannet(varekode);
        }
    }

    private void OnVareScannet(char varekode)
    {
        VareScannetEvent?.Invoke(this, varekode);
    }
}