using System.Net.Http.Json;
using Microsoft.AspNetCore.SignalR.Client;

namespace Project_UI;
using API.Entities;

public partial class CajaUI : Form
{
    HubConnection conn;
    
    public CajaUI()
    {
      InitializeComponent();
      Eventos.RefreshRequested += OnRefreshRequested;
    }
    
    
    
    private async void SignalR()
    {
        conn = new HubConnectionBuilder().WithUrl("https://localhost:5131/ordersHub").Build();
        try
        {

            await conn.StartAsync();
            await conn.SendAsync("JoinGroup", "Cocina");

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private static List<ProductoFormGET> Productos = new List<ProductoFormGET>();
    
    private enum StatusCode
    {
        CANCELADO = 0,
        EN_PROCESO = 1,
        TERMINADA = 2
    }

   
    private async Task<Ordenes?> PostOrden(OrdenPOST orden)
    {
        var http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5131")
        };

        try
        {
            var response =  http.PostAsJsonAsync("/api/Ordenes/NuevaOrden", orden).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadFromJsonAsync<Ordenes>();
                
                return content;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {error}");
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
        
    }

    private async Task<bool> AgregarDetalles(int ordenId, List<Detalle_OrdenGET> detalles)
    {
        var http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5131"),
            Timeout = TimeSpan.FromSeconds(5)
        };

        try
        {
            var response = await http.PostAsJsonAsync($"/api/Ordenes/AddOrdenDetalles/{ordenId}", detalles);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Detalles Agregados");
                return true;
            }
            else
            {
                Console.WriteLine("Error");
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    public static void FillProductos(Producto productos, int cantidad)
    {
        var filler = new ProductoFormGET
        {
            ProductoId = productos.ProductoId,
            Nombre = productos.ProductoNombre,
            Precio = productos.ProductoPrecio,
            Cantidad = cantidad
        };
        var existe = Productos.FirstOrDefault(x => x.ProductoId == productos.ProductoId);
        if (existe != null)
        {
            existe.Cantidad += cantidad;
        }
        else
        {
            Productos.Add(filler);
        }
 
    }


    private void OnRefreshRequested()
    {
        decimal subtotal = 0, tax = 0, total = 0;
        lstPedidos.DataSource = null;
        lstPedidos.DataSource = Productos;
        lstPedidos.Columns["ProductoId"].Visible = false;
        foreach (var prod in Productos)
        {
            subtotal += (prod.Cantidad * prod.Precio);
        }
        lblSubTotal.Text = "SubTotal: " + subtotal.ToString("C");
        tax = subtotal * (decimal)0.15;
        lblTax.Text = "Impuesto: " + tax.ToString("C");
        total = subtotal + tax;
        lblTotal.Text = "Total: " + total.ToString("C");
    }
    
    
    private void FormAsPanel(Form form)
    {
        if(this.pnlContenido.Controls.Count >0)
            this.pnlContenido.Controls.Clear();
        form.TopLevel = false;
        form.Dock = DockStyle.Fill;
        this.pnlContenido.Controls.Add(form);
        this.pnlContenido.Tag = form;
        form.Show();
    }

    private void btnBebidas_Click(object sender, EventArgs e)
    {
        FormAsPanel(new FormPanel(1));
    }

    private void CajaUI_Load(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;
    }

    private async void btnConfirmar_Click(object sender, EventArgs e)
    {
        if (Productos.Count < 1)
        {
            MessageBox.Show("No se puede crear una orden vacia!");
        }
        else
        {
            var orden = new OrdenPOST
            {
                OrdenStatus = (int)StatusCode.EN_PROCESO,
                FechaOrden = DateTime.Now
            };

            var result = PostOrden(orden);

            if (result != null & result.Result.OrdenId != null)
            {
                List<Detalle_OrdenGET> detalles = new List<Detalle_OrdenGET>();
                foreach (var item in Productos)
                {
                    var det = new Detalle_OrdenGET
                    {
                        OrdenId = result.Result.OrdenId,
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad
                    };
                    detalles.Add(det);
                }
        
                bool success = await AgregarDetalles(result.Result.OrdenId, detalles);
                if (success == true)
                {
                    lblSubTotal.Text = "SubTotal:";
                    lblTax.Text = "Impuesto:";
                    lblTotal.Text = "Total:";
                    Productos.Clear();
                    OnRefreshRequested();
                    Console.WriteLine("Detalles Agregados");

                    if (conn.State == HubConnectionState.Connected)
                    {
                        await conn.SendAsync("UpdateOrders");
                    }
                   
                }
                else
                {
                    Console.WriteLine("Error al agregar Detalles");
                }
            }
            else
            {
                Console.WriteLine("Error al agregar Orden");
            }
        }
       

        
    }

    private void btnComidaRapida_Click(object sender, EventArgs e)
    {
        FormAsPanel(new FormPanel(2));
    }
}