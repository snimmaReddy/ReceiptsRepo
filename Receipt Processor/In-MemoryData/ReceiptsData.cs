namespace Receipt_Processor.InMemoryData
{
    public static class ReceiptsData
    {
        private static readonly Dictionary<string, int> Receipts = new Dictionary<string, int>();

        public static void AddReceipt(string receiptId, int points)
        {
            Receipts[receiptId] = points;
        }

        public static int GetPoints(string receiptId)
        {
            return Receipts.TryGetValue(receiptId, out int points) ? points : 0;
        }
    }
}

