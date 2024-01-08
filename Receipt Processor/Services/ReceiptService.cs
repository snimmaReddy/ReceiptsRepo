using Receipt_Processor.Model;

namespace Receipt_Processor.Services
{
	public class ReceiptService:IReceiptService
	{
        public int CalculatePoints(ReceiptModel receipt)
        {
            int points = 0;

            // Rule 1: One point for every alphanumeric character in the retailer name.
            points += receipt.Retailer.Count(char.IsLetterOrDigit);

            // Rule 2: 50 points if the total is a round dollar amount with no cents.
            if (receipt.Total % 1 == 0)
            {
                points += 50;
            }

            // Rule 3: 25 points if the total is a multiple of 0.25.
            if (receipt.Total % 0.25m == 0)
            {
                points += 25;
            }

            // Rule 4: 5 points for every two items on the receipt.
            points += (int)(receipt.Items.Count / 2) * 5;

            // Rule 5: If the trimmed length of the item description is a multiple of 3,
            // multiply the price by 0.2 and round up to the nearest integer.
            // The result is the number of points earned.
            foreach (var item in receipt.Items)
            {
                if (item.ShortDescription.Trim().Length % 3 == 0)
                {
                    points += (int)Math.Ceiling(item.Price * 0.2m);
                }
            }

            // Rule 6: 6 points if the day in the purchase date is odd.
            if (receipt.PurchaseDate.Day % 2 != 0)
            {
                points += 6;
            }

            // Rule 7: 10 points if the time of purchase is after 2:00pm and before 4:00pm
            var purchaseTime = receipt.PurchaseTime.Split(":");
            if (purchaseTime[0] == "14" || purchaseTime[0] == "15")
            {
                points += 10;
            }
            else if (purchaseTime[0] == "16" && int.Parse(purchaseTime[1]) <= 60)
            {
                points += 10;
            }

            return points;
        }
    }
}

