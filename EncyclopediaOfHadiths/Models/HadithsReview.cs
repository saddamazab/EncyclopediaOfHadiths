using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EncyclopediaOfHadiths.Models
{
    public partial class HadithsReview
    {
        public long Id { get; set; }
        public long HadithId { get; set; }
        [Column(TypeName = "nvarchar(450)")]
        public string? UserId { get; set; }
        public byte ReviewTermId { get; set; }

        public virtual Hadith? Hadith { get; set; } 
        public virtual ReviewTerm? ReviewTerm { get; set; }

    }
}
