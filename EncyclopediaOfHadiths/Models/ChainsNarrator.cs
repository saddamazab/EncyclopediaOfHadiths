using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EncyclopediaOfHadiths.Models
{
    public partial class NarratorsChain
    {
        public long NarratorsChainId { get; set; }
        [Required]
        [Display(Name = "Narrator name")]
        public int NarratorId { get; set; }
        [Required]
        [Display(Name = "Narrator level in the chain")]
        public byte NarratorLevel { get; set; }
        [Required]
        [Display(Name = "Hadith reference")]
        public long HadithId { get; set; }

        public virtual Hadith? Hadith { get; set; } 
        public virtual Narrator? Narrator { get; set; } 
        public virtual NarratorLevel? NarratorLevelNavigation { get; set; }


        

    }
}
