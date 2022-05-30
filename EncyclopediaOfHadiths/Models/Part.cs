using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public partial class Part
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PartId { get; set; }
        [Required(ErrorMessage = "Part title can't be null.")]
        [StringLength(300, ErrorMessage = "Length must be less then 300 characters")]
        [Column(TypeName = "nvarchar(300)")]
        [Display(Name = "Part title")]
        public string? PartTitle { get; set; }

        public ICollection<Chapter>? Chapters { get; set; }
    }
}
