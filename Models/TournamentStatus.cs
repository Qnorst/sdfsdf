using System;
using System.Collections.Generic;

namespace TaskSearchWPF.Models
{
    public partial class TournamentStatus
    {
        public TournamentStatus()
        {
            Tounaments = new HashSet<Tounament>();
        }

        public int TournamentStatusId { get; set; }
        public string TournamentStatusName { get; set; } = null!;

        public virtual ICollection<Tounament> Tounaments { get; set; }
    }
}
