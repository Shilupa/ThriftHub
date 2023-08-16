using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
	public class Review
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Review")]
        public string? UserReview { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public DateTime PublishedDate { get; set; }

        public int ProductId { get; set; }

        public string? ApplicationUserId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}

