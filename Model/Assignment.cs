using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManpowerApp.Manpower
{
    public class Assignment
    {
        public Assignment() { }
        public Assignment(long taskId, string name,int day) {
            this.TaskId = taskId;
            this.Name = name;
            this.Day = day;
        }
        public long TaskId { get; set; }
        public string Name { get; set; }
        public int Day { get; set; }
    }
}
