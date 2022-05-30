using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public partial class ReviewTerm
    {
        public ReviewTerm()
        {
            HadithsReviews = new HashSet<HadithsReview>();
        }

        public byte ReviewTermId { get; set; }
        [Required(ErrorMessage = "Review status term can't be null.")]
        [StringLength(50, ErrorMessage = "Length must be less then 50 characters")]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Review status term")]
        public string? ReviewTermTitle { get; set; } 

        public virtual ICollection<HadithsReview> HadithsReviews { get; set; }
    }
}
