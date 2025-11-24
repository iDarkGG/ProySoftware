using System.ComponentModel;

namespace Project_UI;

partial class Pop_Up_Editar
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
        lblText = new System.Windows.Forms.Label();
        btnCompletar = new System.Windows.Forms.Button();
        btnEliminar = new System.Windows.Forms.Button();
        btnCancelar = new System.Windows.Forms.Button();
        numberSelect = new System.Windows.Forms.NumericUpDown();
        ((System.ComponentModel.ISupportInitialize)numberSelect).BeginInit();
        SuspendLayout();
        // 
        // lblText
        // 
        lblText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lblText.Location = new System.Drawing.Point(12, 9);
        lblText.Name = "lblText";
        lblText.Size = new System.Drawing.Size(360, 33);
        lblText.TabIndex = 0;
        lblText.Text = "Seleccione Accion";
        lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // btnCompletar
        // 
        btnCompletar.BackColor = System.Drawing.Color.Lime;
        btnCompletar.Location = new System.Drawing.Point(12, 110);
        btnCompletar.Name = "btnCompletar";
        btnCompletar.Size = new System.Drawing.Size(91, 39);
        btnCompletar.TabIndex = 1;
        btnCompletar.Text = "Completar";
        btnCompletar.UseVisualStyleBackColor = false;
        btnCompletar.Click += btnCompletar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.BackColor = System.Drawing.Color.Red;
        btnEliminar.Location = new System.Drawing.Point(153, 110);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new System.Drawing.Size(91, 39);
        btnEliminar.TabIndex = 2;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = false;
        btnEliminar.Click += btnCancelar_Click;
        // 
        // btnCancelar
        // 
        btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
        btnCancelar.Location = new System.Drawing.Point(281, 110);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new System.Drawing.Size(91, 39);
        btnCancelar.TabIndex = 3;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        btnCancelar.Click += button1_Click;
        // 
        // numberSelect
        // 
        numberSelect.Location = new System.Drawing.Point(73, 62);
        numberSelect.Name = "numberSelect";
        numberSelect.Size = new System.Drawing.Size(233, 23);
        numberSelect.TabIndex = 4;
        // 
        // Pop_Up_Editar
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(384, 161);
        Controls.Add(numberSelect);
        Controls.Add(btnCancelar);
        Controls.Add(btnEliminar);
        Controls.Add(btnCompletar);
        Controls.Add(lblText);
        ShowIcon = false;
        Text = "PopUp";
        Load += Pop_Up_Load;
        Leave += Pop_Up_Leave;
        ((System.ComponentModel.ISupportInitialize)numberSelect).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.NumericUpDown numberSelect;

    private System.Windows.Forms.Button btnCancelar;

    private System.Windows.Forms.Button btnCompletar;
    private System.Windows.Forms.Button btnEliminar;

    private System.Windows.Forms.Label lblText;

    #endregion
}