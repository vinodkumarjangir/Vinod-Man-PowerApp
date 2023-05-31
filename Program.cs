using ManpowerApp.Manpower;
using ManpowerApp.OutPutFile;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace ManpowerApp
{

    class Program
    {
        List<Employee> employees = new List<Employee>();
        List<Employee> employees2 = new List<Employee>();
        List<Tasks> tasks = new List<Tasks>();
        public static string rootFilePath = string.Empty;

        public void Getdetails()
        {
            Console.WriteLine("Executing manpower planning process...");

            var manpowerPlanner = new ManpowerPlanner(employees, employees2, tasks);

            // Generate task assignments
            var assignments = manpowerPlanner.GenerateAssignments();

            Console.WriteLine("Manpower planning process completed!");

            // Save assignments to CSV file
            assignmentRepository.SaveAssignments(assignments, rootFilePath);
            Console.WriteLine("Generated task assignments and save to CSV file!");
        }

        static void Main(string[] args)
        {
            var _dirRoot = System.AppContext.BaseDirectory;
            int _binIndex = _dirRoot.IndexOf("\\bin");
            _dirRoot = _dirRoot.Remove(_binIndex);

            rootFilePath = _dirRoot + "\\Files";

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(_dirRoot)
                   .AddJsonFile("config.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            //Read CSV file path from config.json.
            var employeeFilePath = builder.Build().GetSection("ConnectionFile").GetSection("EmployeeCsvFilePath").Value;
            var taskFilePath = builder.Build().GetSection("ConnectionFile").GetSection("TaskCsvFilePath").Value;


            //creating object of class Program
            Program p = new Program();

            Console.WriteLine("Loading data...");

            p.ReadCSVDataForEmployee(employeeFilePath);
            p.ReadCSVDataForTask(taskFilePath);

            Console.WriteLine("Data loaded successfully!");

            p.Getdetails(); // Calling method
                        
            Console.ReadKey();
        }

        /// <summary>
        /// Read data from Employee CSV file.
        /// </summary>
        /// <param name="path"></param>
        public void ReadCSVDataForEmployee(string path)
        {
            //var path = @"E:\ManpowerApp\Files\Employee.csv"; 
            using (TextFieldParser csvParser = new TextFieldParser(@path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    employees.Add(new Employee { EmpId = (long)Convert.ToInt64(fields[0]), EmpName = fields[1], Skills = fields[2] });
                    employees2.Add(new Employee { EmpId = (long)Convert.ToInt64(fields[0]), EmpName = fields[1], Skills = fields[2] });
                }
            }
        }

        /// <summary>
        /// Read data from task CSV file.
        /// </summary>
        /// <param name="path"></param>       
        public void ReadCSVDataForTask(string path)
        {
            //var path = @"E:\ManpowerApp\Files\Task.csv";
            using (TextFieldParser csvParser = new TextFieldParser(@path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    tasks.Add(new Tasks { TaskId = (long)Convert.ToInt64(fields[0]), SkillRequired = fields[1], IsPriority = IsValid(fields[2]) });
                }
            }
        }

        /// <summary>
        /// Convert CSV column value in bool variable.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsValid(string? value)
        {
            if (!string.IsNullOrEmpty(value) && value == "Yes")
                return true;
            else
                return false;
        }
    }
}



