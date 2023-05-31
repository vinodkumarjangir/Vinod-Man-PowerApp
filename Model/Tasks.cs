using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManpowerApp.Manpower
{
    public class Tasks
    {
        public long TaskId { get; set; }
        public string? SkillRequired { get; set; }
        public bool IsPriority { get; set; }
    }
}
