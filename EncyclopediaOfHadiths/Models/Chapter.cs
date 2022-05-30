using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public partial class Chapter
    {
        public long ChapterId { get; set; }
        [StringLength(300, ErrorMessage = "Length must be less then 300 characters")]
        [Column(TypeName = "nvarchar(300)")]
        [Required(ErrorMessage = "Chapter title is required.")]
        [Display(Name = "Chapter title")]
        public string? ChapterTitle { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Chapter vocabularies explanation")]
        public string? ChapterVocabsExplain { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Chapter explanation and criticism")]
        public string? ChapterExplainText { get; set; }
        [Display(Name = "Part title")]
        public int? PartId { get; set; }
        [Display(Name = "Part title")]
        public Part? Part { get; set; } 
    }
}
