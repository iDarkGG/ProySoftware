using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Producto
{
    public int ProductoId { get; set; }

    public decimal ProductoPrecio { get; set; }

    public string? ProductoNombre { get; set; }

    public string? ProductoImagen { get; set; }

    public string? Categoria { get; set; }

    public bool? Disponible { get; set; }
}
