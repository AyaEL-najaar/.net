using System;
using System.Collections.Generic;

namespace EFWD2.Models;

public partial class EmployeeProject
{
    public int Eid { get; set; }

    public int Pnum { get; set; }

    public int? WorkingHours { get; set; }

    public virtual Employee EidNavigation { get; set; } = null!;

    public virtual Project PnumNavigation { get; set; } = null!;
}
