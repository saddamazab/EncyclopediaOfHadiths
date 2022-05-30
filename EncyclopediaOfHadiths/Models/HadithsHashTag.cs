using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public class HadithsHashTag
    {
        public long Id { get; set; }
        public long HadithId { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }
        public long HashTagId { get; set; }

        public virtual Hadith? Hadith { get; set; }
        public virtual HashTag? HashTag { get; set; }
    }
}
