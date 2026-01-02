using System.Net.Http.Json;

namespace Project_UI;
using API.Entities;
public partial class FormPanel : Form
{
    private byte category;
    private List<Producto> productos = new List<Producto>();
    public FormPanel(byte categoria)
    {
        this.category = categoria;
        InitializeComponent();
    }
    
    private List<Producto> LoadProductos(byte categoria)
    {
        var http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5131")
        };

        try
        {
            var response =  http.GetAsync($"/api/Producto/Category/{categoria}").Result;

            if (response.IsSuccessStatusCode)
            {
                var productos = response.Content.ReadFromJsonAsync<List<Producto>>();
                return productos.Result;
            }
            else
            {
                Console.WriteLine("Error al consultar productos");
                return null;
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
        
    }
    
    private void DisplayProductos()
    {
        string currentPath = Environment.CurrentDirectory;
        
        string projDir = Directory.GetParent(currentPath).Parent.Parent.FullName;
        
        productos = LoadProductos(category);

        try
        {
            if (productos is null | productos.Count == 0)
            {
                MessageBox.Show("Error al recuperar las productos");
            }
            else
            {
                foreach (var item in productos)
                {
                    if (item.Disponible == true)
                    {
                        var card = new Panel { Width = 200, Height = 180, BackColor = Color.LightBlue, Margin = new Padding(8), Tag= item.ProductoId };
                        PictureBox img;
                        try
                        {
                            img = new PictureBox { Width = 80, Height = 80, Image = Image.FromFile(projDir+"/Resources/"+item.ProductoId+".jpg"), Margin = new Padding(60, 10, 0 ,10), SizeMode = PictureBoxSizeMode.StretchImage};
                        }
                        catch (FileNotFoundException e)
                        {
                            img = new PictureBox{ Width = 80, Height = 80, Image = Image.FromFile(projDir+"/Resources/NotFound.png"), Margin = new Padding(60, 10, 0 ,10), SizeMode = PictureBoxSizeMode.StretchImage};
                            Console.WriteLine("Error al cargar la imagen del producto con ID: "+item.ProductoId );
                        }
                        var lblTitle = new Label {  Text = item.ProductoNombre, Font = new Font("Segoe UI",12,FontStyle.Bold), AutoSize = true, Tag = item.ProductoId };
                        var innerLayout = new FlowLayoutPanel
                        {
                            Dock = DockStyle.Fill,
                            FlowDirection = FlowDirection.TopDown,
                            AutoScroll = true,
                            Tag = item.ProductoId
                        };
                        innerLayout.Controls.Add(img);
                        innerLayout.Controls.Add(lblTitle);
                        card.Controls.Add(innerLayout);
                        pnlProductos.Controls.Add(card);

                        innerLayout.Click += Card_Click;
                        lblTitle.Click += Card_Click;
                        img.Click += Card_Click;
                    }
            
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            MessageBox.Show("Error al recuperar las productos, verifique y recargue la ventana");
        }
        
    }

    private void Card_Click(object? sender, EventArgs e)
    {
        var panel = sender as Control;
        while (panel != null && panel is not Panel)
        {
            panel = panel.Parent;
        }
        if (panel == null)
            return;

        using (var popup = new Pop_UpProducto())
        {
            if (popup.ShowDialog() == DialogResult.OK)
            {
                
                foreach (Control control in pnlProductos.Controls )
                {
                    if (control is Panel)
                    {
                        if (control.Tag.Equals(panel.Tag))
                        {
                            CajaUI.FillProductos(productos.Find(x => x.ProductoId == Convert.ToInt32(control.Tag.ToString())) ?? throw new InvalidOperationException(), popup.cantidad);
                            DataRefresh();
                            break;
                        } 
                    }
                   
                }
                
            }
        }
    }

    private void DataRefresh()
    {
       Eventos.Refresh();
    }
    
    private void FormPanel_Load(object sender, EventArgs e)
    {
        DisplayProductos();
    }
}