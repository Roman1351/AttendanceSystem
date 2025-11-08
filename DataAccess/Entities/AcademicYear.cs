using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class AcademicYear
{
    public int Id { get; set; }

    public string YearName { get; set; } = null!;

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}
