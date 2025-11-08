using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Group
{
    public int Id { get; set; }

    public int? DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public int? Course { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<StudyPlan> StudyPlans { get; set; } = new List<StudyPlan>();
}
