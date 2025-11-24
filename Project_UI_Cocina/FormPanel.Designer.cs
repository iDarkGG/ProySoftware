using System.ComponentModel;

namespace Project_UI;

partial class FormPanel
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
        pnlProductos = new System.Windows.Forms.FlowLayoutPanel();
        SuspendLayout();
        // 
        // pnlProductos
        // 
        pnlProductos.Dock = System.Windows.Forms.DockStyle.Fill;
        pnlProductos.Location = new System.Drawing.Point(0, 0);
        pnlProductos.Name = "pnlProductos";
        pnlProductos.Size = new System.Drawing.Size(800, 450);
        pnlProductos.TabIndex = 0;
        // 
        // FormPanel
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        ControlBox = false;
        Controls.Add(pnlProductos);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        MaximizeBox = false;
        MinimizeBox = false;
        ShowIcon = false;
        ShowInTaskbar = false;
        Text = "FormPanel";
        Load += FormPanel_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.FlowLayoutPanel pnlProductos;

    #endregion
}