using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Dean { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
