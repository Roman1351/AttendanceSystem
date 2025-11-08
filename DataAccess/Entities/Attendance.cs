using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Attendance
{
    public int Id { get; set; }

    public int? ScheduleId { get; set; }

    public int? StudentId { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual Schedule? Schedule { get; set; }

    public virtual Student? Student { get; set; }
}
