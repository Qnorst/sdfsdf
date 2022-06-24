using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSearchWPF.Models;

namespace TaskSearchWPF
{
    internal class Helper
    {
        public static TeamSearchContext db = new TeamSearchContext();
        public static User userSession;
        public static UserForm userForm;
        public static User setUser;
        public static TeamMember teamMember;
        public static UserForm userForma;
        public static Tounament tounament;
    }
}
