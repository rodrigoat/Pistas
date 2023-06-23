using PistasProvider.Interfaces;
using PistasProvider.Providers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PistasProvider.Models;

public class Pista : IPista
{
    public ICollection<ISurtidor> Surtidores { get; set; }
    public ICollection<PistaHistory> History { get; set; }
    public Pista()
    {
        Surtidores = Enumerable.Range(1, 3)
                                .Select(i => new Surtidor(i))
                                .ToList<ISurtidor>();
        RegisterSurtidores();
        History = new List<PistaHistory>();
    }
    public void RegisterOperation(PistaHistory surtidorHistory)
    {
        History.Add(surtidorHistory);
    }
    public void RegisterSurtidores()
    {
        foreach (Surtidor surtidor in Surtidores)
        {
            surtidor.RegisterOperation += RegisterOperation;
        }
    }
}
