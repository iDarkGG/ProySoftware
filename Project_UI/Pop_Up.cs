namespace Project_UI;

public partial class Pop_Up : Form
{
    public Pop_Up()
    {
        InitializeComponent();
    }


    private void btnCompletar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }


    private void Pop_Up_Leave(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Abort;
        this.Close();
    }

    private void Pop_Up_Load(object sender, EventArgs e)
    {
        
    }

}