using Bogus;
using Sys_Lesson8.Models;

namespace Sys_Lesson8.Helpers;

public static class StudentHelper
{
    private static readonly Faker<Student> _faker;

    static StudentHelper()
    {
        _faker = new Faker<Student>()
            .RuleFor(s => s.Id, f => f.IndexGlobal)
            .RuleFor(s => s.FirstName, f => f.Person.FirstName)
            .RuleFor(s => s.LastName, f => f.Person.LastName)
            .RuleFor(s => s.Score, f => f.Random.Float(1, 12))
            .RuleFor(s => s.Group, f => f.Company.CompanyName())
            .RuleFor(s => s.BirthDate, f => f.Date.Between(new DateTime(1960, 1, 1), new DateTime(2025, 1, 1)))
            .RuleFor(s => s.Email, f => f.Internet.Email());
    }


    public static List<Student> GenerateStudent(int studentCount)
     => _faker.Generate(studentCount);

}
