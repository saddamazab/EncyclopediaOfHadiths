using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public partial class HadithType
    {
        public HadithType()
        {
            Hadiths = new HashSet<Hadith>();
        }

        public byte HadithTypeId { get; set; }
        [StringLength(300, ErrorMessage = "Length must be less then 300 characters")]
        [Column(TypeName = "nvarchar(300)")]
        [Required(ErrorMessage = "Hadith Type can't be null.")]
        [Display(Name = "Hadith type")]
        public string? HadithTypeTitle { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Note about hadith type")]
        public string? HadithTypeNote { get; set; }

        public virtual ICollection<Hadith> Hadiths { get; set; }
    }
}
