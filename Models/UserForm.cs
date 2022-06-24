using System;
using System.Collections.Generic;

namespace TaskSearchWPF.Models
{
    public partial class UserForm
    {
        public int UserFormId { get; set; }
        public string FormText { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
