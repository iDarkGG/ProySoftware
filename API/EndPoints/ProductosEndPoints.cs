using API.Context;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.EndPoints;

public static class ProductosEndPoints
{
    public static WebApplication UseProductosEndPoints(this WebApplication app)
    {
        app.MapGet("/api/Producto", async (MyDbContext db) => await db.Productos.ToListAsync());
        
        
        app.MapGet("/api/Producto/{id:int}", async (MyDbContext db, int id) =>
        {
            var producto = await db.Productos.FindAsync(id);
            return producto is not null ? Results.Ok(producto) : Results.NotFound();
        });

        app.MapPost("/api/Producto", async (MyDbContext db, ProductoPost productoPost) =>
        {
            if(productoPost is null) return Results.BadRequest();

            var producto = new Producto
            {
                ProductoPrecio = productoPost.ProductoPrecio,
                ProductoNombre = productoPost.ProductoNombre,
                ProductoImagen = productoPost.ProductoImagen,
                Categoria = productoPost.Categoria,
                Disponible = productoPost.Disponible
            };
            
            db.Productos.Add(producto);
            await db.SaveChangesAsync();
            
            return Results.Created($"/api/Producto/{producto.ProductoId}", producto);
            
        });
        
        app.MapGet("/api/Producto/Status/{status:bool}", async (MyDbContext db, bool status) =>
        {
            var producto = await db.Productos.Where(x => x.Disponible  == status ).ToListAsync();
            return producto.Count != 0 ? Results.Ok(producto) : Results.NotFound();
        });
        
        app.MapGet("/api/Producto/Category/{category:int}", async (MyDbContext db, byte category) =>
        {
            var producto = await db.Productos.Where(x => x.Categoria  == category ).ToListAsync();
            return producto.Count != 0 ? Results.Ok(producto) : Results.NotFound();
        });
        
        return app;
    }
}