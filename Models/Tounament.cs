using System;
using System.Collections.Generic;

namespace TaskSearchWPF.Models
{
    public partial class Tounament
    {
        public int TounamentId { get; set; }
        public string TournamentName { get; set; } = null!;
        public string TournamentText { get; set; } = null!;
        public int TournamentStatusId { get; set; }

        public virtual TournamentStatus TournamentStatus { get; set; } = null!;
    }
}
