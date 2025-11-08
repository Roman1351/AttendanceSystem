using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Schedule
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int? SubjectId { get; set; }

    public int? TeacherId { get; set; }

    public DateOnly LessonDate { get; set; }

    public TimeOnly LessonTime { get; set; }

    public string? Classroom { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual Group? Group { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
