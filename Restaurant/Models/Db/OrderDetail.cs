﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models.Db
{
    [Table("orderdetails")]
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(0, 1000000)]
        public decimal UnitPrice { get; set; } = 0;

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; } = 1;

        [StringLength(255)]
        public string? Note { get; set; }


        #region Relationship config
        public Guid OrderId { get; set; }

        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }

        #endregion
    }
}
