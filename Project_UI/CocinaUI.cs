namespace Project_UI;

public partial class CocinaUI : Form
{
    public CocinaUI()
    {
        InitializeComponent();
    }

    private void DisplayOrder()
    {
        var card = new Panel { Width = 200, Height = 320, BackColor = Color.LightBlue, Margin = new Padding(8), Tag= 1 };
        var lblTitle = new Label {  Text = "Orden 1", Font = new Font("Segoe UI",12,FontStyle.Bold), AutoSize = true};
        var lblContent = new Label {  Text = "This is a Test \nTest \nTest \nTest \nTest \nTest ", Font = new Font("Segoe UI",
            12,FontStyle.Bold), AutoSize = true, Padding = new Padding(5,0,0,5) };
        var innerLayout = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            AutoScroll = true
        };
        
        innerLayout.Controls.Add(lblTitle);
        innerLayout.Controls.Add(lblContent);
        card.Controls.Add(innerLayout);
        OrderPanel.Controls.Add(card);

        card.Click += Card_Click;
        lblTitle.Click += Card_Click;
        lblContent.Click += Card_Click;
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

        using (var popup = new Pop_Up())
        {
            if (popup.ShowDialog() == DialogResult.OK)
            {
                foreach (Control control in OrderPanel.Controls )
                {
                    if (control.Tag == panel.Tag)
                    {
                        OrderPanel.Controls.Remove(control);
                        OrderPanel.Refresh();
                        break;
                    }
                }
            }
        }
    }


    private void Form1_Load(object sender, EventArgs e)
    {
        this.WindowState = FormWindowState.Maximized;
        
        for (int i = 0; i < 4; i++)
        {
            DisplayOrder();
        }
    }
}