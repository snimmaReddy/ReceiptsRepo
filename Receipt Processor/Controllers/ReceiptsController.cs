using Microsoft.AspNetCore.Mvc;
using Receipt_Processor.InMemoryData;
using Receipt_Processor.Model;
using Receipt_Processor.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Receipt_Processor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReceiptsController : Controller
    {
        private readonly IReceiptService _receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost("process")]
        public IActionResult ProcessReceipt([FromBody] ReceiptModel receiptModel)
        {
            try
            {
                int points = _receiptService.CalculatePoints(receiptModel);

                string receiptId = Guid.NewGuid().ToString();

                // Store the receipt ID
                ReceiptsData.AddReceipt(receiptId, points);

                return Ok(new { id = receiptId });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error processing receipt: {ex.Message}");
            }
        }

        [HttpGet("{id}/points")]
        public IActionResult GetPoints(string id)
        {
            try
            {
                int points = ReceiptsData.GetPoints(id);

                return Ok(new { points });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error retrieving points: {ex.Message}");
            }
        }
    }
}

