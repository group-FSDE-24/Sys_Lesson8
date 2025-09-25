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

        // var students = StudentHelper.GenerateStudent(500);

        //// 155544918 -> Sinxron
        //// 77878250  -> Assinxron
        //// 12431404  -> Parallel ( Task oz isteyi qeder )
        //// 31294678  -> Parallel ( Custom men verdiyim say 5 )

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

        // // Assinxron Task ile islemek

        // Stopwatch stopwatch = new Stopwatch();
        // stopwatch.Start();
        // 
        // 
        // var t1 = Task.Run(() =>
        // {
        //     for (var i = 0; i < students.Count / 2; i++)
        //     {
        //         students[i].Group = "FSDE_Oct_24_6_az";
        //         Thread.Sleep(10);
        //     }
        // });
        // 
        // var t2 = Task.Run(() =>
        // {
        //     for (var i = students.Count / 2; i < students.Count; i++)
        //     {
        //         students[i].Group = "FSDE_Oct_24_6_az";
        //         Thread.Sleep(10);
        //     }
        // });
        // 
        // await Task.WhenAll(t1, t2);
        // 
        // stopwatch.Stop();
        // Console.WriteLine($"Geden zaman: {stopwatch.ElapsedTicks}");


        //////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////
        // // Parallel 

        // Stopwatch stopwatch = new Stopwatch();
        // stopwatch.Start();
        // 
        // Parallel.ForEach(students, student =>
        // {
        //     student.Group = "FSDE_Oct_24_6_az";
        //     Thread.Sleep(10);
        // });
        // 
        // stopwatch.Stop();
        // Console.WriteLine($"Geden zaman: {stopwatch.ElapsedTicks}");

        //////////////////////////////////////////////////////////////////////


        //////////////////////////////////////////////////////////////////////

        // // Parallel with Option

        // Stopwatch stopwatch = new Stopwatch();
        // stopwatch.Start();
        // 
        // var option = new ParallelOptions()
        // {
        //     MaxDegreeOfParallelism = 2,
        //     // CancellationToken = new CancellationToken(),
        //     // TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext()
        // };
        // 
        // Parallel.ForEach(students, option, student =>
        // {
        //     student.Group = "FSDE_Oct_24_6_az";
        //     Thread.Sleep(10);
        // });
        // 
        // stopwatch.Stop();
        // Console.WriteLine($"Geden zaman: {stopwatch.ElapsedTicks}");

        //////////////////////////////////////////////////////////////////////



        //////////////////////////////////////////////////////////////////////

        // // Parallel With For

        // Parallel.For(0, students.Count, i =>
        // {
        //     students[i].Group = "FSDE_Oct_24_6_az";
        //     Thread.Sleep(10);
        // });

        //////////////////////////////////////////////////////////////////////

        // // Cpu Bound -> Hesablama tipli emeliyyatlar yerine yetirilir
        // // IO Bound  -> Applicationdan cixis ve giris edilen zaman istifade edilir
        // //              Yeni app -> DB | app <- DB | app -> file | app <- file | app <-> Http                          

        //////////////////////////////////////////////////////////////////////

        //////////////////////////////////////////////////////////////////////

        var students = StudentHelper.GenerateStudent(60000);


        // // Linq | Parallel | PLINQ


        // Stopwatch stopwatch = new Stopwatch();
        //
        // stopwatch.Start();
        //
        // var linqCount = students.Count(s => (s.FirstName.Length + s.LastName.Length) > 15 && s.Email.ToLower().EndsWith("@gmail.com"));
        // Console.WriteLine($"Linq -> Count: {linqCount} - Ticks: {stopwatch.ElapsedTicks}");
        //
        // stopwatch.Restart();
        //
        // int parallelCount = 0; // shared memory
        // var _lock = new object();
        //
        // Parallel.ForEach(students, s =>
        // {
        //     // | |
        //     if ((s.FirstName.Length + s.LastName.Length) > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
        //     {
        //         lock (_lock)
        //         {
        //             parallelCount++; // critical section
        //         }
        //     }
        // });
        //
        // Console.WriteLine($"Parallel -> Count: {parallelCount} - Ticks: {stopwatch.ElapsedTicks}");
        //
        //
        // stopwatch.Stop();
        //
        // var plinqCount = students.AsParallel().Count(s => (s.FirstName.Length + s.LastName.Length) > 15 && s.Email.ToLower().EndsWith("@gmail.com"));
        // Console.WriteLine($"PLinq -> Count: {plinqCount} - Ticks: {stopwatch.ElapsedTicks}");


        //////////////////////////////////////////////////////////////////////

        // // LINQ vs Parallel vs PLINQ - Select

        //  Stopwatch sw = Stopwatch.StartNew();
        //  
        //  var namesPLinq = students
        //      .AsParallel()
        //      .Where(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
        //      .Select(s => $"{s.FirstName} {s.LastName}")
        //      .ToList();
        //  
        //  Console.WriteLine($"PLINQ count: {namesPLinq.Count}  -  Ticks: {sw.ElapsedTicks}");
        //  sw.Restart();
        //  
        //  
        //  var namesLinq = students
        //      .Where(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
        //      .Select(s => $"{s.FirstName} {s.LastName}")
        //      .ToList();
        //  
        //  
        //  Console.WriteLine($"LINQ count: {namesLinq.Count}  -  Ticks: {sw.ElapsedTicks}");
        //  sw.Restart();
        //  
        //  
        //  var namesParallel = new List<string>();
        //  var _lock = new object();
        //  
        //  Parallel.ForEach(students, s =>
        //  {
        //      if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
        //      {
        //          lock (_lock)
        //          {
        //              namesParallel.Add($"{s.FirstName} {s.LastName}");
        //          }
        //      }
        //  });
        //  
        //  
        //  Console.WriteLine($"Parallel count: {namesParallel.Count}  -  Ticks: {sw.ElapsedTicks}");

        /////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////

        //  var sw = Stopwatch.StartNew();
        // 
        // 
        //  "abc".AsParallel().Count();
        //  Console.WriteLine(sw.ElapsedTicks);
        // 
        //  sw.Restart();
        // 
        //  "abc".Count();
        //  Console.WriteLine(sw.ElapsedTicks);

        /////////////////////////////////////////////////////////////


        // Thread-Safe collections



    }
}