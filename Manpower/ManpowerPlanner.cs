
namespace ManpowerApp.Manpower
{
    public class ManpowerPlanner
    {
        private  List<Employee> employees;
        private List<Employee> employees2;
        private  List<Tasks> _tasks;

        public ManpowerPlanner(List<Employee> employees, List<Employee> employees2, List<Tasks> tasks)
        {
            this.employees = employees;
            this.employees2 = employees2;
            this._tasks = tasks;
        }

        // Implement the manpower planning logic here
        public List<Assignment> GenerateAssignments()
        {
            var assignments = new List<Assignment>();

            // Sort tasks by priority
            var prioritizedTasks = _tasks.OrderByDescending(t => t.IsPriority).ToList();
            var day = 1;
            var i = 1;
            
            foreach (var task in prioritizedTasks)
            {
                var eligibleEmployees = employees.Where(e => e.Skills.Contains(task.SkillRequired)).ToList();
                var assignedEmployee = eligibleEmployees.FirstOrDefault();

                if (assignedEmployee != null)
                {
                    assignments.Add(new Assignment(task.TaskId, assignedEmployee.EmpName, day));
                    employees.Remove(assignedEmployee);
                    i++;
                }
               
                if (i == employees2.Count())
                {
                    day++;
                    i = 1;
                    employees = employees2.ToList() ;
                }
            }
            if (employees.Count() != employees2.Count())
                employees = employees2;

            // Assign remaining tasks to employees
            foreach (var task in _tasks)
            {
                if (!assignments.Any(a => a.TaskId == task.TaskId))
                {
                    var eligibleEmployees = employees.Where(e => e.Skills.Contains(task.SkillRequired)).ToList();
                    var assignedEmployee = eligibleEmployees.FirstOrDefault();

                    if (assignedEmployee != null)
                    {
                        assignments.Add(new Assignment(task.TaskId, assignedEmployee.EmpName, day));
                        employees.Remove(assignedEmployee);
                        i++;
                    }
                    
                }

                
                if (i == employees2.Count())
                {
                    day++;
                    i = 1;
                    employees = employees2.ToList();
                }
            }

            return assignments;
        }
    }
}
