using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Student
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public string StudentCard { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Group? Group { get; set; }
}
