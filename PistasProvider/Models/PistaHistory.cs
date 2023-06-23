using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PistasProvider.Interfaces;

namespace PistasProvider.Models;

public class PistaHistory : IPistaHistory
{
    public int SurtidorId { get; set; }
    public DateTime OperationDate { get; set; }
    public double? PrePaidAmount { get; set; }
    public double? FinalAmount { get; set; }
}
