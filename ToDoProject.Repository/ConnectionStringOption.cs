﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoProject.Repository;

public class ConnectionStringOption
{
    public const string Key = "ConnectionStrings";
    public string SqlServer { get; set; } = default!;
}
