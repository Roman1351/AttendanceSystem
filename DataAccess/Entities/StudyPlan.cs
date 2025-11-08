using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class StudyPlan
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int? SubjectId { get; set; }

    public int? Semester { get; set; }

    public int? HoursPerSemester { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Subject? Subject { get; set; }
}
