using API.Context;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.EndPoints;

public static class OrdenesEndPoints
{
    public static WebApplication UseOrdenesEndPoints(this WebApplication app)
    {
        app.MapGet("/api/Ordenes", async (MyDbContext db) => await db.Ordenes.ToListAsync());
        
        app.MapGet("/api/Ordenes/{id:int}", async (MyDbContext db, int id) =>
        {
            var orden =  await db.Ordenes.FindAsync(id);
            
            return orden is not null ? Results.Ok(orden) : Results.NotFound();
        });

        app.MapGet("/api/Ordenes/GetByStatus/{status:int}", async (MyDbContext db, int status) =>
        {
            var orden = await db.Ordenes.Where(x => x.OrdenStatus == status).ToListAsync();
            
            return orden.Count != 0 ? Results.Ok(orden) : Results.NotFound();
        });

        app.MapGet("/api/Ordenes/GetDetalles/{id:int}", async (MyDbContext db, int id) =>
        {
            var orden = await db.Detalle_Orden.Where(x => x.OrdenId == id).Select(x => new Detalle_OrdenGET
            {
                OrdenId = x.OrdenId,
                ProductoId = x.ProductoId,
                Cantidad = x.Cantidad,
            }).ToListAsync();

            return orden.Count != 0 ? Results.Ok(orden) : Results.NotFound();
        });


        app.MapPost("/api/Ordenes/NuevaOrden", async (MyDbContext db, OrdenPOST orden) =>
        {
            if(orden is null) return Results.BadRequest();

            var fill = new Ordenes
            {
                OrdenStatus = orden.OrdenStatus,
                FechaOrden = orden.FechaOrden
            };
            
            db.Ordenes.Add(fill);
            await db.SaveChangesAsync();
            
            return Results.Ok(fill);
        });

        app.MapPost("/api/Ordenes/AddOrdenDetalles/{id:int}",
            async (MyDbContext db, int id, List<Detalle_OrdenGET> detalle) =>
            {
                var orden = await db.Ordenes.Where(x => x.OrdenId == id).FirstOrDefaultAsync();
                if (orden is null) return Results.BadRequest("La orden no existe");

                foreach (Detalle_OrdenGET det in detalle)
                {
                    var cont = new Detalle_Orden()
                    {
                        OrdenId = id,
                        ProductoId = det.ProductoId,
                        Cantidad = det.Cantidad
                    };
                    db.Detalle_Orden.Add(cont);
                }
                await db.SaveChangesAsync();

                return Results.Ok($"/api/Ordenes/{id}");

            });

        app.MapPut("/api/Ordenes/UpdateOrder/{id:int}", async (MyDbContext DbContext, OrdenPOST update, int id) =>
        {
            var orden = await DbContext.Ordenes.FirstOrDefaultAsync(o => o.OrdenId == id);

            if (orden is null) return Results.NotFound();
            
            if(update is null) return Results.BadRequest();
            
            orden.FechaOrden = update.FechaOrden;
            orden.OrdenStatus = update.OrdenStatus;

            await DbContext.SaveChangesAsync();
            
            return Results.Ok(orden);
        });
        return app;
    }
}