﻿using System;
using System.Collections.Generic;

namespace ECOM_MVC.Models;

public partial class Purchase
{
    public int PurchaseId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
