﻿using System;
using System.Collections.Generic;

namespace bankprojdb.Models;

public partial class Jivanshu
{
    public int Eid { get; set; }

    public string? Ename { get; set; }

    public DateOnly? Doj { get; set; }
}
