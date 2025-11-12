using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Detalle_Orden
{
    public int? OrdenId { get; set; }

    public int? ProductoId { get; set; }

    public int? Cantidad { get; set; }

    public virtual Ordenes? Orden { get; set; }

    public virtual Producto? Producto { get; set; }
}
