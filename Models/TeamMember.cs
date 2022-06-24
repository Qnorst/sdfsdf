using System;
using System.Collections.Generic;

namespace TaskSearchWPF.Models
{
    public partial class TeamMember
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public int InTeamStatusId { get; set; }
        public int TeamMembersId { get; set; }

        public virtual InTeamStatus InTeamStatus { get; set; } = null!;
        public virtual Team Team { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
