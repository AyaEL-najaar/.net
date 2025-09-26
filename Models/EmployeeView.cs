using System;
using System.Collections.Generic;

namespace EFWD2.Models;

public partial class EmployeeView
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public decimal? Salary { get; set; }
}
