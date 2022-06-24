using System;
using System.Collections.Generic;

namespace TaskSearchWPF.Models
{
    public partial class InTeamStatus
    {
        public InTeamStatus()
        {
            TeamMembers = new HashSet<TeamMember>();
        }

        public int InTeamStatusId { get; set; }
        public string InTeamStatusName { get; set; } = null!;

        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}
