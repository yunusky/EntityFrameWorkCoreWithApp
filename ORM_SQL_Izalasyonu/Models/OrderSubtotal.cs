using System;
using System.Collections.Generic;

namespace ORM_SQL_Izalasyonu.Models;

public partial class OrderSubtotal
{
    public int OrderId { get; set; }

    public decimal? Subtotal { get; set; }
}
