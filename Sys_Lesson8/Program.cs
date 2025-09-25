using Sys_Lesson8.Extentions;
using Sys_Lesson8.Helpers;

namespace Sys_Lesson8;



class Program
{
    static void Main(string[] args)
    {
        //Console.Write("Enter Student Count: ");
        //var countStr = Console.ReadLine();
        //int countStudent = Convert.ToInt32(countStr);

        int countStudent = 15;

        var students = StudentHelper.GenerateStudent(countStudent);

        foreach (var item in students)
        {
            item.PrintStudent();
        }
    }

   

}