using PistasProvider.Models;

namespace PistasProvider.Interfaces
{
    public interface IPistaProvider
    {
        void Block(int surtidorId);
        IEnumerable<IPistaHistory> GetHistory();
        ISurtidor GetSurtidor(int surtidorId);
        ICollection<ISurtidor> GetSurtidores();
        void PrePaid(int surtidorId, double amount);
        void SetFree(int surtidorId);
        void Suply(int surtidorId, double amount);
    }
}