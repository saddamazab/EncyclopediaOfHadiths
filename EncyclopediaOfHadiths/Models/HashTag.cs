using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public class HashTag
    {
        public HashTag()
        {
            HadithsHashTags = new HashSet<HadithsHashTag>();
        }
        public long HashTagId { get; set; }
        [Required(ErrorMessage = "HashTags can't be null.")]
        [StringLength(50, ErrorMessage = "Length must be less then 200 characters")]
        [Column(TypeName = "nvarchar(200)")]
        [Display(Name = "HashTag")]
        public string? HashTagTitle { get; set; }

        public virtual ICollection<HadithsHashTag> HadithsHashTags { get; set; }
    }
}
