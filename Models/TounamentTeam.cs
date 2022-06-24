using System;
using System.Collections.Generic;

namespace TaskSearchWPF.Models
{
    public partial class TounamentTeam
    {
        public int TournamentId { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual Tounament Tournament { get; set; } = null!;
    }
}
