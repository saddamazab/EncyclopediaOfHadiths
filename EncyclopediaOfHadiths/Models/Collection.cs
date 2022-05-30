using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public partial class Collection
    {
        public Collection()
        {
            Hadiths = new HashSet<Hadith>();
        }

        public byte CollectionId { get; set; }
        [StringLength(300, ErrorMessage = "Length must be less then 300 characters")]
        [Column(TypeName = "nvarchar(300)")]
        [Required(ErrorMessage = "Collection title can't be null.")]
        [Display(Name = "Collection title")]
        public string? CollectionTitle { get; set; }
        [StringLength(300, ErrorMessage = "Length must be less then 300 characters")]
        [Column(TypeName = "nvarchar(300)")]
        [Required(ErrorMessage = "Collection ِAuthor can't be null.")]
        [Display(Name = "Collection author")]
        public string? CollectionAuthor { get; set; } 

        public virtual ICollection<Hadith> Hadiths { get; set; }
    }
}
