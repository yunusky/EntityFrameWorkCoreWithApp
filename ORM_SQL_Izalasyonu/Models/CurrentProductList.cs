﻿using System;
using System.Collections.Generic;

namespace ORM_SQL_Izalasyonu.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}
