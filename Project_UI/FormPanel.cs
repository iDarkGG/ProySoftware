namespace Project_UI;

public partial class FormPanel : Form
{
    public FormPanel()
    {
        InitializeComponent();
    }
    
    private void DisplayProductos()
    {
        string currentPath = Environment.CurrentDirectory;
        
        string projDir = Directory.GetParent(currentPath).Parent.Parent.FullName;
        
        var card = new Panel { Width = 200, Height = 320, BackColor = Color.LightBlue, Margin = new Padding(8), Tag= 1 };
        var img = new PictureBox { Width = 80, Height = 80, Image = Image.FromFile(projDir+"/Resources/cerveza.jpg"), Margin = new Padding(60, 10, 0 ,10), SizeMode = PictureBoxSizeMode.StretchImage};
        var lblTitle = new Label {  Text = "Orden 1", Font = new Font("Segoe UI",12,FontStyle.Bold), AutoSize = true};
        var lblContent = new Label {  Text = "This is a Test \nTest \nTest \nTest \nTest \nTest ", Font = new Font("Segoe UI",
            12,FontStyle.Bold), AutoSize = true, Padding = new Padding(5,10,0,5)};
        var innerLayout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            AutoScroll = true,
            Tag = 1
        };
        innerLayout.Controls.Add(img);
        innerLayout.Controls.Add(lblTitle);
        innerLayout.Controls.Add(lblContent);
        card.Controls.Add(innerLayout);
        pnlProductos.Controls.Add(card);

        innerLayout.Click += Card_Click;
        lblTitle.Click += Card_Click;
        lblContent.Click += Card_Click;
        img.Click += Card_Click;
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
                            pnlProductos.Controls.Remove(control);
                            pnlProductos.Refresh();
                            break;
                        } 
                    }
                   
                }
            }
        }
    }

    private void FormPanel_Load(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;
        
        for (int i = 0; i < 4; i++)
        {
            DisplayProductos();
        }
    }
}