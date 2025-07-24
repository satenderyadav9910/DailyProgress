using System;
using System.Collections.Generic;

namespace DailyProgress.SchoolApi.Models;

public partial class Student
{
    public short Id { get; set; }

    public string Name { get; set; } = null!;

    public short Age { get; set; }

    public string Email { get; set; } = null!;
}
