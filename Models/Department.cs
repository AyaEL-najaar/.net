using System;
using System.Collections.Generic;

namespace EFWD2.Models;

public partial class Department
{
    public int Dnumber { get; set; }

    public string? Dname { get; set; }

    public int? ManagerId { get; set; }

    public DateOnly? HiringDate { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
