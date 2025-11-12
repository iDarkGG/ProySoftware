using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Ordenes
{
    public int OrdenId { get; set; }

    public string OrdenStatus { get; set; } = null!;

    public DateTime? FechaOrden { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
