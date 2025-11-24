namespace Project_UI;

public partial class Pop_Up_Editar : Form
{
    private int _cantActual;
    public Pop_Up_Editar(int cantActual)
    {
        _cantActual = cantActual;
        InitializeComponent();
    }


    private void btnCompletar_Click(object sender, EventArgs e)
    {
        switch (numberSelect.Value)
        {
            case < 0:
                MessageBox.Show("Seleccione una cantidad valida");
                break;
            case 0:
                this.DialogResult = DialogResult.OK;
                this.Close();
                break;
            default:
                if (numberSelect.Value > 0 & numberSelect.Value != _cantActual)
                {
                    this.DialogResult = DialogResult.Abort;
                    CajaUI cj = new CajaUI();
                    cj.ProductUpdate((int)numberSelect.Value);
                    Close();
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                break;
                
                
        }
    }


    private void Pop_Up_Leave(object sender, EventArgs e)
    {
        this.Close();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void Pop_Up_Load(object sender, EventArgs e)
    {
        numberSelect.Minimum = 0;
        numberSelect.Maximum = _cantActual + 10;
        numberSelect.Increment = 1;
        numberSelect.Value = _cantActual;
    }


    private void button1_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }
}