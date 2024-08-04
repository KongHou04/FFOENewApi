using System.ComponentModel.DataAnnotations;

namespace Customer.DTOs
{
    public class CouponTypeDTO
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        [Range(0, 100)]
        public int PercentValue { get; set; } = 5;

        [Required]
        [Range(0, 1000000)]
        public decimal HardValue { get; set; } = 0;
    }
}
