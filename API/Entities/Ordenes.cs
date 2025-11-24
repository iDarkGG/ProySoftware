using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Ordenes
{
    public int OrdenId { get; set; }

    public byte OrdenStatus { get; set; } 

    public DateTime? FechaOrden { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
    
    public virtual ICollection<Detalle_Orden> DetalleOrdenes { get; set; } = new List<Detalle_Orden>();

}
