using System;
using System.ComponentModel.DataAnnotations;

namespace ReimbursementApp.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;
    }
}
