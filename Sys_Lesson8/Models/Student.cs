namespace Sys_Lesson8.Models;



public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public float Score { get; set; }
    public string Group { get; set; }
    public DateTime BirthDate { get; set; }
    public string Email { get; set; }


    public List<Student> FilterStudent(FilterStudentDto filter, List<Student> students)
    {
        var studentQuerable = students.AsQueryable();

        if (filter.FirstName != null)
            studentQuerable.Where(x => x.FirstName == filter.FirstName); // DB muraciet

        if (filter.LastName != null)
            studentQuerable.Where(x => x.LastName == filter.LastName);// DB muraciet

        if (filter.Group != null)
            studentQuerable.Where(x => x.Group == filter.Group);// DB muraciet

        if (filter.Email != null)
            studentQuerable.Where(x => x.Email == filter.Email);// DB muraciet


        return studentQuerable.ToList();
    }
}

public class FilterStudentDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Group { get; set; }
    public string? Email { get; set; }
}
