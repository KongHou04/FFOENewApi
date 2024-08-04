﻿using System.ComponentModel.DataAnnotations;

namespace Customer.DTOs
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }
    }
}
