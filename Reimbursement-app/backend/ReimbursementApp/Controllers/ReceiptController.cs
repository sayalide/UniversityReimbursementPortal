using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReimbursementApp.Models;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReimbursementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ReceiptController> _logger;

        public ReceiptController(ApplicationDbContext context, ILogger<ReceiptController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // POST: api/receipts
        [HttpPost]
        public async Task<IActionResult> PostReceipt([FromForm] Receipt receipt, [FromForm] IFormFile receiptFile)
        {
            _logger.LogInformation("Processing receipt submission.");

            // Business rule: Ensure all required fields are provided
            if (receipt == null || receiptFile == null)
            {
                _logger.LogWarning("Receipt data or file is missing.");
                return BadRequest("Receipt data or file is missing.");
            }

            // Business rule: Ensure receipt date is within the last 6 months
            if (receipt.Date < DateTime.Now.AddMonths(-6))
            {
                _logger.LogWarning("Receipt date is older than 6 months.");
                return BadRequest("Receipt date must be within the last 6 months.");
            }

            // Business rule: Ensure description is provided
            if (string.IsNullOrWhiteSpace(receipt.Description))
            {
                _logger.LogWarning("Description is missing.");
                return BadRequest("Description is required.");
            }

            // Business rule: Ensure amount is greater than zero
            if (receipt.Amount <= 0)
            {
                _logger.LogWarning("Invalid amount.");
                return BadRequest("Amount must be greater than zero.");
            }

            // Business rule: Ensure the file is an image
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(receiptFile.FileName).ToLower();
            if (!allowedExtensions.Contains(fileExtension))
            {
                _logger.LogWarning("Invalid file type.");
                return BadRequest("Invalid file type. Only .jpg, .jpeg, and .png files are allowed.");
            }

            // Business rule: File size limit (5MB)
            const long maxFileSize = 5 * 1024 * 1024; // 5 MB
            if (receiptFile.Length > maxFileSize)
            {
                _logger.LogWarning("File size exceeds 5MB.");
                return BadRequest("File size exceeds the 5MB limit.");
            }

            var uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(receiptFile.FileName);
            var filePath = Path.Combine(uploadDirectory, fileName);

            try
            {
                // Save the uploaded file
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await receiptFile.CopyToAsync(stream);
                }

                // Store the file path in the receipt model
                receipt.FilePath = filePath;

                // Save the receipt record to the database
                _context.Receipts.Add(receipt);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Receipt uploaded successfully.");

                return CreatedAtAction(nameof(PostReceipt), new { id = receipt.Id }, receipt);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing receipt submission.");
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
