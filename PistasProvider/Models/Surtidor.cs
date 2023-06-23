using PistasProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistasProvider.Models;

public class Surtidor : ISurtidor
{
    public int SurtidorId { get; set; }
    public SurtidorStatus Status { get; set; } = SurtidorStatus.Blocked;
    public double PrePaidAmount { get; set; }
    public delegate void RegisterOperationDelegate(PistaHistory surtidorHistory);
    public event RegisterOperationDelegate RegisterOperation;
    public Surtidor(int id)
    {
        SurtidorId = id;
    }
    public void PrePaid(double amount)
    {
        PrePaidAmount = amount;
    }
    public void SetFree()
    {
        Status = SurtidorStatus.Free;
    }
    public void Block()
    {
        PrePaidAmount = default;
        Status = SurtidorStatus.Blocked;
    }
    public void Suply(double amount)
    {
        var finalAmount = PrePaidAmount == 0 ? amount : PrePaidAmount;
        PistaHistory surtidorHistory = new PistaHistory()
        {
            SurtidorId = SurtidorId,
            OperationDate = DateTime.Now,
            PrePaidAmount = PrePaidAmount,
            FinalAmount = finalAmount
        };
        RegisterOperation(surtidorHistory);
        Block();
    }
}
