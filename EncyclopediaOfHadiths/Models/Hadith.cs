using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EncyclopediaOfHadiths.Models
{
    public partial class Hadith
    {
        public Hadith()
        {
            HadithsReviews = new HashSet<HadithsReview>();
            NarratorsChains = new HashSet<NarratorsChain>();
            HadithsHashTags = new HashSet<HadithsHashTag>();

        }

        public long HadithId { get; set; }
        [Display(Name = "Collection title")]
        public byte? CollectionId { get; set; }
        [Required(ErrorMessage = "Hadith number in the collection is required.")]
        [Display(Name = "Hadith number in the collection")]
        public int? HadithNo { get; set; }
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Hadith text can't be null.")]
        [Display(Name = "Hadith text")]
        public string? HadithText { get; set; }
        [Column(TypeName = "ntext")]
        [Display(Name = "Hadith vocabularies explanation")]
        public string? VocabsExplain { get; set; }
        [Display(Name = "Hadith review")]
        public byte? ReviewTermId { get; set; }
        [Display(Name = "Hadith type")]
        public byte? HadithTypeId { get; set; }
        [Display(Name = "Narrators chain")]
        public long? NarratorsChainId { get; set; }
        [Display(Name = "Hadith HashTag")]
        public long? HashTagId { get; set; }

        [Display(Name = "Collection title")]
        public virtual Collection? Collection { get; set; }
        [Display(Name = "Hadith type")]
        public virtual HadithType? HadithType { get; set; }
        public virtual ICollection<HadithsReview> HadithsReviews { get; set; }
        public virtual ICollection<NarratorsChain> NarratorsChains { get; set; }
        public virtual ICollection<HadithsHashTag> HadithsHashTags { get; set; }
    }
}
