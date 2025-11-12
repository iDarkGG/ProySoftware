using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Factura
{
    public int FacturaId { get; set; }

    public int? OrdenId { get; set; }

    public decimal? MontoTotal { get; set; }

    public DateTime? FechaFactura { get; set; }

    public virtual Ordenes? Orden { get; set; }
}
