using System;
using System.Collections.Generic;

namespace EncyclopediaOfHadiths.Models
{
    public partial class NarratorLevel
    {
        public NarratorLevel()
        {
            NarratorsChains = new HashSet<NarratorsChain>();
        }

        public byte NarratorLevelId { get; set; }

        public virtual ICollection<NarratorsChain> NarratorsChains { get; set; }
    }
}
