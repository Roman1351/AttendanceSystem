using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Teacher
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public string FullName { get; set; } = null!;

    public string? AcademicDegree { get; set; }

    public DateOnly? EmploymentDate { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
