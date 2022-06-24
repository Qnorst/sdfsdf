using System;
using System.Collections.Generic;

namespace TaskSearchWPF.Models
{
    public partial class GameTeam
    {
        public int TeamId { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
    }
}
