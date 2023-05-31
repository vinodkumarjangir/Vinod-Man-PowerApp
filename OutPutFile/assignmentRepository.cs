using ManpowerApp.Manpower;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ManpowerApp.OutPutFile
{
    public class assignmentRepository
    {
        public static void SaveAssignments(List<Assignment> assignments, string fileRootPath)
        {
            try
            {
                fileRootPath = fileRootPath + "//assignment-sample.CSV";
                using (StreamWriter writer = new StreamWriter(new FileStream(fileRootPath,
                FileMode.Create, FileAccess.Write)))
                {
                    // This is header of the generated file
                    writer.WriteLine("Day, Task Id, Name");

                    foreach (Assignment assignment in assignments.OrderBy(z => z.Day))
                    {
                        writer.WriteLine(assignment.Day + "," + assignment.TaskId + "," + assignment.Name);
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
