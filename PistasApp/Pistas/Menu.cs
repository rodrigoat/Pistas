using PistasProvider.Interfaces;
using PistasProvider.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pistas;

public class Menu
{
    public static void ShowMenu() 
    {
        Console.Clear();
        Console.WriteLine("MENU");
        Console.WriteLine("1. Liberar Surtidor");
        Console.WriteLine("2. Blockear Surtidor");
        Console.WriteLine("3. Mostrar estado de surtidores");
        Console.WriteLine("4. Suministrar Producto");
        Console.WriteLine("5. Ver Historial de Operaciones");
        Console.WriteLine("6. Salir");
    }

    public static void ShowSurtidores(ICollection<ISurtidor> surtidores) 
    {
        Console.WriteLine();
        Console.WriteLine("Surtidores ");
        Console.WriteLine("----------------");
        Console.WriteLine();
        foreach (Surtidor surtidor in surtidores)
        {
            Console.WriteLine("{0}. Surtidor {0}", surtidor.SurtidorId);
        }
    }
    public static int SelectSurtidor(ICollection<ISurtidor> surtidores)
    {
        Console.Clear();
        ShowSurtidores(surtidores);
        bool isValid;
        int selected;
        do
        {
            Console.WriteLine();
            Console.WriteLine("Seleccione un surtidor :");
            string input = Console.ReadKey(true).KeyChar.ToString();
            isValid = int.TryParse(input.ToString(), out selected);
            if (!isValid)
            {
                Console.WriteLine("Seleccione un numero de servidor valido.");
            }
        }
        while (!isValid);
        return selected;
    }

    public static void ShowHistory(IEnumerable<IPistaHistory> pistaHistory) 
    {
        foreach (PistaHistory history in pistaHistory)
        {
            Console.WriteLine();
            Console.WriteLine("Surtidor {0}", history.SurtidorId);
            Console.WriteLine("     Fecha: {0} ", history.OperationDate);
            Console.WriteLine("     Monto Prefijado: {0} ", history.PrePaidAmount);
            Console.WriteLine("     Monto Final: {0} ", history.PrePaidAmount);
            Console.WriteLine("------------------");
        }
    }

    public static void ShowStatusSurtidores(ICollection<ISurtidor> surtidores) 
    {
        Console.Clear();
        Console.WriteLine("------------------");
        Console.WriteLine("Surtidores ");
        Console.WriteLine("------------------");
        Console.WriteLine();
        foreach (Surtidor surtidor in surtidores)
        {
            Console.WriteLine();
            Console.WriteLine("Surtidor {0}", surtidor.SurtidorId);
            Console.WriteLine("     Estado: {0} ", surtidor.Status);
            Console.WriteLine("     Prefijado: {0} ", surtidor.PrePaidAmount.ToString("c"));
            Console.WriteLine("------------------");
        }
    }

    public static double GetPrePaidAmount() 
    {
        Console.Clear();
        Console.WriteLine("Ingrese monto a prefijar");
        string prePaidAmount = Console.ReadLine();
        return double.Parse(prePaidAmount);
    }

    public static double GetSuplyAmount(double maxAmount) 
    {
        Console.Clear();
        Console.WriteLine("Ingrese monto a suministrar");
        if (maxAmount != 0)
        {
            Console.WriteLine("Monto maximo a suministrar: {0}", maxAmount.ToString("c"));
        }
        string suplyAmount = Console.ReadLine();
        return double.Parse(suplyAmount);
    }

    public static bool HasPrePaidOption() 
    {
        Console.Clear();
        Console.WriteLine("Desea Prefijar el surtidor?");
        Console.WriteLine("1. Si");
        Console.WriteLine("2. No");
        string prePaid = Console.ReadKey(true).KeyChar.ToString();
        return prePaid.Equals("1");
    }
}
