using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Department
{
    public int Id { get; set; }

    public int? FacultyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Head { get; set; }

    public virtual Faculty? Faculty { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
