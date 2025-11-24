namespace Project_UI;

public partial class Pop_UpProducto : Form
{
    public Pop_UpProducto()
    {
        InitializeComponent();
    }

    public int cantidad { get; set; }
    
    private void btnCompletar_Click(object sender, EventArgs e)
    {
        if (numSelector.Value < 1)
        {
            MessageBox.Show("Cantidad invalida");
            this.DialogResult = DialogResult.TryAgain;
            return;
        }

        cantidad = (int)numSelector.Value;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }


    private void Pop_Up_Leave(object sender, EventArgs e)
    {
        this.Close();
    }


    private void btnCancelar_Click(object sender, EventArgs e)
    {
       this.Close();
    }
}