using System;
using System.Collections.Generic;

namespace EFWD2.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? SupervisorId { get; set; }

    public int? DepartmentNumber { get; set; }

    public decimal? Salary { get; set; }

    public virtual Department? DepartmentNumberNavigation { get; set; }

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<Employee> InverseSupervisor { get; set; } = new List<Employee>();

    public virtual Employee? Supervisor { get; set; }
}
