using System;
using System.Collections.Generic;

namespace TaskSearchWPF.Models
{
    public partial class Team
    {
        public Team()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        public int TeamId { get; set; }
        public string TeamName { get; set; } = null!;

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
