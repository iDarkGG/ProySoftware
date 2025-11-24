using System.ComponentModel;

namespace Project_UI;

partial class Pop_Up
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
        btnCancelar = new System.Windows.Forms.Button();
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
        btnCompletar.Location = new System.Drawing.Point(62, 110);
        btnCompletar.Name = "btnCompletar";
        btnCompletar.Size = new System.Drawing.Size(91, 39);
        btnCompletar.TabIndex = 1;
        btnCompletar.Text = "Completar";
        btnCompletar.UseVisualStyleBackColor = false;
        btnCompletar.Click += btnCompletar_Click;
        // 
        // btnCancelar
        // 
        btnCancelar.BackColor = System.Drawing.Color.Red;
        btnCancelar.Location = new System.Drawing.Point(228, 110);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new System.Drawing.Size(91, 39);
        btnCancelar.TabIndex = 2;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        btnCancelar.Click += btnCancelar_Click;
        // 
        // Pop_Up
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(384, 161);
        Controls.Add(btnCancelar);
        Controls.Add(btnCompletar);
        Controls.Add(lblText);
        ShowIcon = false;
        Text = "PopUp";
        Leave += Pop_Up_Leave;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnCompletar;
    private System.Windows.Forms.Button btnCancelar;

    private System.Windows.Forms.Label lblText;

    #endregion
}