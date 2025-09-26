using System;
using System.Collections.Generic;

namespace EFWD2.Models;

public partial class Project
{
    public int Pnumber { get; set; }

    public string? Pname { get; set; }

    public string? Location { get; set; }

    public string? City { get; set; }

    public int? DeptNum { get; set; }

    public virtual Department? DeptNumNavigation { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}
