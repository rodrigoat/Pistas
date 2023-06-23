using PistasProvider.Models;

namespace PistasProvider.Interfaces
{
    public interface ISurtidor
    {
        double PrePaidAmount { get; set; }
        SurtidorStatus Status { get; set; }
        int SurtidorId { get; set; }

        event Surtidor.RegisterOperationDelegate RegisterOperation;

        void Block();
        void PrePaid(double amount);
        void SetFree();
        void Suply(double amount);
    }
}