using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public partial class Narrator
    {
        public Narrator()
        {
            NarratorsChains = new HashSet<NarratorsChain>();
        }

        public int NarratorId { get; set; }
        [StringLength(300, ErrorMessage = "Length must be less then 300 characters")]
        [Column(TypeName = "nvarchar(300)")]
        [Required(ErrorMessage = "Narrator Name is required.")]
        [Display(Name = "Narrator name")]
        public string? NarratorName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Narrator birth date")]
        public DateTime? NarratorWasBorned { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Narrator death date")]
        public DateTime? NarratorDied { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Information about narrator")]
        public string? NarratorInfo { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Note about narrator")]
        public string? NarratorNote { get; set; }

        public virtual ICollection<NarratorsChain> NarratorsChains { get; set; }
    }
}
