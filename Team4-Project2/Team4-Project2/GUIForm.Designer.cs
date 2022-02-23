namespace Team4_Project2
{
    partial class GUIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveAssemblyButton = new System.Windows.Forms.Button();
            this.clearAssemblyButton = new System.Windows.Forms.Button();
            this.loadAssemblyButton = new System.Windows.Forms.Button();
            this.assemblyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(463, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "MNAW Instruction Set GUI";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.filesToolStripMenuItem.Text = "File";
            // 
            // instructionsToolStripMenuItem
            // 
            this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
            this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.instructionsToolStripMenuItem.Text = "Information";
            this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.informationToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.saveAssemblyButton);
            this.panel1.Controls.Add(this.clearAssemblyButton);
            this.panel1.Controls.Add(this.loadAssemblyButton);
            this.panel1.Controls.Add(this.assemblyTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 590);
            this.panel1.TabIndex = 2;
            // 
            // saveAssemblyButton
            // 
            this.saveAssemblyButton.BackColor = System.Drawing.Color.DimGray;
            this.saveAssemblyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveAssemblyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.saveAssemblyButton.ForeColor = System.Drawing.Color.Black;
            this.saveAssemblyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveAssemblyButton.Location = new System.Drawing.Point(227, 461);
            this.saveAssemblyButton.Margin = new System.Windows.Forms.Padding(1);
            this.saveAssemblyButton.Name = "saveAssemblyButton";
            this.saveAssemblyButton.Size = new System.Drawing.Size(70, 40);
            this.saveAssemblyButton.TabIndex = 16;
            this.saveAssemblyButton.Text = "Save";
            this.saveAssemblyButton.UseVisualStyleBackColor = false;
            this.saveAssemblyButton.Click += new System.EventHandler(this.saveAssemblyButton_Click);
            // 
            // clearAssemblyButton
            // 
            this.clearAssemblyButton.BackColor = System.Drawing.Color.DimGray;
            this.clearAssemblyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearAssemblyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.clearAssemblyButton.ForeColor = System.Drawing.Color.Black;
            this.clearAssemblyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.clearAssemblyButton.Location = new System.Drawing.Point(4, 461);
            this.clearAssemblyButton.Margin = new System.Windows.Forms.Padding(1);
            this.clearAssemblyButton.Name = "clearAssemblyButton";
            this.clearAssemblyButton.Size = new System.Drawing.Size(140, 40);
            this.clearAssemblyButton.TabIndex = 15;
            this.clearAssemblyButton.Text = "Clear";
            this.clearAssemblyButton.UseVisualStyleBackColor = false;
            this.clearAssemblyButton.Click += new System.EventHandler(this.clearAssemblyButton_Click);
            // 
            // loadAssemblyButton
            // 
            this.loadAssemblyButton.BackColor = System.Drawing.Color.DimGray;
            this.loadAssemblyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadAssemblyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.loadAssemblyButton.ForeColor = System.Drawing.Color.Black;
            this.loadAssemblyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.loadAssemblyButton.Location = new System.Drawing.Point(155, 461);
            this.loadAssemblyButton.Margin = new System.Windows.Forms.Padding(1);
            this.loadAssemblyButton.Name = "loadAssemblyButton";
            this.loadAssemblyButton.Size = new System.Drawing.Size(70, 40);
            this.loadAssemblyButton.TabIndex = 14;
            this.loadAssemblyButton.Text = "Load";
            this.loadAssemblyButton.UseVisualStyleBackColor = false;
            this.loadAssemblyButton.Click += new System.EventHandler(this.loadAssemblyButton_Click);
            // 
            // assemblyTextBox
            // 
            this.assemblyTextBox.BackColor = System.Drawing.Color.White;
            this.assemblyTextBox.ForeColor = System.Drawing.Color.Black;
            this.assemblyTextBox.Location = new System.Drawing.Point(4, 37);
            this.assemblyTextBox.Multiline = true;
            this.assemblyTextBox.Name = "assemblyTextBox";
            this.assemblyTextBox.Size = new System.Drawing.Size(293, 420);
            this.assemblyTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "Assembly Instructions";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(318, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(934, 590);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "Static Pipeline Simulation";
            // 
            // GUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Static Pipeline Simulation";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox assemblyTextBox;
        private System.Windows.Forms.Button saveAssemblyButton;
        private System.Windows.Forms.Button clearAssemblyButton;
        private System.Windows.Forms.Button loadAssemblyButton;
    }
}

