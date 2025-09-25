using Sys_Lesson8.Extentions;
using Sys_Lesson8.Helpers;
using Sys_Lesson8.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sys_Lesson8;



class Program
{
    static async Task Main(string[] args)
    {
        //////////////////////////////////////////////////////////////////////

        // // Test 

        // Console.Write("Enter Student Count: ");
        // var countStr = Console.ReadLine();
        // int countStudent = Convert.ToInt32(countStr);
        // 
        // var students = StudentHelper.GenerateStudent(countStudent);
        // 
        // foreach (var item in students)
        //     item.PrintStudent();

        //////////////////////////////////////////////////////////////////////

        var students = StudentHelper.GenerateStudent(1000);

        //// 155544918 -> Sinxron
        //// 77878250  -> Assinxron
        ////
        ////

        //////////////////////////////////////////////////////////////////////

        // // // Sinxron olaraq Student-in group name-in deyisirem
        // 
        // Stopwatch stopwatch = new Stopwatch();
        // 
        // stopwatch.Start();
        // 
        // foreach (var student in students)
        // {
        //     student.Group = "FSDE_Oct_24_6_az";
        //     Thread.Sleep(10);
        // }
        // 
        // stopwatch.Stop();
        // 
        // Console.WriteLine($"Geden zaman: {stopwatch.ElapsedTicks}");

        //////////////////////////////////////////////////////////////////////



        //////////////////////////////////////////////////////////////////////


        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();


        var t1 = Task.Run(() =>
        {
            for (var i = 0; i < students.Count / 2; i++)
            {
                students[i].Group = "FSDE_Oct_24_6_az";
                Thread.Sleep(10);
            }
        });

        var t2 = Task.Run(() =>
        {
            for (var i = students.Count / 2; i < students.Count; i++)
            {
                students[i].Group = "FSDE_Oct_24_6_az";
                Thread.Sleep(10);
            }
        });

        await Task.WhenAll(t1, t2);

        stopwatch.Stop();
        Console.WriteLine($"Geden zaman: {stopwatch.ElapsedTicks}");


        //////////////////////////////////////////////////////////////////////



    }
}