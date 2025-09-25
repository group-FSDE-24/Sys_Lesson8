using Sys_Lesson8.Models;

namespace Sys_Lesson8.Extentions;

public static class StudentExtention
{
    public static void PrintStudent(this Student student)
    {
        Console.WriteLine(@$"
                Id: {student.Id + 1}
                FirstName: {student.FirstName}
                LastName: {student.LastName}
                Score: {student.Score.ToString("N2")}
                Group: {student.Group}
                BirthDate: {student.BirthDate.ToShortDateString()}
                Email: {student.Email}
               
        ");
    }
}
