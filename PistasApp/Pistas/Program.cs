using Pistas;
using PistasProvider.Models;
using PistasProvider.Providers;
using System.Globalization;
using System.Text;

bool exit = false;
Pista pista = new();  
PistaProvider pistasProvider = new(pista);
Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
var encoding = Encoding.GetEncoding(1252);
Console.OutputEncoding = encoding;
CultureInfo ci = new("es-ES");
ci.NumberFormat.CurrencySymbol = "€";
CultureInfo.DefaultThreadCurrentCulture = ci; 

while (!exit)
{
    Menu.ShowMenu();
    Console.Write("Seleccione un opcion: ");
    string input = Console.ReadKey(true).KeyChar.ToString();

    switch (input)
    {
        case "1":
            int selectedFree = Menu.SelectSurtidor(pistasProvider.GetSurtidores());
            if (Menu.HasPrePaidOption()) 
            {
                var prePaidAmount = Menu.GetPrePaidAmount();
                pistasProvider.PrePaid(selectedFree, prePaidAmount);
            }
            pistasProvider.SetFree(selectedFree);
            break;

        case "2":
            int selectedBlock = Menu.SelectSurtidor(pistasProvider.GetSurtidores());
            pistasProvider.Block(selectedBlock);
            break;

        case "3":
            Menu.ShowStatusSurtidores(pistasProvider.GetSurtidores());
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey(true);
            break;

        case "4":
            var surtidores = pistasProvider.GetSurtidores();
            int selectedSuply = Menu.SelectSurtidor(surtidores);
            SurtidorStatus selectedSuplyStatus = surtidores.Where(x => x.SurtidorId == selectedSuply).First().Status;
            if (selectedSuplyStatus != SurtidorStatus.Free) 
            {
                Console.WriteLine("Surtidor no disponible para dispensar.");
                Console.WriteLine();
                Console.WriteLine("Presione una tecla para continuar.");
                Console.ReadKey(true);
                break;
            }
            var maxAmount = pistasProvider.GetSurtidor(selectedSuply).PrePaidAmount;
            double suplyAmount = Menu.GetSuplyAmount(maxAmount);
            pistasProvider.Suply(selectedSuply, suplyAmount);
            break;

        case "5":
            Menu.ShowHistory(pistasProvider.GetHistory());
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey(true);
            break;

        case "6":
            Console.WriteLine("Saliendo...");
            exit = true;
            break;

        default:
            Console.WriteLine("Opcion Invalida. Presione una tecla para continuar");
            Console.ReadKey(true);
            break;
    }
}