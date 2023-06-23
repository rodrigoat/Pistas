using PistasProvider.Models;

namespace PistasProvider.Interfaces
{
    public interface IPista
    {
        ICollection<PistaHistory> History { get; set; }
        ICollection<ISurtidor> Surtidores { get; set; }

        void RegisterOperation(PistaHistory surtidorHistory);
        void RegisterSurtidores();
    }
}