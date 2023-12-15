namespace _2CARPENELLI
{
    partial class ViewMemoryAndIO
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
            this.clearMemorybtn = new System.Windows.Forms.Button();
            this.btn_memory = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.hexBtn = new System.Windows.Forms.Button();
            this.binaryBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // clearMemorybtn
            // 
            this.clearMemorybtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.clearMemorybtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearMemorybtn.FlatAppearance.BorderSize = 0;
            this.clearMemorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearMemorybtn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.clearMemorybtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.clearMemorybtn.Location = new System.Drawing.Point(247, 5);
            this.clearMemorybtn.Name = "clearMemorybtn";
            this.clearMemorybtn.Size = new System.Drawing.Size(215, 61);
            this.clearMemorybtn.TabIndex = 225;
            this.clearMemorybtn.Text = "Clear Memory and I/O";
            this.clearMemorybtn.UseVisualStyleBackColor = false;
            this.clearMemorybtn.Click += new System.EventHandler(this.ClearMemoryAndIOs);
            // 
            // btn_memory
            // 
            this.btn_memory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.btn_memory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_memory.FlatAppearance.BorderSize = 0;
            this.btn_memory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_memory.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_memory.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_memory.Location = new System.Drawing.Point(12, 5);
            this.btn_memory.Name = "btn_memory";
            this.btn_memory.Size = new System.Drawing.Size(215, 61);
            this.btn_memory.TabIndex = 224;
            this.btn_memory.Text = "View Memory and I/O";
            this.btn_memory.UseVisualStyleBackColor = false;
            this.btn_memory.Click += new System.EventHandler(this.ViewMemoryAndIOs);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.textBox2.Location = new System.Drawing.Point(50, 99);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(836, 444);
            this.textBox2.TabIndex = 223;
            // 
            // hexBtn
            // 
            this.hexBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.hexBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hexBtn.FlatAppearance.BorderSize = 0;
            this.hexBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hexBtn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.hexBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hexBtn.Location = new System.Drawing.Point(483, 5);
            this.hexBtn.Name = "hexBtn";
            this.hexBtn.Size = new System.Drawing.Size(215, 61);
            this.hexBtn.TabIndex = 227;
            this.hexBtn.Text = "Hex";
            this.hexBtn.UseVisualStyleBackColor = false;
            this.hexBtn.Click += new System.EventHandler(this.HexMemory);
            // 
            // binaryBtn
            // 
            this.binaryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(29)))), ((int)(((byte)(45)))));
            this.binaryBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.binaryBtn.FlatAppearance.BorderSize = 0;
            this.binaryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.binaryBtn.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold);
            this.binaryBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.binaryBtn.Location = new System.Drawing.Point(715, 5);
            this.binaryBtn.Name = "binaryBtn";
            this.binaryBtn.Size = new System.Drawing.Size(215, 61);
            this.binaryBtn.TabIndex = 226;
            this.binaryBtn.Text = "Binary";
            this.binaryBtn.UseVisualStyleBackColor = false;
            this.binaryBtn.Click += new System.EventHandler(this.BinaryMemory);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(37)))), ((int)(((byte)(69)))));
            this.panel1.Controls.Add(this.btn_memory);
            this.panel1.Controls.Add(this.binaryBtn);
            this.panel1.Controls.Add(this.hexBtn);
            this.panel1.Controls.Add(this.clearMemorybtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 592);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 104);
            this.panel1.TabIndex = 228;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(37)))), ((int)(((byte)(69)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 592);
            this.panel2.TabIndex = 229;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 22.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(42, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(337, 44);
            this.label2.TabIndex = 224;
            this.label2.Text = "MEMORY AND I/O";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ViewMemoryAndIO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 696);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewMemoryAndIO";
            this.Text = "ViewMemoryAndIO";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clearMemorybtn;
        private System.Windows.Forms.Button btn_memory;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button hexBtn;
        private System.Windows.Forms.Button binaryBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}