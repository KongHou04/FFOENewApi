﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models.Db
{
    [Table("products")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000000)]
        public decimal UnitPrice { get; set; } = 0;

        [Required]
        [Range(0, 100)]
        public int PercentDiscount { get; set; } = 0;

        [Required]
        [Range(0, 1000000)]
        public decimal HardDiscount { get; set; } = 0;

        [Required]
        public string Image { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "Bit")]
        public bool IsAvailable { get; set; } = true;


        #region Relationship config
        public Guid CategoryId { get; set; }

        public ICollection<ComboDetail> ComboDetails { get; set; } = [];

        #endregion
    }
}
