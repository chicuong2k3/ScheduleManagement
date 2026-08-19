namespace ScheduleManagement.Api.Models;
// value type: allocated on stack int, decimal, double, float, bool, char
// reference type: class, object
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
}

