using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? SubjectId { get; set; }

    public int? Grade1 { get; set; }

    public DateOnly? ExamDate { get; set; }

    public int? TeacherId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
