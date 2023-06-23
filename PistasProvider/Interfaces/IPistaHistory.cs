namespace PistasProvider.Interfaces
{
    public interface IPistaHistory
    {
        double? FinalAmount { get; set; }
        DateTime OperationDate { get; set; }
        double? PrePaidAmount { get; set; }
        int SurtidorId { get; set; }
    }
}