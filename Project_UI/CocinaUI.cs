using System.Net.Http.Json;
using API.Entities;
using Microsoft.AspNetCore.SignalR.Client;

namespace Project_UI;

public partial class CocinaUI : Form
{
    private List<Ordenes> ordenes;
    private List<Producto> productos;
    public CocinaUI()
    {
        InitializeComponent();
        SignalR();
    }

    private async void SignalR()
    {
        var conn = new HubConnectionBuilder().WithUrl("https://localhost:5131/ordersHub").Build();
        try
        {
            conn.On("UpdateOrders", () => { this.Invoke(() => { DisplayOrder(); }); });

            await conn.StartAsync();
            await conn.SendAsync("JoinGroup", "Cocina");

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private enum StatusCode
    {
        CANCELADO = 0,
        EN_PROCESO = 1,
        TERMINADA = 2
    }
    private List<Producto> LoadProductos()
    {
        var http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5131")
        };

        try
        {
            var response =  http.GetAsync($"/api/Producto").Result;

            if (response.IsSuccessStatusCode)
            {
                var productos = response.Content.ReadFromJsonAsync<List<Producto>>();
                return productos.Result;
            }
            else
            {
                MessageBox.Show("Error al recuperar las productos");
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        

    }

    private async Task<bool> UpdateOrdenStatus(Ordenes orden, int id)
    {
        var http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5131")
        };
        var fill = new OrdenPOST
        {
            FechaOrden = orden.FechaOrden,
            OrdenStatus = orden.OrdenStatus
        };
        
        try
        {
            var response = http.PutAsJsonAsync($"/api/Ordenes/UpdateOrder/{id}", fill).Result;

            if (response.IsSuccessStatusCode)
            {
                var order = await response.Content.ReadFromJsonAsync<Ordenes>();
                Console.WriteLine($"Actualizado {orden.OrdenId}");
                return true;
            }
            else
            {
                Console.WriteLine("Error al Actualizar la orden");
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }

    private List<Ordenes> GetOrdenes(int status)
    {
        var http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5131")
        };

        try
        {
            var response = http.GetAsync($"/api/Ordenes/GetByStatus/{status}").Result;

            if (response.IsSuccessStatusCode)
            {
                var ordenes = response.Content.ReadFromJsonAsync<List<Ordenes>>().Result;
                return ordenes;
            }
            else
            {
                MessageBox.Show("Error al recuperar las ordenes");
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
        
    }

    private List<Detalle_OrdenGET> GetDetalles(int OrdenID)
    {
        var http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5131")
        };
        
        var response = http.GetAsync($"/api/Ordenes/GetDetalles/{OrdenID}").Result;

        if (response.IsSuccessStatusCode)
        {
            var ordenes = response.Content.ReadFromJsonAsync<List<Detalle_OrdenGET>>().Result;
            return ordenes;
        }
        else
        {
            MessageBox.Show("Error al recuperar los detalles de ordenes GET");
            return null;
        }
    }
  
    
    private void DisplayOrder()
    {
        OrderPanel.Controls.Clear();
        
        ordenes = GetOrdenes((int)StatusCode.EN_PROCESO);
        productos = LoadProductos();

        try
        {
            if (ordenes.Count == 0 | ordenes is null)
            {
                MessageBox.Show("Error al recuperar las ordenes");
            }
            else
            {
                foreach (var orden in ordenes)
                {
                    if (orden.OrdenStatus == (int)StatusCode.EN_PROCESO)
                    {
                        var Detalles = GetDetalles(orden.OrdenId);
                        var card = new Panel { Width = 250, Height = 320, BackColor = Color.LightBlue, Margin = new Padding(8), Tag= orden.OrdenId };
                        var lblTitle = new Label {  Text = "Orden "+ orden.OrdenId, Font = new Font("Segoe UI",12,FontStyle.Bold), AutoSize = true};
                        var lblContent = new Label {  Text = string.Join("\n", Detalles.Select(d =>
                        {
                            var producto = productos.FirstOrDefault(p => p.ProductoId == d.ProductoId);
                            if (producto != null)
                            {
                                return $"{producto.ProductoNombre}   x  {d.Cantidad}";
                            }
                            else
                            {
                                return "No Encontrado";
                            }
                        })), Font = new Font("Segoe UI",
                            12,FontStyle.Bold), AutoSize = true, Padding = new Padding(5,5,0,5)};
                    
                        var innerLayout = new FlowLayoutPanel
                        {
                            Dock = DockStyle.Fill,
                            FlowDirection = FlowDirection.TopDown,
                            AutoScroll = true,
                            Tag = orden.OrdenId
                        };
        
                        innerLayout.Controls.Add(lblTitle);
                        innerLayout.Controls.Add(lblContent);
                        card.Controls.Add(innerLayout);
                        OrderPanel.Controls.Add(card);

                        innerLayout.Click += Card_Click;
                        lblTitle.Click += Card_Click;
                        lblContent.Click += Card_Click;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("No hay nada que cargar");
            MessageBox.Show("no hay nada que cargar, por favor verifique, y recargue la ventana");
        }
        
       
    }

    private async void Card_Click(object? sender, EventArgs e)
    {
        var panel = sender as Control;
        while (panel != null && panel is not Panel)
        {
            panel = panel.Parent;
        }
        if (panel == null)
            return;

        using (var popup = new Pop_Up())
        {
            var result = popup.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (Control control in OrderPanel.Controls )
                {
                    if (control is Panel)
                    {
                        if (control.Tag.Equals(panel.Tag))
                        {
                            var newOrden = new Ordenes
                            {
                                FechaOrden = DateTime.Now,
                                OrdenStatus = (int)StatusCode.TERMINADA
                            };
                             bool success = await UpdateOrdenStatus(newOrden,  Convert.ToInt32(control.Tag));
                             if (success)
                             {
                                 OrderPanel.Controls.Remove(control);
                                 OrderPanel.Refresh();
                             }
                            break;
                        } 
                    }
                   
                }
            }
            else if(result == DialogResult.Abort)
            {
                foreach (Control control in OrderPanel.Controls )
                {
                    if (control is Panel)
                    {
                        if (control.Tag.Equals(panel.Tag))
                        {
                            var newOrden = new Ordenes
                            {
                                FechaOrden = DateTime.Now,
                                OrdenStatus = (int)StatusCode.CANCELADO
                            };
                            bool success = await UpdateOrdenStatus(newOrden,  Convert.ToInt32(control.Tag));
                            if (success)
                            {
                                OrderPanel.Controls.Remove(control);
                                OrderPanel.Refresh();
                            }
                            break;
                        } 
                    }
                   
                }
            }
            else
            {
                popup.Close();
            }
        }
    }

    private void CocinaUI_Load(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;



        DisplayOrder();

    }


}