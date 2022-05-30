using System;
using System.Collections.Generic;

namespace EncyclopediaOfHadiths.Models
{
    public partial class HadithsChapter
    {
        public long HadithId { get; set; }
        public long ChapterId { get; set; }

        public virtual Chapter Chapter { get; set; } = null!;
        public virtual Hadith Hadith { get; set; } = null!;
    }
}
