namespace kpss
{
    partial class soru
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSoru = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtA = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.txtD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbtnA = new System.Windows.Forms.RadioButton();
            this.rdbtnB = new System.Windows.Forms.RadioButton();
            this.rdbtnC = new System.Windows.Forms.RadioButton();
            this.rdbtnD = new System.Windows.Forms.RadioButton();
            this.cmbdersadi = new System.Windows.Forms.ComboBox();
            this.cmbkadi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 398);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(830, 281);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick);
            // 
            // txtSoru
            // 
            this.txtSoru.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoru.Location = new System.Drawing.Point(151, 79);
            this.txtSoru.Multiline = true;
            this.txtSoru.Name = "txtSoru";
            this.txtSoru.Size = new System.Drawing.Size(452, 137);
            this.txtSoru.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button1.Location = new System.Drawing.Point(619, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "EKLE";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Font = new System.Drawing.Font("Kristen ITC", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.button2.Location = new System.Drawing.Point(619, 345);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 47);
            this.button2.TabIndex = 9;
            this.button2.Text = "SİL";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtA
            // 
            this.txtA.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.Location = new System.Drawing.Point(151, 222);
            this.txtA.Multiline = true;
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(192, 82);
            this.txtA.TabIndex = 10;
            // 
            // txtB
            // 
            this.txtB.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.Location = new System.Drawing.Point(411, 222);
            this.txtB.Multiline = true;
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(192, 82);
            this.txtB.TabIndex = 11;
            // 
            // txtC
            // 
            this.txtC.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtC.Location = new System.Drawing.Point(151, 310);
            this.txtC.Multiline = true;
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(192, 82);
            this.txtC.TabIndex = 12;
            // 
            // txtD
            // 
            this.txtD.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtD.Location = new System.Drawing.Point(411, 310);
            this.txtD.Multiline = true;
            this.txtD.Name = "txtD";
            this.txtD.Size = new System.Drawing.Size(192, 82);
            this.txtD.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Soru Adı :";
            // 
            // rdbtnA
            // 
            this.rdbtnA.AutoSize = true;
            this.rdbtnA.Font = new System.Drawing.Font("Kristen ITC", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnA.Location = new System.Drawing.Point(91, 223);
            this.rdbtnA.Name = "rdbtnA";
            this.rdbtnA.Size = new System.Drawing.Size(54, 26);
            this.rdbtnA.TabIndex = 15;
            this.rdbtnA.Text = "A :";
            this.rdbtnA.UseVisualStyleBackColor = true;
            // 
            // rdbtnB
            // 
            this.rdbtnB.AutoSize = true;
            this.rdbtnB.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnB.Location = new System.Drawing.Point(353, 222);
            this.rdbtnB.Name = "rdbtnB";
            this.rdbtnB.Size = new System.Drawing.Size(52, 27);
            this.rdbtnB.TabIndex = 16;
            this.rdbtnB.Text = "B :";
            this.rdbtnB.UseVisualStyleBackColor = true;
            // 
            // rdbtnC
            // 
            this.rdbtnC.AutoSize = true;
            this.rdbtnC.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnC.Location = new System.Drawing.Point(91, 310);
            this.rdbtnC.Name = "rdbtnC";
            this.rdbtnC.Size = new System.Drawing.Size(54, 27);
            this.rdbtnC.TabIndex = 17;
            this.rdbtnC.TabStop = true;
            this.rdbtnC.Text = "C :";
            this.rdbtnC.UseVisualStyleBackColor = true;
            // 
            // rdbtnD
            // 
            this.rdbtnD.AutoSize = true;
            this.rdbtnD.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnD.Location = new System.Drawing.Point(353, 310);
            this.rdbtnD.Name = "rdbtnD";
            this.rdbtnD.Size = new System.Drawing.Size(55, 27);
            this.rdbtnD.TabIndex = 18;
            this.rdbtnD.TabStop = true;
            this.rdbtnD.Text = "D :";
            this.rdbtnD.UseVisualStyleBackColor = true;
            // 
            // cmbdersadi
            // 
            this.cmbdersadi.FormattingEnabled = true;
            this.cmbdersadi.Location = new System.Drawing.Point(151, 17);
            this.cmbdersadi.Name = "cmbdersadi";
            this.cmbdersadi.Size = new System.Drawing.Size(257, 21);
            this.cmbdersadi.TabIndex = 19;
            this.cmbdersadi.SelectedIndexChanged += new System.EventHandler(this.cmbdersadi_SelectedIndexChanged);
            // 
            // cmbkadi
            // 
            this.cmbkadi.FormattingEnabled = true;
            this.cmbkadi.Location = new System.Drawing.Point(151, 47);
            this.cmbkadi.Name = "cmbkadi";
            this.cmbkadi.Size = new System.Drawing.Size(345, 21);
            this.cmbkadi.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ders Adı :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 23);
            this.label3.TabIndex = 21;
            this.label3.Text = "Kategori Adı :";
            // 
            // soru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(830, 679);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbkadi);
            this.Controls.Add(this.cmbdersadi);
            this.Controls.Add(this.rdbtnD);
            this.Controls.Add(this.rdbtnC);
            this.Controls.Add(this.rdbtnB);
            this.Controls.Add(this.rdbtnA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtD);
            this.Controls.Add(this.txtC);
            this.Controls.Add(this.txtB);
            this.Controls.Add(this.txtA);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSoru);
            this.Controls.Add(this.dataGridView1);
            this.Name = "soru";
            this.Text = "soru";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSoru;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.TextBox txtD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbdersadi;
        private System.Windows.Forms.ComboBox cmbkadi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.RadioButton rdbtnA;
        public System.Windows.Forms.RadioButton rdbtnB;
        public System.Windows.Forms.RadioButton rdbtnC;
        public System.Windows.Forms.RadioButton rdbtnD;
    }
}