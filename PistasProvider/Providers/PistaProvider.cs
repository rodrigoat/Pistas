using PistasProvider.Interfaces;
using PistasProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistasProvider.Providers;

public class PistaProvider : IPistaProvider
{
    private IPista _pista = new Pista();
    public PistaProvider(IPista pista)
    {
        _pista = pista;
    }
    public void Block(int surtidorId)
    {
        var surtidor = _pista.Surtidores.First(x => x.SurtidorId == surtidorId);
        if (surtidor is not null)
        {
            surtidor.Block();
        }
    }
    public void SetFree(int surtidorId)
    {
        var surtidor = _pista.Surtidores.First(x => x.SurtidorId == surtidorId);
        if (surtidor is not null)
        {
            surtidor.SetFree();
        }
    }
    public void PrePaid(int surtidorId, double amount)
    {
        var surtidor = _pista.Surtidores.First(x => x.SurtidorId == surtidorId);
        if (surtidor is not null)
        {
            surtidor.PrePaid(amount);
        }
    }
    public IEnumerable<IPistaHistory> GetHistory()
    {
        return _pista.History.OrderBy(x => x.FinalAmount).ThenByDescending(x => x.OperationDate);
    }
    public void Suply(int surtidorId, double amount)
    {
        var surtidor = _pista.Surtidores
                .Where(x => x.SurtidorId == surtidorId)
                .First();
        surtidor.Suply(amount);
    }
    public ICollection<ISurtidor> GetSurtidores()
    {
        return _pista.Surtidores;
    }
    public ISurtidor GetSurtidor(int surtidorId)
    {
        return _pista.Surtidores
                .Where(x => x.SurtidorId == surtidorId)
                .First();
    }
}
