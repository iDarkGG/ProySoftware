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
        btnBebidas = new System.Windows.Forms.Button();
        btnComidaRapida = new System.Windows.Forms.Button();
        pnlOrder = new System.Windows.Forms.Panel();
        pnlContenido = new System.Windows.Forms.Panel();
        listView1 = new System.Windows.Forms.ListView();
        lblSubTotal = new System.Windows.Forms.Label();
        lblTax = new System.Windows.Forms.Label();
        lblTotal = new System.Windows.Forms.Label();
        btnConfirmar = new System.Windows.Forms.Button();
        pnlMenu.SuspendLayout();
        pnlOrder.SuspendLayout();
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
        // 
        // pnlOrder
        // 
        pnlOrder.BackColor = System.Drawing.SystemColors.ActiveBorder;
        pnlOrder.Controls.Add(btnConfirmar);
        pnlOrder.Controls.Add(lblTotal);
        pnlOrder.Controls.Add(lblTax);
        pnlOrder.Controls.Add(lblSubTotal);
        pnlOrder.Controls.Add(listView1);
        pnlOrder.Dock = System.Windows.Forms.DockStyle.Right;
        pnlOrder.Location = new System.Drawing.Point(941, 0);
        pnlOrder.Name = "pnlOrder";
        pnlOrder.Size = new System.Drawing.Size(220, 789);
        pnlOrder.TabIndex = 1;
        // 
        // pnlContenido
        // 
        pnlContenido.BackColor = System.Drawing.SystemColors.Control;
        pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlContenido.Location = new System.Drawing.Point(171, 0);
        pnlContenido.Name = "pnlContenido";
        pnlContenido.Size = new System.Drawing.Size(770, 789);
        pnlContenido.TabIndex = 2;
        // 
        // listView1
        // 
        listView1.Location = new System.Drawing.Point(6, 12);
        listView1.Name = "listView1";
        listView1.Size = new System.Drawing.Size(211, 575);
        listView1.TabIndex = 0;
        listView1.UseCompatibleStateImageBehavior = false;
        // 
        // lblSubTotal
        // 
        lblSubTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblSubTotal.Location = new System.Drawing.Point(6, 590);
        lblSubTotal.Name = "lblSubTotal";
        lblSubTotal.Size = new System.Drawing.Size(202, 33);
        lblSubTotal.TabIndex = 1;
        lblSubTotal.Text = "SubTotal:";
        // 
        // lblTax
        // 
        lblTax.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblTax.Location = new System.Drawing.Point(6, 623);
        lblTax.Name = "lblTax";
        lblTax.Size = new System.Drawing.Size(202, 33);
        lblTax.TabIndex = 2;
        lblTax.Text = "Impuestos:";
        // 
        // lblTotal
        // 
        lblTotal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblTotal.Location = new System.Drawing.Point(6, 656);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new System.Drawing.Size(202, 33);
        lblTotal.TabIndex = 3;
        lblTotal.Text = "Total:";
        // 
        // btnConfirmar
        // 
        btnConfirmar.BackColor = System.Drawing.SystemColors.Control;
        btnConfirmar.FlatAppearance.BorderSize = 0;
        btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        btnConfirmar.Location = new System.Drawing.Point(6, 711);
        btnConfirmar.Name = "btnConfirmar";
        btnConfirmar.Size = new System.Drawing.Size(211, 45);
        btnConfirmar.TabIndex = 3;
        btnConfirmar.Text = "COMPLETAR";
        btnConfirmar.UseVisualStyleBackColor = false;
        // 
        // CajaUI
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1161, 789);
        Controls.Add(pnlContenido);
        Controls.Add(pnlOrder);
        Controls.Add(pnlMenu);
        Text = "CajaUI";
        pnlMenu.ResumeLayout(false);
        pnlOrder.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label lblTax;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Button btnConfirmar;
    private System.Windows.Forms.Panel pnlMenu;

    private System.Windows.Forms.Label lblSubTotal;

    private System.Windows.Forms.ListView listView1;

    private System.Windows.Forms.Panel pnlOrder;

    private System.Windows.Forms.ListView lstPedido;

    private System.Windows.Forms.Button btnComidaRapida;

    private System.Windows.Forms.Button btnBebidas;

    private System.Windows.Forms.Panel pnlContenido;

    #endregion
}