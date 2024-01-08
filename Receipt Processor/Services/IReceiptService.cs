using System;
using Receipt_Processor.Model;

namespace Receipt_Processor.Services
{
    public interface IReceiptService
    {
        int CalculatePoints(ReceiptModel receipt);
    }
}

