namespace API.Entities;

public partial class ProductoPost
{

    public decimal ProductoPrecio { get; set; }

    public string? ProductoNombre { get; set; }

    public string? ProductoImagen { get; set; }

    public byte? Categoria { get; set; }

    public bool? Disponible { get; set; }
}