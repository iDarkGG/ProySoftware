using System.ComponentModel;

namespace Project_UI;

partial class CajaUI
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pnlMenu = new System.Windows.Forms.Panel();
        btnComidaRapida = new System.Windows.Forms.Button();
        btnBebidas = new System.Windows.Forms.Button();
        pnlOrder = new System.Windows.Forms.Panel();
        lblPedidoActual = new System.Windows.Forms.Label();
        lblSubTotal = new System.Windows.Forms.Label();
        lblTax = new System.Windows.Forms.Label();
        lblTotal = new System.Windows.Forms.Label();
        lstPedidos = new System.Windows.Forms.DataGridView();
        btnConfirmar = new System.Windows.Forms.Button();
        pnlContenido = new System.Windows.Forms.Panel();
        pnlMenu.SuspendLayout();
        pnlOrder.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)lstPedidos).BeginInit();
        SuspendLayout();
        // 
        // pnlMenu
        // 
        pnlMenu.BackColor = System.Drawing.SystemColors.ActiveBorder;
        pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pnlMenu.Controls.Add(btnComidaRapida);
        pnlMenu.Controls.Add(btnBebidas);
        pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
        pnlMenu.Location = new System.Drawing.Point(0, 0);
        pnlMenu.Name = "pnlMenu";
        pnlMenu.Size = new System.Drawing.Size(171, 789);
        pnlMenu.TabIndex = 0;
        // 
        // btnComidaRapida
        // 
        btnComidaRapida.BackColor = System.Drawing.SystemColors.Control;
        btnComidaRapida.FlatAppearance.BorderSize = 0;
        btnComidaRapida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnComidaRapida.Location = new System.Drawing.Point(-1, 273);
        btnComidaRapida.Name = "btnComidaRapida";
        btnComidaRapida.Size = new System.Drawing.Size(171, 45);
        btnComidaRapida.TabIndex = 2;
        btnComidaRapida.Text = "COMIDA RAPIDA";
        btnComidaRapida.UseVisualStyleBackColor = false;
        btnComidaRapida.Click += btnComidaRapida_Click;
        // 
        // btnBebidas
        // 
        btnBebidas.BackColor = System.Drawing.SystemColors.Control;
        btnBebidas.FlatAppearance.BorderSize = 0;
        btnBebidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnBebidas.Location = new System.Drawing.Point(0, 222);
        btnBebidas.Name = "btnBebidas";
        btnBebidas.Size = new System.Drawing.Size(170, 45);
        btnBebidas.TabIndex = 1;
        btnBebidas.Text = "BEBIDAS";
        btnBebidas.UseVisualStyleBackColor = false;
        btnBebidas.Click += btnBebidas_Click;
        // 
        // pnlOrder
        // 
        pnlOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
        pnlOrder.Controls.Add(lblPedidoActual);
        pnlOrder.Controls.Add(lblSubTotal);
        pnlOrder.Controls.Add(lblTax);
        pnlOrder.Controls.Add(lblTotal);
        pnlOrder.Controls.Add(lstPedidos);
        pnlOrder.Controls.Add(btnConfirmar);
        pnlOrder.Dock = System.Windows.Forms.DockStyle.Right;
        pnlOrder.Location = new System.Drawing.Point(861, 0);
        pnlOrder.Name = "pnlOrder";
        pnlOrder.Size = new System.Drawing.Size(300, 789);
        pnlOrder.TabIndex = 1;
        // 
        // lblPedidoActual
        // 
        lblPedidoActual.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
        lblPedidoActual.BackColor = System.Drawing.SystemColors.ActiveBorder;
        lblPedidoActual.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblPedidoActual.Location = new System.Drawing.Point(90, 0);
        lblPedidoActual.Name = "lblPedidoActual";
        lblPedidoActual.Size = new System.Drawing.Size(149, 33);
        lblPedidoActual.TabIndex = 5;
        lblPedidoActual.Text = "Pedido Actual";
        // 
        // lblSubTotal
        // 
        lblSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblSubTotal.Location = new System.Drawing.Point(3, 590);
        lblSubTotal.Name = "lblSubTotal";
        lblSubTotal.Size = new System.Drawing.Size(211, 33);
        lblSubTotal.TabIndex = 1;
        lblSubTotal.Text = "Sub Total:";
        // 
        // lblTax
        // 
        lblTax.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        lblTax.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblTax.Location = new System.Drawing.Point(3, 623);
        lblTax.Name = "lblTax";
        lblTax.Size = new System.Drawing.Size(202, 33);
        lblTax.TabIndex = 2;
        lblTax.Text = "Impuestos:";
        // 
        // lblTotal
        // 
        lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        lblTotal.BackColor = System.Drawing.SystemColors.ActiveBorder;
        lblTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblTotal.Location = new System.Drawing.Point(3, 656);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new System.Drawing.Size(202, 33);
        lblTotal.TabIndex = 3;
        lblTotal.Text = "Total: ";
        // 
        // lstPedidos
        // 
        lstPedidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right));
        lstPedidos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
        lstPedidos.Location = new System.Drawing.Point(3, 44);
        lstPedidos.Name = "lstPedidos";
        lstPedidos.Size = new System.Drawing.Size(294, 543);
        lstPedidos.TabIndex = 4;
        // 
        // btnConfirmar
        // 
        btnConfirmar.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        btnConfirmar.BackColor = System.Drawing.SystemColors.Control;
        btnConfirmar.FlatAppearance.BorderSize = 0;
        btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnConfirmar.Location = new System.Drawing.Point(38, 714);
        btnConfirmar.Name = "btnConfirmar";
        btnConfirmar.Size = new System.Drawing.Size(211, 45);
        btnConfirmar.TabIndex = 3;
        btnConfirmar.Text = "COMPLETAR";
        btnConfirmar.UseVisualStyleBackColor = false;
        btnConfirmar.Click += btnConfirmar_Click;
        // 
        // pnlContenido
        // 
        pnlContenido.BackColor = System.Drawing.SystemColors.Control;
        pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlContenido.Location = new System.Drawing.Point(171, 0);
        pnlContenido.Name = "pnlContenido";
        pnlContenido.Size = new System.Drawing.Size(690, 789);
        pnlContenido.TabIndex = 2;
        // 
        // CajaUI
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(1161, 789);
        Controls.Add(pnlContenido);
        Controls.Add(pnlOrder);
        Controls.Add(pnlMenu);
        Location = new System.Drawing.Point(15, 15);
        Text = "TEST";
        Load += CajaUI_Load;
        pnlMenu.ResumeLayout(false);
        pnlOrder.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)lstPedidos).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblPedidoActual;

    private System.Windows.Forms.DataGridView lstPedidos;

    private System.Windows.Forms.Label lblTax;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Button btnConfirmar;
    private System.Windows.Forms.Panel pnlMenu;

    private System.Windows.Forms.Label lblSubTotal;

    private System.Windows.Forms.Panel pnlOrder;

    private System.Windows.Forms.Button btnComidaRapida;

    private System.Windows.Forms.Button btnBebidas;

    private System.Windows.Forms.Panel pnlContenido;

    #endregion
}